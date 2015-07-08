using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Recog
{
    public partial class PassBox : Form
    {
        public string Description { get { return tb_desc.Text; } }
        public PassBox()
        {
            InitializeComponent();
        }

       
    }
}
