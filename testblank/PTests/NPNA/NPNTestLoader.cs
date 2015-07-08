using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
using Recog.Controls;
using System.Xml.Serialization;

namespace Recog.PTests.NPNA
{
    public class NPNTestLoader
    {
         private NPNAnswers _answers;
            private answersparam _currentaparam;
            private pBaseEntities _ge;
            private TwoButtonsControl _ktc;
            public event EventHandler TestDone;
            private TestDoneEventArgs arg;
            private void OnTestDone() { if (TestDone != null) { TestDone(this, arg); } }

            [XmlElement(Type = typeof(NPNAnswer))]
           
            public NPNAnswers Answers
            {
                get { return _answers; }
            }

            public NPNTestLoader(pBaseEntities GlobalEntities, TwoButtonsControl Control)
            {
                _ge = GlobalEntities;
                _ktc = Control;
                _answers = new NPNAnswers(_ge);
                arg = new TestDoneEventArgs();
            }

        public void Start()
        {
            testsparam t = _ge.testsparams.First(tp => tp.idt == (int)EnumPTests.NPNA);
            t.answersparams.Load();
            _currentaparam = t.answersparams.First(ap => ap.num == 1);
            _ktc.lb_caption.Text = _currentaparam.buttondescription;
            _currentaparam.cellsparams.Load();
            cellsparam c1 = _currentaparam.cellsparams.First(cp => cp.description.Trim() == "Да");
            _ktc.lb_1.Text = "1. " + c1.buttonsescription;
            cellsparam c2 = _currentaparam.cellsparams.First(cp => cp.description.Trim() == "Нет");
            _ktc.lb_2.Text = "2. " + c2.buttonsescription;
           
        }

        public void Stop()
        {
        OnTestDone();
        }

        public void Next()
        {
            if (_currentaparam.num != 276)
            {
                testsparam t = _ge.testsparams.First(tp => tp.idt == (int)EnumPTests.NPNA);
                t.answersparams.Load();
                _currentaparam = t.answersparams.First(ap => ap.num == _currentaparam.num + 1);
                _ktc.lb_caption.Text = _currentaparam.buttondescription;
                _currentaparam.cellsparams.Load();
                cellsparam c1 = _currentaparam.cellsparams.First(cp => cp.description.Trim() == "Да");
                _ktc.lb_1.Text = "1. " + c1.buttonsescription;
                cellsparam c2 = _currentaparam.cellsparams.First(cp => cp.description.Trim() == "Нет");
                _ktc.lb_2.Text = "2. " + c2.buttonsescription;
               
            }
            else { this.Stop(); }
        }
        public void SendKey(int cellindex)
        {
            NPNAnswer ka = new NPNAnswer();
            ka.Time = DateTime.Now;
            ka.AnswerIndex = (int)_currentaparam.num;
            ka.AnswerDescription = _currentaparam.buttondescription;
            ka.SelectedCellIndex = cellindex;
            string celldescription="d";
            switch (cellindex)
            { 
                case 0:
                    celldescription="Нет";
                    break;
                case 1:
                    celldescription = "Да";
                    break;            
            }
            cellsparam c = _currentaparam.cellsparams.First(cp => cp.description.Trim() == celldescription);
            ka.SelectedCellDescription = celldescription;
            ka.SelectedCellButtonDescription = c.buttonsescription;
            _answers.Add(ka);
        }
    }
}
