using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TwainDotNet;
using TwainDotNet.TwainNative;
using TwainDotNet.WinFroms;

namespace Recog.Scaning
{
    public class Scaner
    {
        private string _name;
        private WinFormsWindowMessageHook _wh;
        private EnumScanerType _type;
        private Bitmap _image;
        private Twain _twain;
        public event EventHandler ScanDone;
        private EventArgs arg;
        private void OnScanDone() { if (ScanDone != null) { ScanDone(this, arg); } }
        public Bitmap Image
        {
            get { return _image; }
        }
        public string Name
        {
            get { return _name; }
        }

        public EnumScanerType Type
        {
            get { return _type; }
        }

        public Scaner(string name, EnumScanerType type, WinFormsWindowMessageHook wh)
        {
            arg = new EventArgs();
            _name = name.Trim();
            _type = type;
            _wh = wh;
            if (_type == EnumScanerType.Twain)
            {
                try
                {
                    _twain = new Twain(_wh);
                    _twain.TransferImage += new EventHandler<TransferImageEventArgs>(_twain_TransferImage);
                    _twain.ScanningComplete += new EventHandler<ScanningCompleteEventArgs>(_twain_ScanningComplete);
                    _twain.SelectSource(_name);
                }
                catch
                {
                    _type = EnumScanerType.File;
                }
                
            }
        }

        public static EnumScanerType StringToScanerType(string s)
        {
            EnumScanerType st = EnumScanerType.File;
            switch (s.Trim())
            {

                case "WIA":
                    st = EnumScanerType.WIA;
                    break;

                case "Twain":
                    st = EnumScanerType.Twain;
                    break;
            }
            return st;
        }

        public void Scan()
        {

            {

                switch (_type)
                {
                    case EnumScanerType.Twain:


                            try
                            {
                                this.ScanTwainFixedSize();
                            }
                            catch  
                            {
                                try
                                {
                                    this.ScanTwainA4();
                                }
                                catch 
                                {
                                    MessageBox.Show("Проблема при использовании драйвера Twain. Проверьте подключение сканера, чотя есть вероятность, что сканер не поддерживается.");
                                }
                            }
                        break;



                    case EnumScanerType.WIA:
                        try
                        {
                            List<Bitmap> lst = WIAScanner.Scan(_name);
                            if (lst.Count != 0)
                            {
                                _image = lst[0];
                                OnScanDone();
                            }
                        }
                        catch { MessageBox.Show("Не найден сканер. Проверьте подключение или выберите другой в настройках"); }

                        break;
                    case EnumScanerType.File:
                        OpenFileDialog oof_dialog = new OpenFileDialog();
                        oof_dialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.* ";
                        oof_dialog.Title = "Выберите изображение из файла";

                        if (oof_dialog.ShowDialog() == DialogResult.OK)
                        {
                            string fn = oof_dialog.FileName;

                            _image = new Bitmap(fn);
                            OnScanDone();

                        }
                        break;
                }
            }

        }




        private void ScanTwainA4()
        {

         
            ScanSettings _settings = new ScanSettings();
            ResolutionSettings rs = new ResolutionSettings();
            rs.ColourSetting = ColourSetting.GreyScale;
            rs.Dpi = 100;
            _settings.Resolution = rs;
            _settings.ShowTwainUI = false;
            _settings.ShowProgressIndicatorUI = true;
            PageSettings ps = new PageSettings();
            ps.Orientation = TwainDotNet.TwainNative.Orientation.Portrait;
            ps.Size = PageType.MaxSize;

            _settings.Page = ps;
           
                _twain.StartScanning(_settings);
             }

        private void ScanTwainFixedSize()
        {

              AreaSettings AreaSettings = new AreaSettings(Units.Centimeters, 0f, 0f, 29.7f, 21.01f);
            ScanSettings _settings = new ScanSettings();
            ResolutionSettings rs = new ResolutionSettings();
            rs.ColourSetting = ColourSetting.GreyScale;
            rs.Dpi = 100;
            _settings.Resolution = rs;
            _settings.ShowTwainUI = false;
            _settings.ShowProgressIndicatorUI = true;
            _settings.Area = AreaSettings;
           
           
                _twain.StartScanning(_settings);
           
        }

        void _twain_ScanningComplete(object sender, ScanningCompleteEventArgs e)
        {
            OnScanDone();
        }

        void _twain_TransferImage(object sender, TransferImageEventArgs e)
        {
            if (e.Image != null)
            {
                _image = e.Image;
            }
        }



    }
}
