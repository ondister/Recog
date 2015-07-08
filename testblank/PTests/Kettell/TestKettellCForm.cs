using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Recog.Data;

namespace Recog.PTests.Kettell
{
    public partial class TestKettellCForm : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);
        public KettellCTestLoader ktl;
        private pBaseEntities _ge;
        public TestKettellCForm(pBaseEntities Globalentities)
        {
            InitializeComponent();
            _ge = Globalentities;
        }

        private void TestKettellForm_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            this.ktc_gone.Visible = false;
            this.etc_end.Visible = false;
            this.stc_start.AboutTest = "\nВнимательно прочитайте условия выполнения задания!!!\nНажимайте клавиши 1 2 или 3 в зависимости от вашего ответа";
            this.stc_start.btn_start.Click += new EventHandler(btn_start_Click);
            this.stc_start.Location = new Point(0, 27);
            this.stc_start.Dock = DockStyle.Fill;
            this.stc_start.btn_start.TabIndex = 0;
            this.stc_start.btn_start.Text = "Приступить к тестированию";
        }

        void btn_start_Click(object sender, EventArgs e)
        {


            this.stc_start.Visible = false;
            this.ktc_gone.Location = new Point(0, 27);
            this.ktc_gone.Dock = DockStyle.Fill;
            this.ktc_gone.Visible = true;
            this.ktc_gone.Focus();
            this.ktc_gone.KeyUp += new KeyEventHandler(ktc_gone_KeyUp);
            ktl = new KettellCTestLoader(_ge, this.ktc_gone);
            ktl.TestDone += new EventHandler(ktl_TestDone);
            ktl.Start(); this.Invalidate();
        }

        void ktl_TestDone(object sender, EventArgs e)
        {
            this.ktc_gone.Visible = false;
            this.etc_end.Location = new Point(0, 27);
            this.etc_end.Dock = DockStyle.Fill;
            this.etc_end.Visible = true;
            this.etc_end.Focus();
            this.etc_end.btn_savedata.Focus();
            this.etc_end.AboutTest = "Ура вы закончили этот замечательный тестик";
            Cursor.Show();
        }

      
        void ktc_gone_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1) { ktl.SendKey(0); ktl.Next(); }
            if (e.KeyCode == Keys.D2) { ktl.SendKey(1); ktl.Next(); }
            if (e.KeyCode == Keys.D3) { ktl.SendKey(2); ktl.Next(); }
            if (e.KeyCode == Keys.NumPad1) { ktl.SendKey(0); ktl.Next(); }
            if (e.KeyCode == Keys.NumPad2) { ktl.SendKey(1); ktl.Next(); }
            if (e.KeyCode == Keys.NumPad3) { ktl.SendKey(2); ktl.Next(); }

            if (e.KeyCode == Keys.Escape)
            {
               // trainloader.Stop();
                Cursor.Show();
                this.Close();
            }
        }
    }
}
