using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;

using System.Windows.Forms;
using System.Data.EntityClient;
using FirebirdSql.Data.FirebirdClient;
namespace Recog
{
    public class ConnectArgs : EventArgs
    {
        public bool IsSuccess;
    }
    public delegate void ConnectHandler(object sender, ConnectArgs arg);

   public class MainLoader
    {
        private pBaseEntities _ge;
        private fBaseEntities _fe;
        public event ConnectHandler ConnectComplite;
        private ConnectArgs arg;

        private void OnConnectComplite() { if (ConnectComplite != null) { ConnectComplite(this, arg); } }
        public pBaseEntities GE
        {
            get { return _ge; }
        }
        public fBaseEntities FE
        {
            get { return _fe; }
        }
        public MainLoader()
        {
            arg = new ConnectArgs();
        }
        public void Start()
        {
            Splash sf = new Splash();
            sf.Show();
            //try
            //{

            BaseManager database = new BaseManager();
            if (database.FbconnectionIsValid == true & database.PbconnectionIsValid==true)
            {
                _ge = database.Ge;
                _fe = database.Fe;
                sf.Close();
                arg.IsSuccess = true;
                OnConnectComplite();
            }
            else
            { 
                sf.Close();
                MessageBox.Show("Требуется настройка подключения к базам данных.\nСейчас Вам будут предоставлены настройки по умолчанию.","Философия выбора",MessageBoxButtons.OK,MessageBoxIcon.Error);
                arg.IsSuccess = false;
                OnConnectComplite();
            }



             
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    sf.Close();
            //}
            
        }


        


    }
}
