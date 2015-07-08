using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Recog.RecogCore;
using Recog.Data;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Recog.RecogCore.AnswerGrid;
using Recog.PTests;
namespace Recog.TestConstruktor
{
    /// <summary>
    /// Конструктор теста
    /// </summary>
    public partial class TestAdd : Form
    {
      // private pBaseEntities pb;
       private AnwerEdit ansedf;
       private Canvas _canvas;

       public Canvas Canvas
       {
           get { return _canvas; }
           set { _canvas = value; }
       }
        /// <summary>
        /// Инициализирует новый объект на основе класса конструктора тестов
        /// </summary>
        public TestAdd()
        {
            InitializeComponent();
        }

        private void cmd_openimg_Click(object sender, EventArgs e)
        {
            if (this.oof_dialog.ShowDialog() == DialogResult.OK)
            {
                string fn = this.oof_dialog.FileName;

                this.pb_img.Image = new Bitmap(fn);
                this.cmd_addtest.Enabled = true;
            }

        }

        private void TConstructor_Load(object sender, EventArgs e)
        {
           // pb = new pBaseEntities();
            ansedf = new AnwerEdit();

        }

        private void cmd_addtest_Click(object sender, EventArgs e)
        {
            this.lst_answ.Items.Clear();
            _canvas = new Canvas((Bitmap)this.pb_img.Image,8d);
            _canvas.RecognizeImage();
            this.pb_img.Image = _canvas.CorrectedImage;

           //KetelData td = new KetelData();
            pBaseEntities pb = new pBaseEntities();
            
           // modulData md = new modulData();
           // testsparam tst =  testsparam.Createtestsparam(0, "ОПРОСНИК МОДУЛЬ", 200, true);
           // for (int a = 0; a < tst.answerscount; a++)
           // {
           //     answersparam ap = answersparam.Createanswersparam(0, tst.idt, "Вопрос № " + (a + 1), 2);
           //     ap.num = a + 1;
           //     ap.buttondescription = md.answers[a].text;
           //     ap.intercellswidth = 27;
           //     ap.cellshight = 25;
           //     ap.cellswidth = 25;
           //     ap.toplx = 0;
           //     ap.toply = 0;
           //     ap.toprx = 0;
           //     ap.topry = 0;
           //     ap.blx = 0;
           //     ap.bly = 0;
           //     ap.brx = 0;
           //     ap.bry = 0;

           //     cellsparam cp = cellsparam.Createcellsparam(0, ap.ida);
           //     cp.description = "Да";
           //     cp.buttonsescription = "Да";
           //     cp.mark = md.answers[a].isYes?md.answers[a].mark:0;
           //     cellsparam cp1 = cellsparam.Createcellsparam(0, ap.ida);
           //     cp1.description = "Нет";
           //     cp1.buttonsescription = "Нет";
           //     cp1.mark = md.answers[a].isYes ? 0 : md.answers[a].mark;
             


           //     ap.cellsparams.Add(cp);
           //     ap.cellsparams.Add(cp1);
             
           //     tst.answersparams.Add(ap);


           // }

           //pb.testsparams.AddObject(tst);
           // pb.SaveChanges();




            testsparam t = pb.testsparams.First(tp => tp.idt == (int)EnumPTests.NPNA);
            t.answersparams.Load();
            IEnumerable<answersparam> answers = t.answersparams;

            foreach (answersparam ap in answers)
            {
                ListViewItem it = new ListViewItem(ap.num.ToString());
                it.SubItems.Add(ap.ida.ToString());
                it.SubItems.Add(ap.description.ToString());
                it.SubItems.Add(ap.intercellswidth.ToString());
                it.SubItems.Add(ap.cellswidth.ToString());
                it.SubItems.Add(ap.cellshight.ToString());
                it.SubItems.Add(ap.toplx.ToString());
                it.SubItems.Add(ap.toply.ToString());
                this.lst_answ.Items.Add(it);
                //добавляем вопросы на грид
                //создаем коллекцию дистанций для каждого ответа

                Distances _distances = new Distances();
                _distances.Add(_canvas.TopLeftMarker, (double)ap.toplx, (double)ap.toply);
                _distances.Add(_canvas.TopRightMarker, (double)ap.toprx, (double)ap.topry);
                _distances.Add(_canvas.BottomLeftMarker, (double)ap.blx, (double)ap.bly);
                _distances.Add(_canvas.BottomRightMarker, (double)ap.brx, (double)ap.bry);

                //_distances.Add(_canvas.TopLeftMarker, 100, 100);
                //_distances.Add(_canvas.TopRightMarker, 100, 100);
                //_distances.Add(_canvas.BottomLeftMarker, 100, 100);
                //_distances.Add(_canvas.BottomRightMarker, 100, 100);


                //создаем ответы
                Answer _answer = new Answer(_canvas.CorrectedImage, (int)ap.ida, (int)ap.cellscount, _distances, (int)ap.intercellswidth, (int)ap.cellswidth, (int)ap.cellshight);
                _answer.Select();
                _canvas.Answers.Add(_answer);

            }

                
               

        }



        private byte[] ConvertBitMapToByte(Bitmap img)
        {
            byte[] Result = null;
            BitmapData bData = img.LockBits(new Rectangle(new Point(), img.Size), ImageLockMode.ReadOnly, img.PixelFormat);
            int ByteCount = bData.Stride * img.Height;
            Result = new byte[ByteCount];
            Marshal.Copy(bData.Scan0, Result, 0, ByteCount);
            img.UnlockBits(bData);
            return Result;
        }


        private Bitmap ConvertByteToBitMap(byte[] Ishod)
        {
            Bitmap img = new Bitmap(640, 480);
            BitmapData bData = img.LockBits(new Rectangle(new Point(), img.Size), ImageLockMode.WriteOnly, img.PixelFormat);
            Marshal.Copy(Ishod, 0, bData.Scan0, Ishod.Length);
            img.UnlockBits(bData);
            return img;
        }

      

        private void lst_answ_ItemActivate(object sender, EventArgs e)
        {
           

            ListView lb = (ListView)sender;
            ansedf.Dispose();
            ansedf = new AnwerEdit();


            ansedf.fx = lb.Bottom;
            ansedf.fy = 0;
            ansedf.IDA = Convert.ToInt16(lb.FocusedItem.SubItems[1].Text);
            ansedf.Description = lb.FocusedItem.SubItems[2].Text;
            ansedf.InterCellWidth = Convert.ToInt16(lb.FocusedItem.SubItems[3].Text);
            ansedf.CellWidth = Convert.ToInt16(lb.FocusedItem.SubItems[4].Text);
            ansedf.CellHight = Convert.ToInt16(lb.FocusedItem.SubItems[5].Text);
          
            
            ansedf.Show();
        }

        int cnt = 0;
        int x1 = 0;
        int x2 = 0;
        int y1 = 0;
        int y2 = 0;

        private void pb_img_MouseClick(object sender, MouseEventArgs e)
        {
           
            if (e.Button == MouseButtons.Right)
            {
                cnt++;
                if (cnt == 2)
                {
                    x2 = e.X;
                    y2 = e.Y;

                    MessageBox.Show("X" + (x2 - x1) + "Y" + (y2 - y1));
                    cnt = 0;
                     x1 = 0;
                    x2 = 0;
                     y1 = 0;
                     y2 = 0;
                    
                }
                if(cnt==1)
                {
                    x1 = e.X;
                    y1 = e.Y;
                }
               
                
            }

            //Distances _distances = new Distances();
            //_distances.Add(_canvas.TopLeftMarker, e.X, e.Y);
            //_distances.Add(_canvas.TopRightMarker, e.X, e.Y);
            //_distances.Add(_canvas.BottomLeftMarker, e.X, e.Y);
            //_distances.Add(_canvas.BottomRightMarker, e.X, e.Y);

            //if (this.lst_answ.SelectedIndices.Count != 0)
            //{
            //    int i = this.lst_answ.SelectedIndices[0];
            //    _canvas.Answers[i].Clear();
            //    _canvas.Answers[i].Cells.ReMeasure(_distances, _canvas.Answers[i].InterCentresDistX, _canvas.Answers[i].CellsWidth, _canvas.Answers[i].CellsHeight);
            //    _canvas.Answers[i].Select();
            //    pb_img.Refresh();

            //    pBaseEntities pb = new pBaseEntities();
            //    testsparam t = pb.testsparams.First(tp => tp.idt == (int)EnumPTests.Modul2);
            //    t.answersparams.Load();
            //    answersparam a = t.answersparams.First(ap => ap.num == i + 1);
            //    //  IEnumerable<answersparam> answers = pb.answersparams.Where(a => a.num ==i+1);

            //    a.toplx = (int)_distances[0].OnX;
            //    a.toply = (int)_distances[0].OnY;

            //    a.toprx = (int)_distances[1].OnX;
            //    a.topry = (int)_distances[1].OnY;

            //    a.blx = (int)_distances[2].OnX;
            //    a.bly = (int)_distances[2].OnY;

            //    a.brx = (int)_distances[3].OnX;
            //    a.bry = (int)_distances[3].OnY;

            //    pb.SaveChanges();

            //}
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // это необходимо менять
            double startx =58.8;
            double starty = 197;
            int rowscount = 31;
            int colscount = 9;
            double colsinterval = 86.6;
            double rowsinterval = 27.5;
            //


             pBaseEntities pb = new pBaseEntities();
               testsparam t = pb.testsparams.First(tp => tp.idt == (int)EnumPTests.NPNA);
               t.answersparams.Load();

            int curransverindex = 0;
            double x = startx;
            
            for(int col=0;col<colscount;col++)
            {
                double y = starty;

                for (int row = 0; row < rowscount;row++ )
                {
                    if (curransverindex <= t.answerscount-1)
                    {
                        Distances _distances = new Distances();
                        _distances.Add(_canvas.TopLeftMarker, (int)x, (int)y);
                        _distances.Add(_canvas.TopRightMarker, (int)x, (int)y);
                        _distances.Add(_canvas.BottomLeftMarker, (int)x, (int)y);
                        _distances.Add(_canvas.BottomRightMarker, (int)x, (int)y);

                        _canvas.Answers[curransverindex].Clear();
                        _canvas.Answers[curransverindex].Cells.ReMeasure(_distances, _canvas.Answers[curransverindex].InterCentresDistX, _canvas.Answers[curransverindex].CellsWidth, _canvas.Answers[curransverindex].CellsHeight);
                        _canvas.Answers[curransverindex].Select();
                        pb_img.Refresh();

                        //это комментить при подгонке
                        answersparam a = t.answersparams.First(ap => ap.num == curransverindex + 1);


                        a.toplx = (int)_distances[0].OnX;
                        a.toply = (int)_distances[0].OnY;

                        a.toprx = (int)_distances[1].OnX;
                        a.topry = (int)_distances[1].OnY;

                        a.blx = (int)_distances[2].OnX;
                        a.bly = (int)_distances[2].OnY;

                        a.brx = (int)_distances[3].OnX;
                        a.bry = (int)_distances[3].OnY;

                       pb.SaveChanges();



                        y += rowsinterval;
                        
                        curransverindex++;
                    }
                  
                }
                x += colsinterval;
            }

         
        }

        private void pb_img_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.X.ToString() + "_" + (double)e.Y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pBaseEntities pb = new pBaseEntities();

            LData md = new LData();
            testsparam tst = pb.testsparams.First(t => t.idt == (int)EnumPTests.NPNA);
            tst.answersparams.Load();
            
            for (int a = 0; a < tst.answerscount; a++)
            {
                answersparam ap = answersparam.Createanswersparam(0, tst.idt, "Вопрос № " + (a + 1), 2);
                ap.num = a + 1;
                ap.buttondescription = md.answers[a].text;
                ap.intercellswidth = 27;
                ap.cellshight = 25;
                ap.cellswidth = 25;
                ap.toplx = 0;
                ap.toply = 0;
                ap.toprx = 0;
                ap.topry = 0;
                ap.blx = 0;
                ap.bly = 0;
                ap.brx = 0;
                ap.bry = 0;

                cellsparam cp = cellsparam.Createcellsparam(0, ap.ida);
                cp.description = "Да";
                cp.buttonsescription = "Да";
                cp.mark = 1;
                cellsparam cp1 = cellsparam.Createcellsparam(0, ap.ida);
                cp1.description = "Нет";
                cp1.buttonsescription = "Нет";
                cp1.mark = 0;



                ap.cellsparams.Add(cp);
                ap.cellsparams.Add(cp1);

                tst.answersparams.Add(ap);


            }

          //  pb.testsparams.AddObject(tst);
          //  pb.SaveChanges();
        }

       

    }
}
