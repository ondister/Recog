using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Recog.Data;
namespace Recog
{
    public partial class PoolDoneForm : Form
    {
        private fBaseEntities _fe;
        private int _humanid;
        public PoolDoneForm(fBaseEntities fe, int HumanID)
        {
            InitializeComponent();
            _fe = fe;
            _humanid = HumanID;
        }

        private void btn_done_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PoolDoneForm_Load(object sender, EventArgs e)
        {
            human h = _fe.humans.First(hh => hh.idh == _humanid);
            this.lb_name.Text = h.firstname + " " + h.lastname + "!";
        }
    }
}
