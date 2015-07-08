using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;


namespace Recog.Data
{


    public partial class ImportForm : Form
    {
        private fBaseEntities _fe;
        private BackupTool _backuptool;
        public ImportForm(fBaseEntities fe)
        {
            InitializeComponent();
            _fe = fe;
            _backuptool = new BackupTool(_fe);
            _backuptool.HumanDone += new EventHandler(_backuptool_HumanDone);

            HelpProvider help = new HelpProvider();
            help.HelpNamespace = "Recog_help.chm";
            help.SetHelpNavigator(this, HelpNavigator.Topic);
            help.SetHelpKeyword(this, "menu_settings.htm#import_resp");
        }

        void _backuptool_HumanDone(object sender, EventArgs e)
        {
            pb_progress.PerformStep();
        }






        private void btn_setdir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dirdialog = new FolderBrowserDialog();
            dirdialog.Description = "Укажите папку, в которую необходимо осуществить экспорт";
            if (dirdialog.ShowDialog() == DialogResult.OK)

                txt_dirpath.Text = dirdialog.SelectedPath;
        }

        private void btn_startimport_Click(object sender, EventArgs e)
        {

            if (txt_dirpath.Text.Length != 0)
            {
                _backuptool.CheckRestorePath(txt_dirpath.Text);
                pb_progress.Value = 1;
                pb_progress.Minimum = 1;
                pb_progress.Step = 1;
                pb_progress.Maximum =_backuptool.Humans.Count;
                if (_backuptool.Restore(txt_dirpath.Text) == true)
                {
                    MessageBox.Show("Импорт завершен");
                }
                else 
                {
                    MessageBox.Show("Папка, указанная в качестве источника для импорта не содержит необходимых файлов. \nИзвините, но импорт невозможен.");
                }
            }


        }


    }




}
