using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Recog.Data;

namespace Recog.PTests.FPI
{
    public partial class TestFPIForm : Form
    {
         [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);
        public FPITestLoader ktl;
        private pBaseEntities _ge;
        public TestFPIForm(pBaseEntities Globalentities)
        {
            InitializeComponent();
            _ge = Globalentities;
        }

       
        void btn_start_Click(object sender, EventArgs e)
        {

            this.SuspendLayout();
            this.stc_start.Visible = false;
            this.atc_gone.Location = new Point(0, 27);
            this.atc_gone.Dock = DockStyle.Fill;
            this.atc_gone.Visible = true;
            this.atc_gone.Focus();
            this.atc_gone.KeyUp += new KeyEventHandler(atc_gone_KeyUp);
            ktl = new FPITestLoader(_ge, this.atc_gone);
            ktl.TestDone += new EventHandler(atl_TestDone);
            ktl.Start(); 
            this.ResumeLayout();
        }

        void atl_TestDone(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.atc_gone.Visible = false;
            this.etc_end.Location = new Point(0, 27);
            this.etc_end.Dock = DockStyle.Fill;
            this.etc_end.Visible = true;
            this.etc_end.Focus();
            this.etc_end.btn_savedata.Focus();
            this.etc_end.AboutTest = "Ура вы закончили этот замечательный тестик";
            this.ResumeLayout();
            Cursor.Show();
        }

      
        void atc_gone_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1) { ktl.SendKey(1); ktl.Next(); }
            if (e.KeyCode == Keys.D2) { ktl.SendKey(0); ktl.Next(); }
           
            if (e.KeyCode == Keys.NumPad1) { ktl.SendKey(1); ktl.Next(); }
            if (e.KeyCode == Keys.NumPad2) { ktl.SendKey(0); ktl.Next(); }
           

            if (e.KeyCode == Keys.Escape)
            {
               // trainloader.Stop();
                Cursor.Show();
                this.Close();
            }
        }

        private void TestAdaptabilityForm_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            this.atc_gone.Visible = false;
            this.etc_end.Visible = false;
            this.stc_start.AboutTest = "\nВам будет представлен ряд утверждений, каждое из которых подразумевает относящийся к вам вопрос о том, соответствует или не соответствует данное утверждение каким-то особенностям вашего поведения, отдельных поступков, отношения к людям, взглядам на жизнь и т.п. \n\nЕсли Вы считаете, что такое соответствие имеет место, то дайте ответ «Да», нажав клавишу 1, в противном случае – ответ «Нет», нажав клавишу 2. \n\nОтветы необходимо дать на все вопросы.\nУспешность исследования во многом зависит от того, насколько внимательно выполняется задание. Ни в коем случае не следует стремиться своими ответами произвести на кого-то лучшее впечатление, так как ни один ответ не оценивается как хороший или плохой. Вы не должны долго размышлять над каждым вопросом, а старайтесь как можно быстрее решить, какой из двух ответов, пусть весьма относительно, но все-таки кажется вам ближе к истине.\n Вас не должно смущать, если некоторые из вопросов покажутся слишком личными, поскольку исследование не предусматривает анализа каждого вопроса и ответа, а опирается лишь на количество ответов одного и другого вида. Кроме того, вы должны знать, что результаты индивидуально-психологических исследований, как и медицинских, не подлежат широкому обсуждению.";
            this.stc_start.btn_start.Click += new EventHandler(btn_start_Click);
            this.stc_start.Location = new Point(0, 27);
            this.stc_start.Dock = DockStyle.Fill;
            this.stc_start.btn_start.TabIndex = 0;
            this.stc_start.btn_start.Text = "Приступить к тестированию";
        }
    }
}
