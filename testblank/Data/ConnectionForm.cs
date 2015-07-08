using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FirebirdSql.Data.FirebirdClient;

namespace Recog.Data
{


    public partial class ConnectionForm : Form
    {
        private BaseManager _database;

        private bool _defaultsettings;

        private void SetDefaultSettings()
        {
            cb_servertype.SelectedValue = FbServerType.Embedded.ToString();
            tb_pbase_path.Text = ApplicationInfo.GetDirectory() +@"\Data\FPBASE.fdb";
            tb_fbase_path.Text = ApplicationInfo.GetDirectory() + @"\Data\FFBASE.fdb";
        }



        public ConnectionForm(bool defaultsettings)
        {
            InitializeComponent();
            _defaultsettings = defaultsettings;

            HelpProvider help = new HelpProvider();
            help.HelpNamespace = "Recog_help.chm";
            help.SetHelpNavigator(this, HelpNavigator.Topic);
            help.SetHelpKeyword(this, "menu_settings.htm#conn_settings");
        }

        private void ConnectionForm_Load(object sender, EventArgs e)
        {
           _database = new BaseManager();
            ArrayList servers = new ArrayList();
            servers.Add(new ServerName(FbServerType.Embedded.ToString(), "Встроенный сервер"));
            servers.Add(new ServerName(FbServerType.Default.ToString(), "Сервер сети или локальный"));
            this.cb_servertype.DataSource = servers;
            this.cb_servertype.DisplayMember = "LongName";
            this.cb_servertype.ValueMember = "ShortName";
            
            this.cb_servertype.SelectedValue = _database.ServerType.ToString();

            if (_defaultsettings == true) { SetDefaultSettings(); }
        }

        private void btn_openpbase_Click(object sender, EventArgs e)
        {
            OpenFileDialog basedialog = new OpenFileDialog();

            basedialog.InitialDirectory = ApplicationInfo.GetDirectory() + @"\Data";
            basedialog.Filter = "База FPBASE (FPBASE.fdb)|FPBASE.fdb";
            basedialog.RestoreDirectory = true;

            if (basedialog.ShowDialog(this) == DialogResult.OK)
            {
                tb_pbase_path.Text = basedialog.FileName;
            }
        }

        private void btn_openfbase_Click(object sender, EventArgs e)
        {
            OpenFileDialog basedialog = new OpenFileDialog();

            basedialog.InitialDirectory = ApplicationInfo.GetDirectory() + @"\Data";
            basedialog.Filter = "База FPBASE (FFBASE.fdb)|FFBASE.fdb";
            basedialog.RestoreDirectory = true;

            if (basedialog.ShowDialog(this) == DialogResult.OK)
            {
                tb_fbase_path.Text = basedialog.FileName;
            }
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            MessageBox.Show(CheckConn());
        }

        private string CheckConn()
        {
            if (cb_servertype.SelectedValue.ToString() == FbServerType.Embedded.ToString())
            {
                _database.ServerType = FbServerType.Embedded;
            }
            else
            {
                _database.ServerType = FbServerType.Default;
            }

            _database.ServerIP = tb_ip.Text;
            _database.PDataBase = tb_pbase_path.Text;
            _database.FDataBase = tb_fbase_path.Text;

            string warnings = _database.CheckConnection();  
            return warnings;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string warnings = CheckConn();

            if (_database.PbconnectionIsValid == true & _database.FbconnectionIsValid == true)
            {
                _database.SaveConnection();
               
                MessageBox.Show("Параметры подключения сохранены, запустите приложение еще раз");
                this.Close();
            }
            else { MessageBox.Show(warnings); }
        }

        private void cb_servertype_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_servertype.SelectedValue.ToString() == FbServerType.Default.ToString())
            {
                tb_ip.Enabled = true;
                tb_ip.Text = _database.ServerIP;
            }
            else 
            {
                tb_ip.Enabled = false;
                tb_ip.Text = "";
            }
            
            tb_pbase_path.Text = _database.PDataBase;
            tb_fbase_path.Text = _database.FDataBase;
            
        }


    }


    public class ServerName
    {
        private string _shortname;

        public string ShortName
        {
            get { return _shortname; }
        }
        private string _longname;

        public string LongName
        {
            get { return _longname; }
        }
        public ServerName(string shortname, string longname)
        {
            _shortname = shortname;
            _longname = longname;
        }

    }

}