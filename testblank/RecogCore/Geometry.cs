using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge;

namespace Recog.RecogCore
{
   
    public static class Geometry
    {
       
        public static double PXtoMM(int PX, double Resolution)
        {
           
            double _mm = 0;
            _mm = (PX / Resolution) * 25.4;
            return _mm;
        }

     
        public static int MMtoPX(double MM, double Resolution)
        {

            double _dpi = 0;
            _dpi = (MM / 25.4) * Resolution;
            return Convert.ToInt16(_dpi);
        }

        public static double EuclidianDistance(Point point1, Point point2)
        {
            double distance = 0.0d;
            distance = Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
            return distance;

        }

    }
}
