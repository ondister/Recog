using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Recog.PTests;
namespace Recog.Controls
{
    public partial class ScaleControl : UserControl
    {
        private IScale _scale;
       

        public bool IsActive
        {
            get
            {
                if ((int)nud_stens.Value == -1 & (int)this.nud_marks.Value == -1)
                {
                    return false;
                }
                else { return true; }
            }
        }

        public IScale ControlScale
        {
            get { return _scale; }
            set { 
                _scale = value;
                if (_scale != null) { this.tb_name.Text = _scale.Name; }
            }
        }
        public ScaleControl()
        {
            InitializeComponent();
            _scale = null;
            
        }

      

        private void nud_stens_ValueChanged(object sender, EventArgs e)
        {
            if ((int)nud_stens.Value != -1)
            {
                _scale.Stens = (int)nud_stens.Value;
                _scale.GetLevel();
                _scale.GetResult();
                nud_stens.BackColor = Color.ForestGreen;
            }
            else 
            {
                this.nud_marks.Value = -1;
                nud_stens.BackColor = Color.RosyBrown;
            }
        }

        private void nud_marks_ValueChanged(object sender, EventArgs e)
        {
           if ((int)this.nud_marks.Value!=-1) 
            {
                _scale.Mark = (double)this.nud_marks.Value;
            _scale.GetSten();
            this.nud_stens.Value=_scale.Stens;
            _scale.GetLevel();
            _scale.GetResult();
            nud_marks.BackColor = Color.ForestGreen;
            }
            else
            {
                nud_stens.Value = -1;
                nud_marks.BackColor = Color.RosyBrown;
            }
        }
    }
}
