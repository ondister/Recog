using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Recog.BlankRecognition;
using Recog.Data;
using Recog.Forms;
using Recog.Humans;
using Recog.Interact;
using Recog.PTests;
using Recog.PTests.ResultReader;
using Recog.Scaning;
using Recog.TestConstruktor;
namespace Recog
{
    public partial class MainMenu : Form
    {
        public pBaseEntities pGlobalEntities;
        public fBaseEntities fGlobalEntities;
        public MainMenu()
        {
            InitializeComponent();
            HelpProvider help = new HelpProvider();
            help.HelpNamespace = "Recog_help.chm";
            help.SetHelpNavigator(this, HelpNavigator.Topic);
            help.SetHelpKeyword(this, "main_menu.htm");
        }

        private void menu_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        void tlk_TestsPoolDone(object sender, EventArgs e)
        {
            TestLoader tl = (TestLoader)sender;
            PoolDoneForm pd = new PoolDoneForm(fGlobalEntities, tl.HumanID);
            pd.ShowDialog();
        }

        
       

        private void menu_results_Click(object sender, EventArgs e)
        {
           ResultForm rf = new ResultForm(pGlobalEntities,fGlobalEntities);
            rf.WindowState = FormWindowState.Maximized;
            rf.ShowDialog();
        }

        

        private void sm_about_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            //TestAdd ab = new TestAdd();
            ab.ShowDialog();

            //DualForm fc = new DualForm();
            //List<string> d = new List<string>() { "да", "нет" };
            //fc.Create("tmp.pdf", 88, 2, d, 15);



        }

       
        
        private void submenu_scanerchange_Click(object sender, EventArgs e)
        {
            ScanerManager sm = new ScanerManager(pGlobalEntities, new TwainDotNet.WinFroms.WinFormsWindowMessageHook(this));
            sm.SelectDevice();
        }

        private void submenu_editdep_Click(object sender, EventArgs e)
        {
            FormDep fd= new FormDep(fGlobalEntities);
            fd.Show();
        }

        private void sm_help_Click(object sender, EventArgs e)
        {
            Process p = new Process { StartInfo = { FileName = ApplicationInfo.GetDirectory() + @"\Recog_help.chm" } };
            if (p != null) { p.Start(); }
        }

       

       
        private void sm_kettellCF_Click(object sender, EventArgs e)
        {
            FormPrinter.ShowForm(EnumPTests.KettellC); 
        }

        private void sm_kettellAF_Click(object sender, EventArgs e)
        {
            FormPrinter.ShowForm(EnumPTests.KettellA); 
        }

        private void sm_FPIF_Click(object sender, EventArgs e)
        {
            FormPrinter.ShowForm(EnumPTests.FPI); 
        }

        private void sm_DF_Click(object sender, EventArgs e)
        {
            FormPrinter.ShowForm(EnumPTests.Adaptability); 
        }

        private void sm_kettellCM_Click(object sender, EventArgs e)
        {
            FormPrinter.ShowMethod(EnumPTests.KettellC); 
        }

        private void sm_kettellAM_Click(object sender, EventArgs e)
        {
            FormPrinter.ShowMethod(EnumPTests.KettellA); 
        }

        private void sm_FPIM_Click(object sender, EventArgs e)
        {
            FormPrinter.ShowMethod(EnumPTests.FPI); 
        }

        private void sm_DM_Click(object sender, EventArgs e)
        {
            FormPrinter.ShowMethod(EnumPTests.Adaptability); 
        }

        private void submenu_PNN_Click(object sender, EventArgs e)
        {
            FormPrinter.ShowMethod(EnumPTests.PNN); 
        }

        private void menu_pool_Click(object sender, EventArgs e)
        {
           PoollForm pf = new PoollForm(pGlobalEntities,fGlobalEntities);
           pf.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadFBForm frm = new LoadFBForm(pGlobalEntities,fGlobalEntities);
            frm.ShowDialog();
        }

        private void submenu_packeditor_Click(object sender, EventArgs e)
        {
            PEditorForm pe = new PEditorForm(pGlobalEntities);
            pe.Show();
        }

        private void submenuMDB_Click(object sender, EventArgs e)
        {
            FormPrinter.ShowForm(EnumPTests.Modul2); 
        }

        private void submenuMDM_Click(object sender, EventArgs e)
        {
            FormPrinter.ShowMethod(EnumPTests.Modul2); 
        }

        private void tb_automator_Click(object sender, EventArgs e)
        {
            AutomatorForm automator = new AutomatorForm(pGlobalEntities, fGlobalEntities);
            automator.Show();
            
        }

        private void submenu_backup_Click(object sender, EventArgs e)
        {
            ExportForm backform = new ExportForm(fGlobalEntities,pGlobalEntities);
            backform.Show();
        }

        private void submenu_import_Click(object sender, EventArgs e)
        {
            ImportForm loadform = new ImportForm(fGlobalEntities);
            loadform.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            TestAdd t = new TestAdd();
            t.Show();
            //PortraitForm fc = new PortraitForm();
            //List<string> d = new List<string>() { "да", "нет" };
            //fc.Create("tmp.pdf", 232, 2, d, 29);
        }

        private void submenuPB_Click(object sender, EventArgs e)
        {
            FormPrinter.ShowForm(EnumPTests.Prognoz); 
        }

        private void submenuPM_Click(object sender, EventArgs e)
        {
            FormPrinter.ShowMethod(EnumPTests.Prognoz); 
        }

        private void submenuaddictblank_Click(object sender, EventArgs e)
        {
            FormPrinter.ShowForm(EnumPTests.Addictive); 
        }

        private void submenuaddictmethod_Click(object sender, EventArgs e)
        {
            FormPrinter.ShowMethod(EnumPTests.Addictive); 
        }

        private void submenuleongardblank_Click(object sender, EventArgs e)
        {
            FormPrinter.ShowForm(EnumPTests.Leongard); 
        }

        private void submenuleongardmathod_Click(object sender, EventArgs e)
        {
            FormPrinter.ShowMethod(EnumPTests.Leongard); 
        }

        private void submenunpnablank_Click(object sender, EventArgs e)
        {
            FormPrinter.ShowForm(EnumPTests.NPNA); 
        }

        private void submenunpnamethod_Click(object sender, EventArgs e)
        {
            FormPrinter.ShowMethod(EnumPTests.NPNA); 
        }

        private void sm_base_manage_Click(object sender, EventArgs e)
        {
            ConnectionForm connform = new ConnectionForm(false);
            connform.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            RefreshMenu();
        }

        private void RefreshMenu()
        {
            if (Properties.Settings.Default.AllowViews == false)
            {
                menu_results.Visible = false;
                toolStripButton1.Visible = false;
                menu_help.Visible = false;
               
                tsep3.Visible = false;
                tsep4.Visible = false;
                tsep5.Visible = false;
                tsep6.Visible = false;
                tsep7.Visible = false;
                tsep8.Visible = false;
                toolStripButton2.Image = new Bitmap(ApplicationInfo.GetDirectory()+@"\Images\RightArrow.png");
            }
            else 
            {
                menu_results.Visible = true;
                toolStripButton1.Visible = true;
                menu_help.Visible = true;
              
                tsep3.Visible = true;
                tsep4.Visible = true;
                tsep5.Visible = true;
                tsep6.Visible = true;
                tsep7.Visible = true;
                tsep8.Visible = true;
                toolStripButton2.Image = new Bitmap(ApplicationInfo.GetDirectory() + @"\Images\LeftArrow.png");
            }
        }

        

        private void smenu_pass_Click(object sender, EventArgs e)
        {
            PassBox db = new PassBox();
            db.Text = "Введите старый пароль";
            db.ShowDialog();
            if (db.DialogResult == DialogResult.OK)
            {
                if (db.Description == Properties.Settings.Default.Pass)
                {
                    PassBox newdb = new PassBox();
                    newdb.Text = "Введите новый пароль";
                    newdb.ShowDialog();
                    if (newdb.DialogResult == DialogResult.OK)
                    {
                        if (newdb.Description.Trim()!="")
                        {
                            Properties.Settings.Default.Pass = newdb.Description;
                            Properties.Settings.Default.Save();
                        }
                    }
                    
                }
                else { MessageBox.Show("Неверный пароль"); }
            }

        }

        private void toolStripButton2_CheckedChanged(object sender, EventArgs e)
        {
            PassBox db = new PassBox();
            db.ShowDialog();
            if (db.DialogResult == DialogResult.OK)
            {
                if (db.Description == Properties.Settings.Default.Pass)
                {
                    Properties.Settings.Default.AllowViews = toolStripButton2.Checked;
                    Properties.Settings.Default.Save();
                    RefreshMenu();
                }
                else { MessageBox.Show("Неверный пароль"); }
            }
        }

     

        

       
       

      

      

       

        
    }
}
