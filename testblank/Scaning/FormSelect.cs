using System.Collections.Generic;
using System.Windows.Forms;
using TwainDotNet.WinFroms;
namespace Recog.Scaning
{
    public partial class FormSelect : Form
    {
        private Scaner _selectedscaner;

        public Scaner SelectedScaner
        {
            get { return _selectedscaner; }
        }
        private List<Scaner> _devlist;

        public List<Scaner> Devlist
        {
            get { return _devlist; }
            set
            {
                _devlist = value;
                for (int i = 0; i < _devlist.Count; i++)
                {
                    ListViewItem item = new ListViewItem(_devlist[i].Name);
                    item.SubItems.Add(_devlist[i].Type.ToString());
                    lst_devices.Items.Add(item);
                }
                if (_devlist.Count != 0) {lst_devices.Items[0].Selected=true ;}
            }
        }
        public FormSelect()
        {
            InitializeComponent();

            HelpProvider help = new HelpProvider();
            help.HelpNamespace = "Recog_help.chm";
            help.SetHelpNavigator(this, HelpNavigator.Topic);
            help.SetHelpKeyword(this, "menu_settings.htm#scan_settings");
        }



        private void lst_devices_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lst_devices.SelectedItems.Count != 0)
            {
                Scaner s = new Scaner(lst_devices.SelectedItems[0].Text, Scaner.StringToScanerType(lst_devices.SelectedItems[0].SubItems[1].Text), new WinFormsWindowMessageHook(this));
                _selectedscaner = s;
            }
        }


    }
}
