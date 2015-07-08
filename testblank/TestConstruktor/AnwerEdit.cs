using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Recog.Data;
namespace Recog.TestConstruktor
{
    public partial class AnwerEdit : Form
    {
      
        public string Description;
        public int InterCellWidth;
        public int CellWidth;
        public int CellHight;
       
        public int IDA;
        public int fx;
        public int fy;
        public AnwerEdit()
        {
            InitializeComponent();
        }

        private void AnwerEdit_Load(object sender, EventArgs e)
        {

            this.Text = Description;
            this.tb_desc.Text = Description;
            this.nu_intercells.Value = InterCellWidth;
            this.nu_width.Value = CellWidth;
            this.nu_hight.Value = CellHight;
          
            Point p = new Point(fx, fy);
            this.DesktopLocation = p;

        }

        private void cmd_editans_Click(object sender, EventArgs e)
        {
            pBaseEntities pb = new pBaseEntities();
            IEnumerable<answersparam> answers = pb.answersparams.Where(a => a.ida == this.IDA);
            foreach (answersparam ap in answers)
            {
                ap.description = this.tb_desc.Text;
                ap.cellswidth = (int)this.nu_width.Value;
                ap.cellshight = (int)this.nu_hight.Value;
                ap.intercellswidth = (int)this.nu_intercells.Value;
              
            }
            pb.SaveChanges();
            this.Close();
        }
    }
}
