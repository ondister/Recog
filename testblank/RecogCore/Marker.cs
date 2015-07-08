using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Imaging;
using AForge;


namespace Recog.RecogCore
{
   public class Marker
    {
        private Blob _blob;
        private double _distansefrommarkers;
        private double _distancefromcenter;
        private MarkerType _type;
        public MarkerType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public double DistanceFromCenter
        {
            get { return _distancefromcenter; }
        }
        public double DistanseFromMarkers
        {
            get { return _distansefrommarkers; }
        }
        public Blob Blob
        {
            get { return _blob; }
        }

       public Marker(Blob blob)
       {
           _blob = blob;
           _distansefrommarkers = 0.0d;
           _distancefromcenter = 0.0d;
       }

       public void GetDistanceFromMarkers(List<Marker> markers)
       { 

       foreach(Marker marker in markers)
       {
           _distansefrommarkers += Geometry.EuclidianDistance(_blob.CenterOfGravity, marker._blob.CenterOfGravity);
       }
       }

       public void GetDistanceFromCenter(Point centerpoint)
       {
           _distancefromcenter = Geometry.EuclidianDistance(_blob.CenterOfGravity, centerpoint);
       }


    }
}
