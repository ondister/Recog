using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Recog.RecogCore;
using AForge.Imaging;
using AForge.Math;
using System.Drawing.Imaging;
using AForge;
using System;
namespace Recog.RecogCore.AnswerGrid
{


    public enum CellContent { Cross = 1, Free = 2, Miss = 3 }

    /// <summary>
    /// Инкапсулирует ячейку с ответом
    /// </summary>
    public class Cell
    {

        private double _britnessdispertion;

        public double BritnessDispertion
        {
            get { return _britnessdispertion; }
        }
        public Histogram histogram;

        private CellContent _neurocontent;
        private bool _content;
        private string _contentdescription;
        private Rectangle _rect;
        private System.Drawing.Point _centerofgravity;
        private UnmanagedImage _image8;
        private Bitmap _parentimage;

        public CellContent NeuroContent
        { get { return _neurocontent; } set { _neurocontent = value; } }



        /// <summary>
        /// Получает и возвращает описание ответа ячейки
        /// </summary>
        /// <value>
        /// Описание ответа ячейки
        /// </value>
        public string ContentDescription
        {
            get { return _contentdescription; }
            set { _contentdescription = value; }
        }

        /// <summary>
        /// Возвращает и получает центр тяжести ячейки
        /// </summary>
        /// <value>
        /// Центр тяжести
        /// </value>
        public System.Drawing.Point CenterOfGravity
        {
            get { return _centerofgravity; }
            set
            {
                _centerofgravity = value;
                int x = _centerofgravity.X - (_rect.Width / 2);
                int y = _centerofgravity.Y - (_rect.Height / 2);
                _rect = new Rectangle(x, y, _rect.Height, _rect.Height);
            }
        }

        /// <summary>
        /// Возвращает квадрат ячейки
        /// </summary>
        /// <value>
        /// Квадрат ячейки
        /// </value>
        public Rectangle Rect
        {
            get { return _rect; }
            set { _rect = value; }
        }

        /// <summary>
        /// Указывает, содержится ли ответ в ячейке
        /// </summary>
        /// <value>
        ///   <c>true</c> если ответ содержится; в противном случае <c>false</c>.
        /// </value>
        public bool Content
        {
            get { return _content; }
            set { _content = value; }
        }


        /// <summary>
        /// Инициализирует объект на основе класса <see cref="Cell"/> 
        /// </summary>
        /// <param name="Image">Ссылка на родительское изображение</param>
        /// <param name="centerofgravity">Центр тяжести ячейки</param>
        /// <param name="Width">Ширина в пикселях</param>
        /// <param name="Height">Высота в пикселях</param>
        public Cell(Bitmap Image, System.Drawing.Point centerofgravity, int Width, int Height)
        {
            _centerofgravity = centerofgravity;
            int x = _centerofgravity.X - (Width / 2);
            int y = _centerofgravity.Y - (Height / 2);
            _rect = new Rectangle(x, y, Height, Height);
            _parentimage = Image;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        public Cell() { }


        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <param name="mincross">Минимальная разница яркости ячейки с кретсиком</param>
        /// <param name="maxcross">Максимальная разница яркости ячейки с кретсиком</param>
        public void GetContent(double mincross, double maxcross)
        {
             _content = false;
            _neurocontent = CellContent.Free;

            List<double> _lrange = new List<double>();
            BitmapData data = _parentimage.LockBits(_rect, ImageLockMode.ReadWrite, _parentimage.PixelFormat);
            VerticalIntensityStatistics vis = new VerticalIntensityStatistics(data);
            histogram = vis.Gray;


            HorizontalIntensityStatistics his = new HorizontalIntensityStatistics(data);
            Histogram hhistogram = his.Gray;
            List<double> _hrange = new List<double>();


            _parentimage.UnlockBits(data);

            for (int i = 8; i <= 15; i++)
            {
                _lrange.Add((histogram.Values[i]+hhistogram.Values[i])/2);
               // _hrange.Add(hhistogram.Values[i]);
            }
          // _britnessdispertion = (1 - RecogCore.Statistics.Mean(_lrange) / histogram.Values.Max()) + (1 - RecogCore.Statistics.Mean(_hrange) / hhistogram.Values.Max());
            _britnessdispertion = 1 - RecogCore.Statistics.Mean(_lrange) / histogram.Values.Max();
            if (_britnessdispertion <= mincross) { _neurocontent = CellContent.Free; _content = false; }
            if (_britnessdispertion > mincross & _britnessdispertion <= maxcross) { _neurocontent = CellContent.Cross; _content = true; }
            if (_britnessdispertion > maxcross) { _neurocontent = CellContent.Miss; _content = false; }

        }

     


        /// <summary>
        /// Выделяет ячейку черным квадратом на родительском изображении
        /// </summary>
        public void Select()
        {
            BitmapData imageData = _parentimage.LockBits(
          new Rectangle(0, 0, _parentimage.Width, _parentimage.Height),
          ImageLockMode.ReadWrite, _parentimage.PixelFormat);

            _image8 = new UnmanagedImage(imageData);
            for (int x = _rect.X; x <= _rect.Right; x++)
            {
                _image8.SetPixel(x, _rect.Y, 0);
                _image8.SetPixel(x, _rect.Bottom, 0);
            }
            for (int y = _rect.Y; y <= _rect.Bottom; y++)
            {
                _image8.SetPixel(_rect.X, y, 0);
                _image8.SetPixel(_rect.Right, y, 0);
            }

            _parentimage.UnlockBits(imageData);

        }

        /// <summary>
        /// Рисует темный квадрат на расстоянии 5 пикселей от ячейки слева
        /// </summary>
        public void SetLeftMarker()
        {
            BitmapData imageData = _parentimage.LockBits(
       new Rectangle(0, 0, _parentimage.Width, _parentimage.Height),
       ImageLockMode.ReadWrite, _parentimage.PixelFormat);

            _image8 = new UnmanagedImage(imageData);
            for (int x = _rect.X - 5; x <= _rect.X; x++)
            {
                for (int y = _rect.Y; y <= _rect.Y + _rect.Height; y++)
                { _image8.SetPixel(x, y, 0); }
            }

            _parentimage.UnlockBits(imageData);
        }

        /// <summary>
        /// Удаляет темный квадрат на расстоянии 5 пикселей от ячейки слева
        /// </summary>
        public void ClearLeftMarker()
        {
            BitmapData imageData = _parentimage.LockBits(
       new Rectangle(0, 0, _parentimage.Width, _parentimage.Height),
       ImageLockMode.ReadWrite, _parentimage.PixelFormat);

            _image8 = new UnmanagedImage(imageData);
            for (int x = _rect.X - 5; x <= _rect.X; x++)
            {
                for (int y = _rect.Y; y <= _rect.Y + _rect.Height; y++)
                { _image8.SetPixel(x, y, 255); }
            }

            _parentimage.UnlockBits(imageData);
        }

        /// <summary>
        /// Рисует темный квадрат на расстоянии 5 пикселей от ячейки справа
        /// </summary>
        public void SetRightMarker()
        {
            BitmapData imageData = _parentimage.LockBits(
       new Rectangle(0, 0, _parentimage.Width, _parentimage.Height),
       ImageLockMode.ReadWrite, _parentimage.PixelFormat);

            _image8 = new UnmanagedImage(imageData);
            for (int x = _rect.X + _rect.Width; x <= _rect.X + _rect.Width + 5; x++)
            {
                for (int y = _rect.Y; y <= _rect.Y + _rect.Height; y++)
                { _image8.SetPixel(x, y, 0); }
            }

            _parentimage.UnlockBits(imageData);
        }

        /// <summary>
        /// Удаляет темный квадрат на расстоянии 5 пикселей от ячейки справа
        /// </summary>
        public void ClearRightMarker()
        {
            BitmapData imageData = _parentimage.LockBits(
       new Rectangle(0, 0, _parentimage.Width, _parentimage.Height),
       ImageLockMode.ReadWrite, _parentimage.PixelFormat);

            _image8 = new UnmanagedImage(imageData);
            for (int x = _rect.X + _rect.Width; x <= _rect.X + _rect.Width + 5; x++)
            {
                for (int y = _rect.Y; y <= _rect.Y + _rect.Height; y++)
                { _image8.SetPixel(x, y, 255); }
            }

            _parentimage.UnlockBits(imageData);
        }


        /// <summary>
        /// Рисует вокруг ячейки рамку белого цвета
        /// </summary>
        public void Clear()
        {

            BitmapData imageData = _parentimage.LockBits(
   new Rectangle(0, 0, _parentimage.Width, _parentimage.Height),
   ImageLockMode.ReadWrite, _parentimage.PixelFormat);

            _image8 = new UnmanagedImage(imageData);
            for (int x = _rect.X; x <= _rect.Right; x++)
            {
                _image8.SetPixel(x, _rect.Y, 255);
                _image8.SetPixel(x, _rect.Bottom, 255);
            }
            for (int y = _rect.Y; y <= _rect.Bottom; y++)
            {
                _image8.SetPixel(_rect.X, y, 255);
                _image8.SetPixel(_rect.Right, y, 255);
            }

            _parentimage.UnlockBits(imageData);
        }

        public void ClearContent()
        {
            this.NeuroContent = CellContent.Free;
            this.Content = false;
        }

    }
}
