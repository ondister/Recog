using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recog.BlankRecognition
{
   public class RecogResult
    {
        private double _mindisp;
        private int _mistakecount;
        private double _rangewidth;

        public double RangeWidth
        {
            get { return _rangewidth; }
            set { _rangewidth = value; }
        }

        public double MinDisp
        {
            get { return _mindisp; }
            set { _mindisp = value; }
        }
       

       public int MistakeCount
        {
            get { return _mistakecount; }
            set { _mistakecount = value; }
        }
    }
}
