using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
using System.Xml.Serialization;
using System.IO;

namespace Recog.PTests.Prognoz
{
  public   class TestP:ITest
    {

        private bool _alone;
        private pBaseEntities _ge;
        private fBaseEntities _fe;
        private int _humanid;
        private int _id;
        public event EventHandler TestDone;
        private TestDoneEventArgs arg;
        private TestPForm tkf;
        private void OnTestDone() { if (TestDone != null) { TestDone(this, arg); } }
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public int HumanID
        {
            get
            {
                return _humanid;
            }
            set
            {
                _humanid = value;
            }
        }

        public TestP(pBaseEntities ge, fBaseEntities fe,bool  IsAlone)
        {
            arg = new TestDoneEventArgs();
            _ge = ge;
            _fe = fe;
            _alone = IsAlone;
            tkf = new TestPForm(_ge);
            tkf.etc_end.btn_savedata.Click += new EventHandler(btn_savedata_Click);
            tkf.etc_end.btn_exit.Click += new EventHandler(btn_exit_Click);
        }

        void btn_exit_Click(object sender, EventArgs e)
        {
            arg.Reason = "Выход";
            this.OnTestDone();
            tkf.Close();
        }

        void btn_savedata_Click(object sender, EventArgs e)
        {
            this.ResultsToBase();
            arg.Reason = "Закончен честно";
            this.OnTestDone();
            this.End();
        }
        public void Start()
        {
            tkf.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            tkf.Show();
        }

        public void End()
        {
            tkf.Close();
        }

        public void ResultsToBase()
        {
            PAnswers Answers = tkf.ktl.Answers;

            XmlSerializer mySerializer = new XmlSerializer(typeof(PAnswers));

            StringWriter myWriter = new StringWriter();
            mySerializer.Serialize(myWriter, Answers);

            testresult t = testresult.Createtestresult(0, _humanid, DateTime.Now, (int)EnumPTests.Prognoz, myWriter.ToString(),"auto");
            _fe.testresults.AddObject(t);
            _fe.SaveChanges();

            myWriter.Close();
        }



        #region Члены ITest


        public testresult ResultsToBase(RecogCore.AnswerGrid.Answers Answers)
        {
            PAnswers _answersforbase = new PAnswers(_ge);
            
            for (int i = 0, count = Answers.Count; i < count; i++)
            {
                _answersforbase.Add(Answers[i].SelectedCellIndex(), Answers[i].ContentDescription, "", Answers[i].Id, "");
            }
            XmlSerializer mySerializer = new XmlSerializer(typeof(PAnswers));

            StringWriter myWriter = new StringWriter();
            mySerializer.Serialize(myWriter, _answersforbase);

            testresult t = testresult.Createtestresult(0, _humanid, DateTime.Now, (int)EnumPTests.Prognoz, myWriter.ToString(), "manual");
            _fe.testresults.AddObject(t);
            _fe.SaveChanges();

            myWriter.Close();
            return t;
        }

        #endregion
    }
}
