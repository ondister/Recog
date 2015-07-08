using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Controls;
using Recog.Data;
using System.Xml.Serialization;

namespace Recog.PTests.Kettell
{

        public class KettellATestLoader
    {
            private KettellAnswers _answers;
            private answersparam _currentaparam;
            private pBaseEntities _ge;
            private ThreeButtonsControl _ktc;
            public event EventHandler TestDone;
            private TestDoneEventArgs arg;
            private void OnTestDone() { if (TestDone != null) { TestDone(this, arg); } }

            [XmlElement(Type = typeof(KettellAnswer))]
           
            public KettellAnswers Answers
            {
                get { return _answers; }
            }

            public KettellATestLoader(pBaseEntities GlobalEntities, ThreeButtonsControl Control)
            {
                _ge = GlobalEntities;
                _ktc = Control;
                _answers = new KettellAnswers(_ge);
                arg = new TestDoneEventArgs();
            }

        public void Start()
        {
            testsparam t = _ge.testsparams.First(tp => tp.idt == (int)EnumPTests.KettellA);
            t.answersparams.Load();
            _currentaparam = t.answersparams.First(ap => ap.num == 1);
            _ktc.lb_caption.Text = _currentaparam.buttondescription;
            _currentaparam.cellsparams.Load();
            cellsparam c1 = _currentaparam.cellsparams.First(cp => cp.description.Trim() == "A");
            _ktc.lb_1.Text = "1. " + c1.buttonsescription;
            cellsparam c2 = _currentaparam.cellsparams.First(cp => cp.description.Trim() == "B");
            _ktc.lb_2.Text = "2. " + c2.buttonsescription;
            cellsparam c3 = _currentaparam.cellsparams.First(cp => cp.description.Trim() == "C");
            _ktc.lb_3.Text = "3. " + c3.buttonsescription;
        }

        public void Stop()
        {
        OnTestDone();
        }

        public void Next()
        {
            if (_currentaparam.num != 187)
            {
                testsparam t = _ge.testsparams.First(tp => tp.idt == (int)EnumPTests.KettellA);
                t.answersparams.Load();
                _currentaparam = t.answersparams.First(ap => ap.num == _currentaparam.num + 1);
                _ktc.lb_caption.Text = _currentaparam.buttondescription;
                _currentaparam.cellsparams.Load();
                cellsparam c1 = _currentaparam.cellsparams.First(cp => cp.description.Trim() == "A");
                _ktc.lb_1.Text = "1. " + c1.buttonsescription;
                cellsparam c2 = _currentaparam.cellsparams.First(cp => cp.description.Trim() == "B");
                _ktc.lb_2.Text = "2. " + c2.buttonsescription;
                cellsparam c3 = _currentaparam.cellsparams.First(cp => cp.description.Trim() == "C");
                _ktc.lb_3.Text = "3. " + c3.buttonsescription;
            }
            else { this.Stop(); }
        }
        public void SendKey(int cellindex)
        {
            KettellAnswer ka = new KettellAnswer();
            ka.Time = DateTime.Now;
            ka.AnswerIndex = (int)_currentaparam.num;
            ka.AnswerDescription = _currentaparam.buttondescription;
            ka.SelectedCellIndex = cellindex;
            string celldescription="d";
            switch (cellindex)
            { 
                case 0:
                    celldescription="A";
                    break;
                case 1:
                    celldescription = "B";
                    break;
                case 2:
                    celldescription = "C";
                    break;
            }
            cellsparam c = _currentaparam.cellsparams.First(cp => cp.description.Trim() == celldescription);
            ka.SelectedCellDescription = celldescription;
            ka.SelectedCellButtonDescription = c.buttonsescription;
            _answers.Add(ka);
        }
       
       
    }
}
