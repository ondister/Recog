using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Recog.Controls;
using System.Xml.Serialization;
using System.IO;
using Recog.Data;
namespace Recog.PTests.PNN
{
    public partial class TestPnnForm : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        public TestPnnForm()
        {
            InitializeComponent();
        }

        #region train
        private StartTestControl trainstartcontrol;
        private CycleControl traincyclecontrol;
        private const int _traintime = 60000;//время тренировки в милисекундах
        private Timer _traintimer;//таймер окончания тренировки
        private PNNTestLoader trainloader;
        private void TestPnn_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            trainstartcontrol = new StartTestControl();
            trainstartcontrol.AboutTest = "\nВнимательно прочитайте условия выполнения задания!!!\nПри загорании на экране красного круга необходимо быстро нажать и отпустить правый Ctrl правой рукой, при загорании зеленого круга - левый Ctrl левой рукой, при загорании желтого круга - не реагировать. Скорость предъявления сигналов будет зависеть от скорости и точности Ваших реакций. Она будет постепенно увеличиваться и наконец, достигнет предела, на котором Вы начнете допускать большое количество ошибок. Не обращайте внимания на ошибки, старайтесь как можно дольше удержать достигнутый максимальный темп предъявления сигналов. \n\nПосле тренировки, которая продлится ровно одну минуту, начнется 2 минутный тест. \n\n\nНажмите клавишу Enter когда будете готовы приступить... ";
            trainstartcontrol.btn_start.Click += new EventHandler(train_btn_start_Click);
            trainstartcontrol.Location = new Point(0, 27);
            trainstartcontrol.Dock = DockStyle.Fill;
            trainstartcontrol.btn_start.TabIndex = 0;
            trainstartcontrol.btn_start.Text = "Приступить к тренировке";
            this.Controls.Add(trainstartcontrol);
           
            endtestcontrol = new EndTestControl();
            endtestcontrol.AboutTest = "\nСпасибо, что прошли тест. Теперь подтвердите достоверность Ваших результатов и добровольность тестирования, нажав кнопку \' Сохранить результаты\'. \n\n\nЕсли Вы не хотите сохранять результаты теста, нажмите кнопку \'Выход без сохранения\'. ";
            endtestcontrol.Location = new Point(0, 27);
            endtestcontrol.Dock = DockStyle.Fill;
            endtestcontrol.btn_savedata.TabIndex = 0;

            this.Controls.Add(endtestcontrol);
            endtestcontrol.Visible = false;

            
            this.trainstartcontrol.btn_start.Focus();

        }

        void train_btn_start_Click(object sender, EventArgs e)
        {
            trainstartcontrol.Dispose();
            traincyclecontrol = new CycleControl();
            traincyclecontrol.Location = new Point(0, 27);
            traincyclecontrol.Dock = DockStyle.Fill;
            traincyclecontrol.KeyUp += new KeyEventHandler(traincyclecontrol_KeyUp);
            traincyclecontrol.KeyDown += new KeyEventHandler(traincyclecontrol_KeyDown);
            this.Controls.Add(traincyclecontrol);
            this.traincyclecontrol.Focus();
            //запускаем таймер
            _traintimer = new Timer();
            _traintimer.Interval = _traintime;
            _traintimer.Tick += new EventHandler(_traintimer_Tick);
            _traintimer.Start();
            trainloader = new PNNTestLoader(900, traincyclecontrol);
            trainloader.Start();
        }

        void traincyclecontrol_KeyDown(object sender, KeyEventArgs e)
        {

            if (this.traincyclecontrol.CurrentSignalType != PnnSignalType.None)
            {
                if (e.KeyCode == Keys.ControlKey)
                {
                    if (Convert.ToBoolean(GetAsyncKeyState(Keys.LControlKey)))
                    {
                        trainloader.SetKey(PnnKeyType.LeftControl, DateTime.Now);
                    }
                    if (Convert.ToBoolean(GetAsyncKeyState(Keys.RControlKey)))
                    {
                        trainloader.SetKey(PnnKeyType.RightControl, DateTime.Now);
                    }
                }
                else if (e.KeyCode == Keys.Space) { }
                else if (e.KeyCode == Keys.Enter) { }
                else
                {
                    trainloader.SetKey(PnnKeyType.AnyKey, DateTime.Now);
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                trainloader.Stop();
                Cursor.Show();
                this.Close();
            }
        }


        void traincyclecontrol_KeyUp(object sender, KeyEventArgs e)
        {
            
        }


        void _traintimer_Tick(object sender, EventArgs e)
        {
            trainloader.Stop();
            _traintimer.Stop();
            traincyclecontrol.Dispose();
            starttestcontrol = new StartTestControl();
            starttestcontrol.AboutTest = "\nЭто была тренировка. Теперь сам тест \n\n\nНажмите клавишу Enter когда будете готовы приступить... ";
            starttestcontrol.btn_start.Click += new EventHandler(test_btn_start_Click);
            starttestcontrol.Location = new Point(0, 27);
            starttestcontrol.Dock = DockStyle.Fill;
            starttestcontrol.btn_start.TabIndex = 0;
            starttestcontrol.btn_start.Text = "Приступить к тестированию";
            this.Controls.Add(starttestcontrol);
            this.starttestcontrol.btn_start.Focus();

        }









        #endregion

        #region test

        private StartTestControl starttestcontrol;
        public EndTestControl endtestcontrol;
        private CycleControl testcyclecontrol;

        private const int _testtime =120000;//время теста в миллисекндах

        private Timer _testtimer;//таймер окончания теста
        public PNNTestLoader testloader;

        void test_btn_start_Click(object sender, EventArgs e)
        {
            starttestcontrol.Dispose();
            testcyclecontrol = new CycleControl();
            testcyclecontrol.Location = new Point(0, 27);
            testcyclecontrol.Dock = DockStyle.Fill;
            testcyclecontrol.KeyUp += new KeyEventHandler(testcyclecontrol_KeyUp);
            testcyclecontrol.KeyDown += new KeyEventHandler(testcyclecontrol_KeyDown);
            this.Controls.Add(testcyclecontrol);
            this.testcyclecontrol.Focus();
            //запускаем таймер
            _testtimer = new Timer();
            _testtimer.Interval = _testtime;
            _testtimer.Tick += new EventHandler(_testtimer_Tick);
            _testtimer.Start();
            testloader = new PNNTestLoader(900, testcyclecontrol);
            testloader.Start();
        }

        void _testtimer_Tick(object sender, EventArgs e)
        {
            
            _testtimer.Stop();
            Cursor.Show();
            testcyclecontrol.Dispose();
            endtestcontrol.Visible = true;
            this.endtestcontrol.btn_savedata.Focus();
        }

       

        void testcyclecontrol_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.testcyclecontrol.CurrentSignalType != PnnSignalType.None)
            {
                if (e.KeyCode == Keys.ControlKey)
                {
                    if (Convert.ToBoolean(GetAsyncKeyState(Keys.LControlKey)))
                    {
                        testloader.SetKey(PnnKeyType.LeftControl, DateTime.Now);
                    }
                    if (Convert.ToBoolean(GetAsyncKeyState(Keys.RControlKey)))
                    {
                        testloader.SetKey(PnnKeyType.RightControl, DateTime.Now);
                    }
                }
                else if (e.KeyCode == Keys.Space) { }
                else if (e.KeyCode == Keys.Enter) { }
                else
                {
                    testloader.SetKey(PnnKeyType.AnyKey, DateTime.Now);
                }
            }


            if (e.KeyCode == Keys.Escape)
            {
                testloader.Stop();
                Cursor.Show();
                this.Close();
            }
        }

        void testcyclecontrol_KeyUp(object sender, KeyEventArgs e)
        {
            
        }


        #endregion




    }
}
