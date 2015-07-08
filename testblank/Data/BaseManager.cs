using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using Recog.Properties;
using System.Data.EntityClient;
namespace Recog.Data
{
    public class BaseManager
    {
        private pBaseEntities _ge;
        private fBaseEntities _fe;
        private bool _pbconnectionisvalid;
        private bool _fbconnectionisvalid;
        private FbServerType _servertype;
        private string _serverip;
        private string _pdatabase;
        private string _fdatabase;

        public string ServerIP
        {
            get { return _serverip; }
            set { _serverip = value; }
        }

        public string PDataBase
        {
            get { return _pdatabase; }
            set { _pdatabase = value; }
        }

        public string FDataBase
        {
            get { return _fdatabase; }
            set { _fdatabase = value; }
        }

        public FbServerType ServerType
        {
            get { return _servertype; }
            set { _servertype = value; }
        }

        public pBaseEntities Ge
        {
            get { return _ge; }
        }

        public fBaseEntities Fe
        {
            get { return _fe; }
        }

        public bool PbconnectionIsValid
        {
            get { return _pbconnectionisvalid; }
        }

        public bool FbconnectionIsValid
        {
            get { return _fbconnectionisvalid; }
        }

        public BaseManager()
        {
            _pbconnectionisvalid = false;
            _fbconnectionisvalid = false;

            if (Settings.Default.ServerType == FbServerType.Embedded.ToString())
            {
                _servertype = FbServerType.Embedded;
            }
            else
            {
                _servertype = FbServerType.Default;
            }

            _serverip = Settings.Default.ServerIP;
            _pdatabase = Settings.Default.pBaseAlias;
            _fdatabase = Settings.Default.fBaseAlias;

            string pconnstring = pConnectionString();
            string fconnstring = fConnectionString();

            if (_pbconnectionisvalid == true & _fbconnectionisvalid == true)
            {
                _ge = new pBaseEntities(pconnstring);
                _fe = new fBaseEntities(fconnstring);
            }
            else
            {
                _ge = null;
                _fe = null;
            }


        }


        public string fConnectionString()
        {

            const string providerName = "FirebirdSql.Data.FirebirdClient";
            const string metaData = "res://*/Data.fModel.csdl|res://*/Data.fModel.ssdl|res://*/Data.fModel.msl";

            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();

            entityBuilder.Provider = providerName;

            FbConnectionStringBuilder sqlBuilder = new FbConnectionStringBuilder();

            sqlBuilder.UserID = "sysdba";
            sqlBuilder.Password = "masterkey";
            sqlBuilder.Dialect = 3;
            sqlBuilder.Charset = "WIN1251";
            sqlBuilder.ServerType = _servertype;

            if (_servertype == FbServerType.Embedded)
            {
                sqlBuilder.Database = _fdatabase;
                sqlBuilder.ClientLibrary = ApplicationInfo.GetDirectory() + @"\Data\fembeded\fbembed.dll";
            }
            else
            {
                sqlBuilder.Database = _fdatabase;
                sqlBuilder.DataSource = _serverip;
            }
           
            try
            {
                FbConnection conn = new FbConnection(sqlBuilder.ConnectionString);
                conn.Open();
                _fbconnectionisvalid = true;
            }
            catch
            {
                _fbconnectionisvalid = false;
            }

            entityBuilder.ProviderConnectionString = sqlBuilder.ConnectionString;
            entityBuilder.Metadata = metaData;
            return entityBuilder.ToString();
        }

        public string pConnectionString()
        {
            const string providerName = "FirebirdSql.Data.FirebirdClient";
            const string metaData = "res://*/Data.pModel.csdl|res://*/Data.pModel.ssdl|res://*/Data.pModel.msl";

            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();

            entityBuilder.Provider = providerName;

            FbConnectionStringBuilder sqlBuilder = new FbConnectionStringBuilder();

            sqlBuilder.UserID = "sysdba";
            sqlBuilder.Password = "masterkey";
            sqlBuilder.Dialect = 3;
            sqlBuilder.Charset = "WIN1251";
            sqlBuilder.ServerType = _servertype;

            if (_servertype == FbServerType.Embedded)
            {
                sqlBuilder.Database = _pdatabase;
                sqlBuilder.ClientLibrary = ApplicationInfo.GetDirectory() + @"\Data\fembeded\fbembed.dll";
            }
            else
            {
                sqlBuilder.Database = _pdatabase;
                sqlBuilder.DataSource = _serverip;
            }
           
            try
            {
                FbConnection conn = new FbConnection(sqlBuilder.ConnectionString);
                conn.Open();
                _pbconnectionisvalid = true;
            }
            catch
            {
                _pbconnectionisvalid = false;
            }

            entityBuilder.ProviderConnectionString = sqlBuilder.ConnectionString;
            entityBuilder.Metadata = metaData;
            return entityBuilder.ToString();


        }

        public string CheckConnection()
        {
            string warnings = "";

            string pconnstring = pConnectionString();
            string fconnstring = fConnectionString();

            if (_pbconnectionisvalid == true & _fbconnectionisvalid == true)
            {
                warnings += "Проверка подключения пройдена успешно";
            }

            if (_pbconnectionisvalid == false)
            {
                warnings += "Не пройдена проверка подключения к базе FPBASE.fdb";
            }
            if (_pbconnectionisvalid == false)
            {
                warnings += "\nНе пройдена проверка подключения к базе FFBASE.fdb";
            }


            return warnings;
        }
        public void SaveConnection()
        {
        
            Settings.Default.ServerType = _servertype.ToString();
            Settings.Default.ServerIP = _serverip;
            Settings.Default.pBaseAlias =_pdatabase;
            Settings.Default.fBaseAlias = _fdatabase;
            Settings.Default.Save();
        }
    
    
    }
}
