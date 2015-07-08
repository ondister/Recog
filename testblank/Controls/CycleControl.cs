using System;
using System.Drawing;
using System.Windows.Forms;
using Recog.PTests.PNN;
namespace Recog.Controls
{
    public partial class CycleControl : UserControl
    {
        private Bitmap _green;
        private Bitmap _red;
        private Bitmap _yellow;

        private PnnSignalType _currsignal;

        public PnnSignalType CurrentSignalType
        {
            get { return _currsignal; }
        }


        public CycleControl()
        {
            InitializeComponent();
            _currsignal = PnnSignalType.None;
            try
            {
                _green = new Bitmap(ApplicationInfo.GetDirectory() + @"\Images\Pnn\GreenCicle.png");
                _red = new Bitmap(ApplicationInfo.GetDirectory() + @"\Images\Pnn\RedCicle.png");
                _yellow = new Bitmap(ApplicationInfo.GetDirectory() + @"\Images\Pnn\YellowCicle.png");
            }

            catch { throw new Exception("Не удалось найти файлы с кружками..."); }
        }


        public void SetSignal(PnnSignalType Signal)
        {
            _currsignal = Signal;

            switch (Signal)
            {
                case PnnSignalType.Green:
                    pb_cycle.Image = _green;
                    break;
                case PnnSignalType.Red:
                    pb_cycle.Image = _red;
                    break;
                case PnnSignalType.Yellow:
                    pb_cycle.Image = _yellow;
                    break;
                case PnnSignalType.None:
                    pb_cycle.Image = null;
                    break;
            }

        }


    }
}
