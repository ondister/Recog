using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Recog.Data;
using Recog.RecogCore;
using Recog.RecogCore.AnswerGrid;
using System;


namespace Recog.BlankRecognition
{
   public class Recognizer
    {
       private pBaseEntities _ge;
       private Canvas _canvas;
       private Bitmap _image;
       private int _testid;
       public event EventHandler RecItem;
       private EventArgs arg;
       private void OnRecItem() { if (RecItem != null) { RecItem(this, arg); } }
       public Canvas Canvas
       {
           get { return _canvas; }
       }
       public Recognizer(pBaseEntities GlobalEntities,Bitmap image,int testid)
       {
           _ge = GlobalEntities;
           _image = image;
           _testid = testid;
           arg = new EventArgs();
       }

       public void Prerecognize()
       {
           
           try
           {
               _canvas = new Canvas((Bitmap)_image.Clone(), 8.0d);
               _canvas.RecognizeImage();

               testsparam t = _ge.testsparams.First(tp => tp.idt == _testid);

               t.answersparams.Load();
               IEnumerable<answersparam> answers = t.answersparams.Where(a => a.idt == t.idt);
               foreach (answersparam a in answers)
               {
                   Distances _distances = new Distances();
                   _distances.Add(_canvas.TopLeftMarker, (double)a.toplx, (double)a.toply);
                   _distances.Add(_canvas.TopRightMarker, (double)a.toprx, (double)a.topry);
                   _distances.Add(_canvas.BottomLeftMarker, (double)a.blx, (double)a.bly);
                   _distances.Add(_canvas.BottomRightMarker, (double)a.brx, (double)a.bry);

                   Answer _answer = new Answer(_canvas.CorrectedImage, (int)a.num, (int)a.cellscount, _distances, (int)a.intercellswidth, (int)a.cellswidth, (int)a.cellshight);

                   IEnumerable<cellsparam> cells = a.cellsparams.Where(c => c.ida == a.ida);
                   a.cellsparams.Load();
                   int i = 0;
                   foreach (cellsparam cp in cells)
                   {
                       _answer.Cells[i].ContentDescription = cp.description.Trim();
                       i++;
                   }

                   _canvas.Answers.Add(_answer);
               }
               OnRecItem();
           }
           catch (Exception ex) { throw ex; }
       }

       public RecogResult FindBestRecognize()
       {
          
           List<RecogResult> rlist = new List<RecogResult>();
           for (double rng = 0; rng < 1; rng += 0.1)      
  //for (double rng = 0.2; rng < 0.5; rng += 0.1)
           {
               for (double m = 0; m < 1 - rng; m += 0.01)
               {
                   rlist.Add(Recognize(rng, m));
                   OnRecItem();
               }
           }
           RecogResult rr= FindMinMistake(rlist);
           
           return rr;
       }

       private RecogResult FindMinMistake(List<RecogResult> rlist)
       {
           return rlist.First(m => m.MistakeCount == rlist.Min(mn => mn.MistakeCount));
       }

       public RecogResult Recognize(double rangewidth, double mindisp)
       {
          
           RecogResult rr = new RecogResult();
           rr.MinDisp = double.NaN;
           rr.RangeWidth = double.NaN;
           rr.MistakeCount = int.MaxValue;
              _canvas.Answers.ClearContent();
               _canvas.Answers.GetContent(mindisp, rangewidth + mindisp);

               rr = new RecogResult();
               rr.MinDisp = mindisp;
               rr.RangeWidth = rangewidth;
               rr.MistakeCount = _canvas.Answers.CountWithDoubleCross+_canvas.Answers.CountWithEmpty+_canvas.Answers.CountWithMiss;
              
        
           return rr;
       }
      
    }
}
