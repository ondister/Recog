using System;
using System.Data.Objects;
using System.Windows.Forms;
using Recog.Data;

namespace Recog.Humans
{
    public partial class HumansForm : Form
    {
         public fBaseEntities _fe;//сущности быстрого для поиска
         private int _currenthumanid;//текущий индекс сущности

         public int CurrentHumanID
         {
             get { return _currenthumanid; }
             set { _currenthumanid = value; }
         }
         private AddHumanForm _addform;

         public HumansForm(fBaseEntities fe)
        {
            InitializeComponent();
            _fe=fe;

            HelpProvider help = new HelpProvider();
            help.HelpNamespace = "Recog_help.chm";
            help.SetHelpNavigator(this, HelpNavigator.Topic);
            help.SetHelpKeyword(this, "respondent_common.htm#human");
        }
       

        private void HumansForm_Load(object sender, EventArgs e)
        {
            this.hc_human.ConnectToBase(_fe);
            if (Properties.Settings.Default.AllowViews == true)
            { LoadHumansInList(this.tb_search.Text); }
            else
            { 
                tb_search.Enabled = false;
                btn_del.Enabled = false;
                btn_edit.Enabled = false;
            }
        }

        private void LoadHumansInList(string txtsearch)
        {

            var humanQuery = _fe.humans.Where("it.secondname LIKE @sname+'%'", new ObjectParameter("sname", txtsearch.ToUpper()));
                this.dg_humans.DataSource = humanQuery.Execute(MergeOption.AppendOnly);

            //меняем интерфейс слегка
               this.dg_humans.Columns[2].DisplayIndex = 1;
                this.dg_humans.Columns[2].HeaderText = "ФАМИЛИЯ";
                this.dg_humans.Columns[1].DisplayIndex = 2;
                this.dg_humans.Columns[1].HeaderText = "ИМЯ";
                this.dg_humans.Columns[3].DisplayIndex = 3;
                this.dg_humans.Columns[3].HeaderText = "ОТЧЕСТВО";
                this.dg_humans.Columns[8].DisplayIndex = 4;
                this.dg_humans.Columns[8].HeaderText = "ДАТА РОЖДЕНИЯ";

                this.dg_humans.Columns[0].Visible = false;
                this.dg_humans.Columns[4].Visible = false;
                this.dg_humans.Columns[5].Visible = false;
                this.dg_humans.Columns[6].Visible = false;
                this.dg_humans.Columns[7].Visible = false;
                this.dg_humans.Columns[9].Visible = false;
                this.dg_humans.Columns[10].Visible = false;
                this.dg_humans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dg_humans.MultiSelect = false;
                if (this.dg_humans.Rows.Count == 0) { 
                    this.hc_human.Id = 0;
                    _currenthumanid = 0;
                }
        }
        

     

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            this.LoadHumansInList(this.tb_search.Text);
        }

        private void dg_humans_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dg = this.dg_humans;
            _currenthumanid =(int) dg.Rows[e.RowIndex].Cells[0].Value;
            this.hc_human.Id = _currenthumanid;

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
             _addform= new AddHumanForm(_fe);
                   _addform.Show();
            _addform.FormClosed += new FormClosedEventHandler(_addform_FormClosed);
        }

        void _addform_FormClosed(object sender, FormClosedEventArgs e)
        {
            AddHumanForm frm = (AddHumanForm)sender;
            this.tb_search.Text = frm.hc_humaninfo.SecondName;
            this.hc_human.RefreshDeps();
            this.LoadHumansInList(this.tb_search.Text); 
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            this.hc_human.EditHuman();
            this.tb_search.Text = this.hc_human.SecondName;
            this.LoadHumansInList(this.tb_search.Text); 
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            this.hc_human.DeleteHuman();
            this.LoadHumansInList(this.tb_search.Text); 
        }

        private void btn_begin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            _currenthumanid = 0; 
        }

       
       
       

      
    }
}
