using System;
using System.Data.Objects;
using System.Linq;
using System.Windows.Forms;
using Recog.Data;
namespace Recog.Humans
{
    public partial class FormDep : Form
    {
        private fBaseEntities _fe;
        public FormDep(fBaseEntities fe)
        {
            InitializeComponent();
            _fe = fe;

            HelpProvider help = new HelpProvider();
            help.HelpNamespace = "Recog_help.chm";
            help.SetHelpNavigator(this, HelpNavigator.Topic);
            help.SetHelpKeyword(this, "menu_settings.htm#edit_deps");
        }

        private void LoadDepsInList()
        {
            
                var depsQuery = _fe.departments;
                this.dg_deps.DataSource = depsQuery.Execute(MergeOption.AppendOnly);
           
            //меняем интерфейс слегка
            this.dg_deps.Columns[1].DisplayIndex = 1;
            this.dg_deps.Columns[1].HeaderText = "СПИСОК ПОДРАЗДЕЛЕНИЙ";
            this.dg_deps.Columns[0].Visible = false;
            this.dg_deps.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_deps.MultiSelect = false;
        }

        private void FormDep_Load(object sender, EventArgs e)
        {
            this.LoadDepsInList();
        }

        private bool IsExist(string description)
        {
            bool ise = false;
          
                int dc = _fe.departments.Count(dp => dp.description.Trim() == description.Trim().ToUpper());
                if (dc != 0) { ise = true; }
           
            return ise;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (IsExist(this.txt_dep.Text) == false & this.txt_dep.Text.Trim() != "")
            {
                
                    department d = department.Createdepartment(0, this.txt_dep.Text.Trim().ToUpper());
                    _fe.departments.AddObject(d);
                    _fe.SaveChanges();
                    LoadDepsInList();
               
            }
            else { MessageBox.Show("Такое подразделение уже в базе"); }
        }

       

    }
}
