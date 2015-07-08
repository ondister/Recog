using System;
using System.IO;
using System.Xml.Serialization;
using Recog.Data;
namespace Recog.PTests.PNN
{
   public class TestPnn:ITest
    {
       private TestPnnForm _tstfrm;
       private bool _alone;
       private pBaseEntities _ge;
       private fBaseEntities _fe;
       private int _humanid;
       private int _id;
       public event EventHandler TestDone;
       private TestDoneEventArgs arg;
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

       public TestPnn(pBaseEntities ge, fBaseEntities fe, bool IsAlone)
       {
           arg = new TestDoneEventArgs();
           _ge = ge;
           _fe = fe;
           _alone = IsAlone;
           _tstfrm = new TestPnnForm();
          
          
       }
        public void Start()
       {
           _tstfrm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            _tstfrm.Show();
            _tstfrm.endtestcontrol.btn_savedata.Click += new EventHandler(btn_savedata_Click);
            _tstfrm.endtestcontrol.btn_exit.Click += new EventHandler(btn_exit_Click);
        }

        void btn_exit_Click(object sender, EventArgs e)
        {
            arg.Reason = "Выход";
            this.OnTestDone();
            _tstfrm.Close();
            
        }

        void btn_savedata_Click(object sender, EventArgs e)
        {
            this.ResultsToBase();
            arg.Reason = "Закончен чесно";
            this.OnTestDone();
            this.End();
        }

        public void End()
        {
            _tstfrm.Close();
        }


        public void ResultsToBase()
        {
            PNNAnswers Answers = _tstfrm.testloader.Answers;

            XmlSerializer mySerializer = new XmlSerializer(typeof(PNNAnswers));
            
             StringWriter myWriter = new StringWriter();
             mySerializer.Serialize(myWriter, Answers);

             testresult t = testresult.Createtestresult(0, _humanid, DateTime.Now, (int)EnumPTests.PNN, myWriter.ToString(), "auto");
                _fe.testresults.AddObject(t);
                _fe.SaveChanges();

             myWriter.Close();
            
        }

















       


        
        #region Члены ITest


        public testresult ResultsToBase(RecogCore.AnswerGrid.Answers Answers)
        {
            throw new Exception("Для этого теста не существует бланка");
        }

        #endregion
    }
}
