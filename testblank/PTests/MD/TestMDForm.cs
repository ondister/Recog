using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Recog.Data;

namespace Recog.PTests.MD
{
    public partial class TestMDForm : Form
    {
         [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);
         public MDTestLoader ktl;
        private pBaseEntities _ge;
        public TestMDForm(pBaseEntities Globalentities)
        {
            InitializeComponent();
            _ge = Globalentities;
        }

       
        void btn_start_Click(object sender, EventArgs e)
        {

            this.atc_gone.SuspendLayout();
            this.stc_start.Visible = false;
            this.atc_gone.Location = new Point(0, 27);
            this.atc_gone.Dock = DockStyle.Fill;
            this.atc_gone.Visible = true;
            this.atc_gone.Focus();
            this.atc_gone.KeyUp += new KeyEventHandler(atc_gone_KeyUp);
            ktl = new MDTestLoader(_ge, this.atc_gone);
            ktl.TestDone += new EventHandler(atl_TestDone);
            ktl.Start();
            this.atc_gone.ResumeLayout();
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
            this.stc_start.Visible = true;
            this.stc_start.AboutTest = "\nСейчас Вам будет предложен ряд вопросов, на которые Вы должны ответить только «да» ( клавишей 1) или «нет» ( клавишей 2).\nВопросы касаются Вашего самочувствия, поведения или характера. «Правильных» или «неправильных» ответов здесь быть не может, поэтому не старайтесь долго их обдумывать – отвечайте исходя из того, что больше соответствует Вашему состоянию или представлению о самом себе».";
            this.stc_start.btn_start.Click += new EventHandler(btn_start_Click);
            this.stc_start.Location = new Point(0, 27);
            this.stc_start.Dock = DockStyle.Fill;
            this.stc_start.btn_start.TabIndex = 0;
            this.stc_start.btn_start.Text = "Приступить к тестированию";
        }
    }
}
