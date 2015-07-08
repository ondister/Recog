using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Recog.PTests.PNN
{
    public enum PnnSignalType { Yellow = 0, Red = 1, Green = 2, None = -1 }
    public enum PnnKeyType { RightControl = 1, LeftControl = 2, AnyKey = 0 }
   
   
    public class PNNAnswer
    {
        
       
        private DateTime _time;
        private PnnSignalType _signal;
        private PnnKeyType _key;
        private bool _answer;
        private int _exposition;

        [XmlElement]
        public int Exposition
        {
            get { return _exposition; }
            set { _exposition = value; }
        }

         [XmlElement]
        public bool Answer
        {
            get 
            { 
                return _answer; 
            }
            set { _answer = value; }
           
        }

         [XmlElement]
        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

         [XmlElement]
        public PnnKeyType Key
        {
            get { return _key; }
            set { _key = value; }
        }

         [XmlElement]
        public PnnSignalType Signal
        {
            get { return _signal; }
            set { _signal = value; }
        }

        public PNNAnswer(PnnSignalType signal, PnnKeyType key, DateTime time, int exposition)
        {
            _time = time;
            _signal = signal;
            _key = key;
            _answer = SignalComparer(key, signal);
            _exposition = exposition;
        }
        public PNNAnswer() { }
        private bool SignalComparer(PnnKeyType  key,PnnSignalType signal)
        {
            if ((int)key ==(int) signal) { return true; }
            else { return false; }
        }
    }

   

}
