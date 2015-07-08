using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using AForge;
using AForge.Math;
using System.Drawing;
using System.Drawing.Imaging;
using Recog.RecogCore.AnswerGrid;

namespace Recog.RecogCore
{
    public class Canvas
    {
        private Bitmap _image;
        private Bitmap _recogimg;
        public Bitmap _markersimg;
        private double _makerdiameter;
        private Marker _tcmarker;
        private Answers _answers;

        public Answers Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }

        public Marker TopCenterMarker
        {
            get { return _tcmarker; }
            set { _tcmarker = value; }
        }
        private Marker _tlmarker;

        public Marker TopLeftMarker
        {
            get { return _tlmarker; }
            set { _tlmarker = value; }
        }
        private Marker _trmarker;

        public Marker TopRightMarker
        {
            get { return _trmarker; }
            set { _trmarker = value; }
        }
        private Marker _blmarker;

        public Marker BottomLeftMarker
        {
            get { return _blmarker; }
            set { _blmarker = value; }
        }
        private Marker _brmarker;

        public Marker BottomRightMarker
        {
            get { return _brmarker; }
            set { _brmarker = value; }
        }
        private List<Marker> _markers;


        public Bitmap Image
        {
            get { return _image; }
        }

        public Bitmap CorrectedImage
        {
            get { return _recogimg; }
        }

        public Canvas(Bitmap image, double markerdiameter)
        {
            _makerdiameter = markerdiameter;
            if (image.HorizontalResolution > 100)
            {
                _image = this.Resize(image);
            }
            else if (image.HorizontalResolution < 96)
            {
                throw new Exception("Слишком низкое разрешение изображения. Необходимо не менее 100 точек на дюйм");
            }
            else 
            {
                _image = image;
            }

            _recogimg = AForge.Imaging.Image.Clone(_image, PixelFormat.Format24bppRgb);
            _markersimg = AForge.Imaging.Image.Clone(_image, PixelFormat.Format24bppRgb);

            _answers = new Answers();
        }

        public void RecognizeImage()
        {
            this.Preprocess();
            this.FindCenterMarker();
            this.FindMarkers();

        }

        private void Preprocess()
        {
            this.ToGrayScale();
            this.CorrectLevels();
            this.RotateImage();
            this.InvertImage();
            this.CheckUp();
        }

       
        private void ToGrayScale()
        {
            Grayscale gf = new Grayscale(0.2125, 0.7154, 0.0721);
            _recogimg = gf.Apply(_recogimg);
        }

        private void CorrectLevels()
        {
            ImageStatistics ims = new ImageStatistics(_recogimg);

            Histogram gr = ims.Gray;
            double median = gr.Median;
            double mean = gr.Mean;
            double stdev = gr.StdDev;
            //30 170 10

            //for (int i = 30; i < 170; i += 10)
            //{
            //    this.CorrectLevel(i, (int)mean);
            //    ims = new ImageStatistics(_recogimg);
            //    gr = ims.Gray;
            //    stdev = gr.StdDev;
            //    mean = gr.Mean;
            //    if (stdev >= 65 & mean >= 220) { break; }
            //}

            BradleyLocalThresholding filter = new BradleyLocalThresholding();
            // apply the filter
            filter.ApplyInPlace(_recogimg);
        }

        private void CorrectLevel(int MinLevel, int MaxLevel)
        {
            LevelsLinear filter = new LevelsLinear();
            filter.Input = new IntRange(MinLevel, MaxLevel);
            filter.ApplyInPlace(_recogimg);
        }

        private void InvertImage()
        {
            Invert invertfilter = new Invert();
            _markersimg = invertfilter.Apply(_recogimg);
        }

       
        private void FindCenterMarker()
        {

            List<Marker> _blobs = new List<Marker>();
            //блокируем изображение в памяти
            BitmapData bitmapData = _markersimg.LockBits(
                new Rectangle(0, 0, _markersimg.Width, _markersimg.Height),
                ImageLockMode.ReadWrite, _markersimg.PixelFormat);

            BlobCounter blobCounter = new BlobCounter();
            blobCounter.FilterBlobs = true;
            //устанавливаем фильтр и максимальные и минимальные размеры маркера
            blobCounter.MinHeight = blobCounter.MinWidth = Geometry.MMtoPX(_makerdiameter - 2.0d, _image.VerticalResolution);
            blobCounter.MaxHeight = blobCounter.MaxWidth = Geometry.MMtoPX(_makerdiameter + 3.0d, _image.VerticalResolution);



            //собственно поиск
            blobCounter.ProcessImage(bitmapData);
            Blob[] blobs = blobCounter.GetObjectsInformation();
            _markersimg.UnlockBits(bitmapData);

            for (int i = 0, n = blobs.Length; i < n; i++)
            {

                if (blobs[i].Fullness > 0.3)
                {

                    Marker tempmark = new Marker(blobs[i]);
                    _blobs.Add(tempmark);

                }
            }
            this.RecognizeMarkers(_blobs);
        }





        private void RecognizeMarkers(List<Marker> markers)
        {
            if (markers.Count < 5)
            {
                throw new Exception("Число распознанных маркеров  меньше 5. Бланк не читаем.");
            }
            else
            {

                _markers = markers;
                _tcmarker = markers.FirstOrDefault(marker => marker.Blob.Fullness == markers.Max(newmark => newmark.Blob.Fullness));
                if (_tcmarker != null)
                {
                    _markers.Remove(_tcmarker);
                    _tcmarker.Type = MarkerType.TopCenter;
                }

            }
        }

        private void FindMarkers()
        {
            //


            List<Marker> lefts = new List<Marker>();
            List<Marker> rights = new List<Marker>();
            foreach (Marker marker in _markers)
            {
                if (marker.Blob.CenterOfGravity.X < _tcmarker.Blob.CenterOfGravity.X)
                { lefts.Add(marker); }
                else
                { rights.Add(marker); }
            }

            _tlmarker = lefts.FirstOrDefault(marker => marker.Blob.CenterOfGravity.Y == lefts.Min(newmark => newmark.Blob.CenterOfGravity.Y));
            _blmarker = lefts.FirstOrDefault(marker => marker.Blob.CenterOfGravity.Y == lefts.Max(newmark => newmark.Blob.CenterOfGravity.Y));
            _trmarker = rights.FirstOrDefault(marker => marker.Blob.CenterOfGravity.Y == rights.Min(newmark => newmark.Blob.CenterOfGravity.Y));
            _brmarker = rights.FirstOrDefault(marker => marker.Blob.CenterOfGravity.Y == rights.Max(newmark => newmark.Blob.CenterOfGravity.Y));


        }

        private void RotateImage()
        {
            DocumentSkewChecker skewChecker = new DocumentSkewChecker();
            skewChecker.MaxSkewToDetect = 45;
            double angle = skewChecker.GetSkewAngle(_recogimg);

            //Максимальный угол, при котором идет поворот - 45 градусов, после этого изображение не поворачивается
            if (Math.Abs(angle) < 45)
            {
                RotateBilinear rotationFilter = new RotateBilinear(-angle, true);
                rotationFilter.FillColor = Color.Black;
                _recogimg = rotationFilter.Apply(_recogimg);
                _markersimg = rotationFilter.Apply(_markersimg);
            }

        }



        private void CheckUp()
        {
            List<double> disttohight = new List<double>();
            AForge.Point hightpoint = new AForge.Point((float)_markersimg.Width / 2.0f, 0);

            for (int iteration = 0; iteration < 4; iteration++)
            {
                FindCenterMarker();
               // RotateBicubic rbf = new RotateBicubic(-90);
                RotateBilinear rbf = new RotateBilinear(-90);
                _markersimg = rbf.Apply(_markersimg);
                disttohight.Add(Geometry.EuclidianDistance(_tcmarker.Blob.CenterOfGravity, hightpoint));
            }

            double mindist = disttohight.Min();
            double angle = disttohight.IndexOf(mindist) * -90;
            RotateBilinear _recogimgrotator = new RotateBilinear(angle);
            _recogimg = _recogimgrotator.Apply(_recogimg);
            _markersimg = _recogimgrotator.Apply(_markersimg);

        }

        private Bitmap Resize(Bitmap Image)
        {
            float resol = Image.VerticalResolution;
            double koef = resol / 100;
            int nw = Convert.ToInt16(Image.Width / koef);
            int nh = Convert.ToInt16(Image.Height / koef);
            Size sz = new Size(nw, nh);
            return new Bitmap(Image, sz);
        }

        private void SelectBlob(Blob _blob)
        {
            BitmapData imageData = _recogimg.LockBits(
  new Rectangle(0, 0, _image.Width, _recogimg.Height),
  ImageLockMode.ReadWrite, _recogimg.PixelFormat);

            UnmanagedImage _image8 = new UnmanagedImage(imageData);
            for (int x = _blob.Rectangle.X; x <= _blob.Rectangle.Right; x++)
            {
                _image8.SetPixel(x, _blob.Rectangle.Y, 0);
                _image8.SetPixel(x, _blob.Rectangle.Bottom, 0);
            }
            for (int y = _blob.Rectangle.Y; y <= _blob.Rectangle.Bottom; y++)
            {
                _image8.SetPixel(_blob.Rectangle.X, y, 0);
                _image8.SetPixel(_blob.Rectangle.Right, y, 0);
            }

            _recogimg.UnlockBits(imageData);
        }
    }
}
