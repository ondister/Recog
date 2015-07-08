using System;
using System.Xml.Serialization;

namespace Recog.PTests.Contrasts
{

    public class ContrastsAnswer
    {


        private DateTime _time;
        private int _pictureid;



        [XmlElement]
        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

        [XmlElement]
        public int PictureId
        {
            get { return _pictureid; }
            set { _pictureid = value; }
        }


        public ContrastsAnswer(DateTime time, int pictureid)
        {
            _time = time;
            _pictureid = pictureid;
        }
        public ContrastsAnswer() { }



    }


}


