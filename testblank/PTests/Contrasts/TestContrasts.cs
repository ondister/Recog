using System;
using System.IO;
using System.Xml.Serialization;
using Recog.Data;
using System.Windows.Forms;
using Recog.Controls;
namespace Recog.PTests.Contrasts
{
   public class TestContrasts:ITest
    {
        private int _humanid;
        private int _id;
        private fBaseEntities _fe;
       private ContrastsAnswers _answers;
        public event EventHandler TestDone;
        private TestDoneEventArgs arg;
        private TestContrastsForm _contrastsform;
        private EndTestControl _endtestcontrol;
        StartTestControl _startcontrol;
        ContrastsControl _contrastcontrol;
        Panel _parentpanel;
        Panel _childpanel;
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

        public TestContrasts(fBaseEntities fe)
        {
            _fe = fe;
            _contrastsform = new TestContrastsForm();
            _startcontrol = new StartTestControl();
            _parentpanel = new Panel();
            _childpanel = new Panel();
            _contrastcontrol = new ContrastsControl();
            _endtestcontrol = new EndTestControl();
            _answers = new ContrastsAnswers();
            arg = new TestDoneEventArgs();
        }


        public void Start()
        {
            _startcontrol.Dock = DockStyle.Fill;
            _startcontrol.AboutTest = "Вам необходимо выбрать из 10 предъявленных контрастных кругов три наиболее предпочитаемых, а затем три наиболее отвергаемых цветовых контраста. Выбирать цвета следует быстро, по первому впечатлению";
            _startcontrol.btn_start.Click += new EventHandler(btn_start_Click);
            _contrastsform.Controls.Add(_startcontrol);
           
            _contrastsform.Show();
        }

        void btn_start_Click(object sender, EventArgs e)
        {
            _startcontrol.Hide();

            _parentpanel.Dock = DockStyle.Fill;
            _parentpanel.AutoScroll = true;
            _contrastsform.Controls.Add(_parentpanel);
          
            _parentpanel.Controls.Add(_childpanel);
           
            _childpanel.Controls.Add(_contrastcontrol);
            _contrastcontrol.LoadColors();
            _childpanel.AutoSize = true;
            _contrastcontrol.CycleClick += new EventHandler(_contrastcontrol_CycleClick);
        }

        void _contrastcontrol_CycleClick(object sender, EventArgs e)
        {
            CycleClickArgs args = (CycleClickArgs)e;
           
                _answers.Add(DateTime.Now, args.Id);

                if (_answers.Count == 6)
                {   
                _parentpanel.Hide();
                _endtestcontrol.Dock = DockStyle.Fill;
                _endtestcontrol.btn_savedata.Click += new EventHandler(btn_savedata_Click);
                _endtestcontrol.btn_exit.Click += new EventHandler(btn_exit_Click);
                _endtestcontrol.AboutTest = "\nСпасибо, что прошли тест. Теперь подтвердите достоверность Ваших результатов и добровольность тестирования, нажав кнопку \' Сохранить результаты\'. \n\n\nЕсли Вы не хотите сохранять результаты теста, нажмите кнопку \'Выход без сохранения\'. ";
                _contrastsform.Controls.Add(_endtestcontrol);   
                }
        }

        void btn_exit_Click(object sender, EventArgs e)
        {
            arg.Reason = "Выход";
            this.OnTestDone();
            End();
        }

        void btn_savedata_Click(object sender, EventArgs e)
        {
            ResultsToBase();
           arg.Reason = "Тест успешно пройден";
            this.OnTestDone();
            End();
        }

        public void End()
        {
            _contrastsform.Close();
        }

        public void ResultsToBase()
        {
           ContrastsAnswers Answers = _answers;

            XmlSerializer mySerializer = new XmlSerializer(typeof(ContrastsAnswers));

            StringWriter myWriter = new StringWriter();
            mySerializer.Serialize(myWriter, Answers);

            testresult t = testresult.Createtestresult(0, _humanid, DateTime.Now, (int)EnumPTests.Contrasts, myWriter.ToString(), "auto");
            _fe.testresults.AddObject(t);
            _fe.SaveChanges();

            myWriter.Close();
        }

        public testresult ResultsToBase(RecogCore.AnswerGrid.Answers Answers)
        {
            throw new Exception("Для этого теста не существует бланка");
        }
    }
}
