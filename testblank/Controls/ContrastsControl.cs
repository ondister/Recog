using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Recog.PTests.Contrasts;

namespace Recog.Controls
{
    public partial class ContrastsControl : UserControl
    {
        public event EventHandler CycleClick;
        private CycleClickArgs arg;
        private void OnCycleClick() { if (CycleClick != null) { CycleClick(this, arg); } }

        public ContrastsControl()
        {
            InitializeComponent();
            arg = new CycleClickArgs();
        }
        public void LoadColors()
        {
        pictureBox1.Image=    new Bitmap(ApplicationInfo.GetDirectory() + @"\Images\Contrasts\1.png");
        pictureBox2.Image = new Bitmap(ApplicationInfo.GetDirectory() + @"\Images\Contrasts\2.png");
        pictureBox3.Image = new Bitmap(ApplicationInfo.GetDirectory() + @"\Images\Contrasts\3.png");
        pictureBox4.Image = new Bitmap(ApplicationInfo.GetDirectory() + @"\Images\Contrasts\4.png");
        pictureBox5.Image = new Bitmap(ApplicationInfo.GetDirectory() + @"\Images\Contrasts\5.png");
        pictureBox10.Image = new Bitmap(ApplicationInfo.GetDirectory() + @"\Images\Contrasts\6.png");
        pictureBox9.Image = new Bitmap(ApplicationInfo.GetDirectory() + @"\Images\Contrasts\7.png");
        pictureBox8.Image = new Bitmap(ApplicationInfo.GetDirectory() + @"\Images\Contrasts\8.png");
        pictureBox7.Image = new Bitmap(ApplicationInfo.GetDirectory() + @"\Images\Contrasts\9.png");
        pictureBox6.Image = new Bitmap(ApplicationInfo.GetDirectory() + @"\Images\Contrasts\10.png");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ClickDone(1, sender);
            this.pictureBox1.Click -= new System.EventHandler(this.pictureBox1_Click);
        }

        private void ClickDone(int controlId, object control)
        {
            PictureBox picture = (PictureBox)control;
            picture.Image = new Bitmap(250,250);
            arg.Id = controlId;
            this.OnCycleClick();
          
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ClickDone(2, sender);
            this.pictureBox2.Click -= new System.EventHandler(this.pictureBox2_Click);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ClickDone(3, sender);
            this.pictureBox3.Click -= new System.EventHandler(this.pictureBox3_Click);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ClickDone(4, sender);
            this.pictureBox4.Click -= new System.EventHandler(this.pictureBox4_Click);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ClickDone(5, sender);
            this.pictureBox5.Click -= new System.EventHandler(this.pictureBox5_Click);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ClickDone(6, sender);
            this.pictureBox6.Click -= new System.EventHandler(this.pictureBox6_Click);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            ClickDone(7, sender);
            this.pictureBox7.Click -= new System.EventHandler(this.pictureBox7_Click);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ClickDone(8, sender);
            this.pictureBox8.Click -= new System.EventHandler(this.pictureBox8_Click);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ClickDone(9, sender);
            this.pictureBox9.Click -= new System.EventHandler(this.pictureBox9_Click);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            ClickDone(10, sender);
            this.pictureBox10.Click -= new System.EventHandler(this.pictureBox10_Click);
        }
    }
}
