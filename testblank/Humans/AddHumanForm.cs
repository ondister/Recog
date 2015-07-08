using System;
using System.Windows.Forms;
using Recog.Data;
namespace Recog.Humans
{
    public partial class AddHumanForm : Form
    {
        private fBaseEntities _fe;
        public AddHumanForm(fBaseEntities fe)
        {
            InitializeComponent();
            _fe = fe;

            HelpProvider help = new HelpProvider();
            help.HelpNamespace = "Recog_help.chm";
            help.SetHelpNavigator(this, HelpNavigator.Topic);
            help.SetHelpKeyword(this, "respondent_common.htm#human_add");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.hc_humaninfo.AddHuman();
            this.Close();
        }

        private void AddHumanForm_Load(object sender, EventArgs e)
        {
            this.hc_humaninfo.ConnectToBase(_fe);
        }
    }
}
