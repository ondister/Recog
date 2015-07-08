using System;
using System.Timers;
using System.Xml.Serialization;
using Recog.Controls;
namespace Recog.PTests.PNN
{

    public class PNNTestLoader
    {


        private int _exposition;
        private CycleControl _control;
        private Timer _timer;
        private PNNAnswers _answers;
        private PnnKeyType _currkey;
        private DateTime _time;
        private Timer _pauseTimer;
        [XmlElement(Type = typeof(PNNAnswer))]
        public PNNAnswers Answers
        {
            get { return _answers; }
        }
        public PNNTestLoader(int InitialExposition, CycleControl Control)
        {
            _exposition = InitialExposition;
            _timer = new Timer();
            _timer.AutoReset = false;
            _timer.Interval = _exposition;
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            _control = Control;
            _answers = new PNNAnswers();
            _currkey = PnnKeyType.AnyKey;
            _pauseTimer = new Timer();
            _pauseTimer.AutoReset = false;
            _pauseTimer.Interval = 200;//пауза между сигналами
            _pauseTimer.Elapsed += new ElapsedEventHandler(_pauseTimer_Elapsed);
        }
        public PNNTestLoader() { }


        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.SetFeedBack(_currkey, _time, _exposition);
            this.HideSignal();
            _currkey = PnnKeyType.AnyKey;
            _pauseTimer.Start();
        }

        void _pauseTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Interval = _exposition;
            _timer.Start();
            this.ShowSignal();
        }

        public void SetKey(PnnKeyType key, DateTime time)
        {
            _currkey = key;
            _time = time;
        }


        private void SetFeedBack(PnnKeyType key, DateTime time, int exposition)
        {
            PNNAnswer a = new PNNAnswer(_control.CurrentSignalType, key, time, exposition);
            if (_answers.GetWrongPercent() <= 50)
            {
                if (a.Answer == true) { _exposition -= 10; }
            }
            if (a.Answer == false) { _exposition += 10; }

            _answers.Add(a);

        }


        private void ShowSignal()
        {
            _control.SetSignal(NextRandomSignal());
        }

        private void HideSignal()
        {
            _control.SetSignal(PnnSignalType.None);
        }

        public void Start()
        {
            _pauseTimer.Start();
        }

        public void Stop()
        {
            _timer.Stop();

        }

        private PnnSignalType NextRandomSignal()
        {
            Random r = new Random();
            int i = r.Next(3);
            return (PnnSignalType)i;
        }




    }



}
