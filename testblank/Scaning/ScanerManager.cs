using System;
using System.Collections.Generic;
using System.Linq;
using Recog.Data;
using TwainDotNet;
using TwainDotNet.WinFroms;
namespace Recog.Scaning
{

    public class ScanerManager
    {
        private Scaner _currentscaner;

        public Scaner CurrentScaner
        {
            get { return _currentscaner; }
        }
        private FormSelect fs;
        private pBaseEntities _ge;
        private WinFormsWindowMessageHook _wh;
        public ScanerManager(pBaseEntities GlobalEntities, WinFormsWindowMessageHook wh)
        {
            _ge = GlobalEntities;
            _wh = wh;
        }

        public void GetDevicefromBase()
        {
            int scancount = _ge.scaners.Count(sc => sc.ids == 1);
            if (scancount == 0)
            {
                SelectDevice();
            }
            else
            {
                scaner s = _ge.scaners.First(sc => sc.ids == 1);
                _currentscaner = new Scaner(s.currentscanername, Scaner.StringToScanerType(s.driver), _wh);

            }

        }

        private List<Scaner> GetScanersList()
        {
            List<Scaner> ls = new List<Scaner>();
            Scaner s;
            try
            {
                Twain _twain = new Twain(_wh);
                if (_twain.SourceNames.Count != 0)
                {
                    _twain.SelectSource();
                    s = new Scaner(_twain.DefaultSourceName, EnumScanerType.Twain, _wh);
                    ls.Add(s);
                }
            }
            catch (TwainException) { }
            List<string> devices = WIAScanner.GetDevices();
            foreach (string device in devices)
            {
                s = new Scaner(device, EnumScanerType.WIA, _wh);
                ls.Add(s);

            }
            s = new Scaner("Изображение из файла", EnumScanerType.File, _wh);
            ls.Add(s);
            return ls;
        }

        public void SelectDevice()
        {
            fs = new FormSelect();
            fs.btn_done.Click += new EventHandler(btn_done_Click);

            _wh = new WinFormsWindowMessageHook(fs);
            fs.Devlist = GetScanersList();
            fs.ShowDialog();
            fs.BringToFront();
        }

        void btn_done_Click(object sender, EventArgs e)
        {
            _currentscaner = fs.SelectedScaner;
            if (_currentscaner != null)
            {
                fs.Close();
                SaveScaner();
            }
            
        }

        private void SaveScaner()
        {
            int scancount = _ge.scaners.Count(sc => sc.ids == 1);
            if (scancount == 0)
            {
                scaner s = scaner.Createscaner(0, _currentscaner.Name, _currentscaner.Type.ToString());
                _ge.scaners.AddObject(s);
            }
            else
            {
                scaner s = _ge.scaners.First(sc => sc.ids == 1);
                s.currentscanername = _currentscaner.Name;
                s.driver = _currentscaner.Type.ToString();
            }
            _ge.SaveChanges();

        }





    }
}
