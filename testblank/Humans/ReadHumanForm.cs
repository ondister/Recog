using System;
using System.Windows.Forms;
using Recog.Data;
namespace Recog.Humans
{
    public partial class ReadHumanForm : Form
    {
        private fBaseEntities _fe;
        private int _humanid;
        public ReadHumanForm(fBaseEntities fe, int HumanId)
        {
            InitializeComponent();
            _fe = fe;
            _humanid = HumanId;

            HelpProvider help = new HelpProvider();
            help.HelpNamespace = "Recog_help.chm";
            help.SetHelpNavigator(this, HelpNavigator.Topic);
            help.SetHelpKeyword(this, "result_common.htm#human_read");
        }

     
        private void AddHumanForm_Load(object sender, EventArgs e)
        {
            this.hc_humaninfo.ConnectToBase(_fe);
            this.hc_humaninfo.Id = _humanid;
        }
    }
}
