using System.Windows.Forms;

namespace Recog.Controls
{
    public partial class EndTestControl : UserControl
    {
        private string _abouttest;

        public string AboutTest
        {
            get
            {
                _abouttest = lb_caption.Text;
                return _abouttest;
            }
            set
            {
                _abouttest = value;
                lb_caption.Text = _abouttest;
            }
        }

        public EndTestControl()
        {
            InitializeComponent();
        }

        
    }
}
