using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data; 
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;
using Recog.Data;

namespace Recog.Data
{
   

    public partial class ExportForm : Form
    {
        private fBaseEntities _fe;
        private pBaseEntities _ge;
        private BackupTool _backuptool;

        public ExportForm(fBaseEntities fe, pBaseEntities ge)
        {
            InitializeComponent();
            _fe = fe;
            _ge = ge;
            _backuptool = new BackupTool(_fe);
            _backuptool.HumanDone += new EventHandler(_backuptool_HumanDone);
            chb_fam.Click += new EventHandler(chb_fam_Click);
          
            chb_tests.Click += new EventHandler(chb_fam_Click);

            cb_fam.SelectedValueChanged += new EventHandler(cb_fam_SelectedValueChanged);
            cb_tests.SelectedValueChanged += new EventHandler(cb_fam_SelectedValueChanged);

            dp_begdate.ValueChanged += new EventHandler(cb_fam_SelectedValueChanged);
            dp_enddate.ValueChanged += new EventHandler(cb_fam_SelectedValueChanged);

            SetGridStyle();

            HelpProvider help = new HelpProvider();
            help.HelpNamespace = "Recog_help.chm";
            help.SetHelpNavigator(this, HelpNavigator.Topic);
            help.SetHelpKeyword(this, "menu_settings.htm#export_resp");
        }

        void cb_fam_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadHumans();
        }

        private void  SetGridStyle()
        {
         //addcolumns
            DataGridViewTextBoxColumn idcolumn = new DataGridViewTextBoxColumn();
            idcolumn.HeaderText = "idh";
            idcolumn.Width = 0;
            idcolumn.Visible = false;
            this.dg_humans.Columns.Add(idcolumn);

            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.Name = "check";
            column.HeaderText = "Выбор";
            column.Width = 50;
            column.DisplayIndex = 0;
            this.dg_humans.Columns.Add(column);

            DataGridViewTextBoxColumn tstcolumn = new DataGridViewTextBoxColumn();
            tstcolumn.HeaderText = "Тест";
            tstcolumn.Width = 120;
            this.dg_humans.Columns.Add(tstcolumn);

            DataGridViewTextBoxColumn tdcolumn = new DataGridViewTextBoxColumn();
            tdcolumn.HeaderText = "Дата проведения";
            tdcolumn.Width = 120;
            this.dg_humans.Columns.Add(tdcolumn);

            DataGridViewTextBoxColumn famcolumn = new DataGridViewTextBoxColumn();
            famcolumn.HeaderText = "Фамилия";
            famcolumn.Width = 120;
            this.dg_humans.Columns.Add(famcolumn);

            DataGridViewTextBoxColumn imcolumn = new DataGridViewTextBoxColumn();
            imcolumn.HeaderText = "Имя";
            imcolumn.Width = 120;
            this.dg_humans.Columns.Add(imcolumn);

            DataGridViewTextBoxColumn drcolumn = new DataGridViewTextBoxColumn();
            drcolumn.HeaderText = "Дата рождения";
            drcolumn.Width = 120;
            this.dg_humans.Columns.Add(drcolumn);

           

            this.dg_humans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dg_humans.MultiSelect = true;
        }
     
        private void LoadHumans()
        {
            dg_humans.Rows.Clear();
            if (dg_humans.Columns.Count == 0) { SetGridStyle(); }
            SearchParam p = new SearchParam(this.cb_fam, this.cb_tests, this.dp_begdate, this.dp_enddate);
            var testresultsQuery = _fe.testresults.Where(p.Predicate, p.Parameters);
            foreach (testresult tst in testresultsQuery)
            {
                human _human = _fe.humans.First(h=>h.idh==tst.idh);
                testsparam _test= _ge.testsparams.First(t=>t.idt==tst.testid);
               dg_humans.Rows.Add(tst.idh,  true,_test.description,tst.testdate,_human.secondname,_human.firstname,_human.birthday);
                
            }
           
        }

      

        private void btn_setdir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dirdialog = new FolderBrowserDialog();
            dirdialog.Description = "Укажите папку, в которую необходимо осуществить экспорт";
            if (dirdialog.ShowDialog() == DialogResult.OK)
            {
                _backuptool.SetSavePath(dirdialog.SelectedPath);
                txt_dirpath.Text = _backuptool.SavePath.FullName;
                //begin
                this.EnabledControls();
                 this.LoadHumans();
                this.FindDateRange();

            } 
        }

        private void EnabledControls()
        {
            chb_fam.Enabled = true;
            chb_tests.Enabled = true;
            dp_begdate.Enabled = true;
            dp_enddate.Enabled = true;

            dg_humans.Enabled = true;

            btn_selectall.Enabled = true;
            btn_unselectall.Enabled = true;
            btn_startexport.Enabled = true;

            pb_progress.Enabled = true;
            btn_setdir.Enabled = false;
        }
       

        private void btn_selectall_Click(object sender, EventArgs e)
        {
            this.SelectAll();
        }

        private void SelectAll()
        {
            for (int rowindex = 0; rowindex < dg_humans.Rows.Count; rowindex++)
            {
                dg_humans.Rows[rowindex].Cells["check"].Value = true;
            }
        }
        private void btn_unselectall_Click(object sender, EventArgs e)
        {
            for (int rowindex = 0; rowindex < dg_humans.Rows.Count; rowindex++)
            {
                dg_humans.Rows[rowindex].Cells["check"].Value = false;
            }
        }

        private void btn_startexport_Click(object sender, EventArgs e)
        {
            List<human> _humans = new List<human>();
            for (int rowindex = 0; rowindex < dg_humans.Rows.Count; rowindex++)
            {
                if ((bool)dg_humans.Rows[rowindex].Cells["check"].Value == true)
                {
                    int idh = Convert.ToInt32(dg_humans.Rows[rowindex].Cells[0].Value);
                    human _human = _fe.humans.FirstOrDefault(h => h.idh == idh);
                    if (_human != null & _humans.Exists(h=>h.idh==_human.idh)==false) { _humans.Add(_human); }
                }
            }
            pb_progress.Value = 1;
            pb_progress.Minimum = 1;
            pb_progress.Step = 1;
            pb_progress.Maximum = _humans.Count;
            _backuptool.Save(_humans);

            MessageBox.Show("Экспорт завершен");
        }

       
        void _backuptool_HumanDone(object sender, EventArgs e)
        {

            pb_progress.PerformStep();
            
        }

        private void FindDateRange()
        {
            DateTime begdate = _fe.testresults.Min(tr => tr.testdate);
            DateTime enddate = _fe.testresults.Max(tr => tr.testdate);
            this.dp_begdate.Value = begdate;
            this.dp_enddate.Value = enddate;
        }
     
        private void SetParamsEnabled()
        {
            this.cb_fam.Enabled = this.chb_fam.Checked;
            this.cb_tests.Enabled = this.chb_tests.Checked;
        }

        private void ExportForm_Load(object sender, EventArgs e)
        {
            SetParamsEnabled();
            FillTheComboes();
        }

        void chb_fam_Click(object sender, EventArgs e)
        {
            SetParamsEnabled();
            LoadHumans();
        }

        private void FillTheComboes()
        {

            var tests = _ge.testsparams.OrderBy(t => t.description);
            this.cb_tests.DataSource = tests;
            this.cb_tests.DisplayMember = "description";
            this.cb_tests.ValueMember = "idt";

            var humans = _fe.humans.OrderBy(h => h.secondname) ;
            this.cb_fam.DataSource = humans;
            this.cb_fam.DisplayMember = "secondname";
            this.cb_fam.ValueMember = "idh";
        }

       


        
               
         



        }
    }

