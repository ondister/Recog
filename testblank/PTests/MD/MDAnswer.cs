using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Recog.PTests.MD
{
    public class MDAnswer
    {

        private DateTime _time;
        private string _answerdescription;
        private int _selectedcellindex;
        private string _selectedcelldescription;
        private string _selectedcellbuttondescription;
        private int _answerindex;
        [XmlElement]
        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

        [XmlElement]
        public int SelectedCellIndex
        {
            get { return _selectedcellindex; }
            set { _selectedcellindex = value; }
        }

        [XmlElement]
        public string SelectedCellDescription
        {
            get { return _selectedcelldescription; }
            set { _selectedcelldescription = value; }
        }

        [XmlElement]
        public string SelectedCellButtonDescription
        {
            get { return _selectedcellbuttondescription; }
            set { _selectedcellbuttondescription = value; }
        }

        [XmlElement]
        public int AnswerIndex
        {
            get { return _answerindex; }
            set { _answerindex = value; }
        }

        [XmlElement]
        public string AnswerDescription
        {
            get { return _answerdescription; }
            set { _answerdescription = value; }
        }
    }
}
