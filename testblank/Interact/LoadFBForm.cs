using System;
using System.Windows.Forms;
using Recog.Data;
using Recog.PTests;

namespace Recog.Interact
{

    public partial class LoadFBForm : Form
    {
        private pBaseEntities _ge;
        private fBaseEntities _fe;
        private EnumPTests _test;
        private ExcelReport _exreport;
        public LoadFBForm(pBaseEntities ge, fBaseEntities fe)
        {
            InitializeComponent();
            _ge = ge;
            _fe = fe;
            dp_maxdate.ValueChanged += new EventHandler(dp_maxdate_ValueChanged);
            dp_mindate.ValueChanged += new EventHandler(dp_maxdate_ValueChanged);

            HelpProvider help = new HelpProvider();
            help.HelpNamespace = "Recog_help.chm";
            help.SetHelpNavigator(this, HelpNavigator.Topic);
            help.SetHelpKeyword(this, "menu_excel.htm");
        }

        void dp_maxdate_ValueChanged(object sender, EventArgs e)
        {
            lb_tstcnt.Text = "Число тестов: "+_exreport.FindTestsCount(this.dp_mindate.Value, this.dp_maxdate.Value).ToString();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            tbn_cancel.Enabled = true;
            if (lst_manual.SelectedItems.Count == 1)
            {
                EnumPTests test = (EnumPTests)int.Parse(lst_manual.SelectedItems[0].SubItems[0].Text);
                
               _exreport = new ExcelReport(_ge, _fe, test);
               this.pb_progress.Minimum = 0;
               this.pb_progress.Value = 0;
               this.pb_progress.Maximum = _exreport.FindTestsCount();
               this.pb_progress.Step = 1; 
               _exreport.Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(Worker_ProgressChanged);
              _exreport.Create(this.dp_mindate.Value, this.dp_maxdate.Value);
            }
        }

        

        void Worker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            this.pb_progress.PerformStep();
        }


     
        private void LoadFBForm_Load(object sender, EventArgs e)
        {

            var query = _ge.testsparams;
         
            foreach (testsparam t in query)
            {
                ListViewItem item = new ListViewItem(t.idt.ToString());
                item.SubItems.Add(t.description);
                lst_manual.Items.Add(item);
                this.lst_manual.Columns[1].Width = this.lst_manual.Width;
            }

        }

        private void lst_manual_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_manual.SelectedItems.Count == 1)
            {
               _test = (EnumPTests)int.Parse(lst_manual.SelectedItems[0].SubItems[0].Text);
               _exreport = new ExcelReport(_ge, _fe, _test);

               if (_exreport.FindTestsCount() != 0)
               {
                   this.dp_mindate.Value = _exreport.FindMinDate();
                   this.dp_maxdate.Value = _exreport.FindMaxDate();
                   this.EnabledButtons(true);
               }
               else 
               {
                   this.dp_mindate.Value = this.dp_mindate.MinDate;
                   this.dp_maxdate.Value = this.dp_maxdate.MaxDate;
                   this.EnabledButtons(false);
               }

            }
        }

        private void tbn_cancel_Click(object sender, EventArgs e)
        {
            tbn_cancel.Enabled = false;
            _exreport.Worker.CancelAsync();

        }

        private void EnabledButtons(bool isenable)
        {
            dp_maxdate.Enabled = isenable;
            dp_mindate.Enabled = isenable;
            btn_load.Enabled = isenable;
        }

    }
}
