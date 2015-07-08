using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Recog.RecogCore
{
    /// <summary>
    /// Дистанция от центра маркера до центра первой ячейки
    /// </summary>
    public class Distance
    {
        private Marker _marker;
        private double _onx;
        private double _ony;
        private Point _getscenterofgravity;

        /// <summary>
        /// Инициализирует новый объект дистанции на основе класса
        /// </summary>
        /// <param name="marker">Маркер от которого считаем дистанцию</param>
        /// <param name="onx">Дистанция по оси X  в пикселях</param>
        /// <param name="ony">Дистанция по оси Y в пикселях</param>
        public Distance(Marker marker, double onx, double ony)
        {
            _marker = marker;
            _onx = onx;
            _ony = ony;
            _getscenterofgravity = new Point();
        }

        /// <summary>
        /// Возвращает центр тяжести рассчитанный на основе дистанций от маркера
        /// </summary>
        /// <value>
        /// Центр тяжести
        /// </value>
        public Point GetsCenterOfGravity
        {
            get
            {
                double X = 0;
                double Y = 0;
                
                        X = _marker.Blob.CenterOfGravity.X + _onx;
                        Y = _marker.Blob.CenterOfGravity.Y + _ony;
                                    
                _getscenterofgravity.X = Convert.ToInt16(X);
                _getscenterofgravity.Y = Convert.ToInt16(Y);
                return _getscenterofgravity;

            }
        }

        /// <summary>
        /// Получает маркер
        /// </summary>
        /// <value>
        ///Маркер
        /// </value>
        public Marker Marker
        {
            get { return _marker; }
        }

        /// <summary>
        /// Возвращает расстояние по оси X
        /// </summary>
        /// <value>
        /// Расстояние по оси X в миллиметрах
        /// </value>
        public double OnX
        {
            get { return _onx; }
        }

        /// <summary>
        /// Возвращает расстояние по оси Y
        /// </summary>
        /// <value>
        /// Расстояние по оси Y в миллиметрах
        /// </value>
        public double OnY
        {
            get { return _ony; }
        }
    }



    /// <summary>
    /// Коллекция дистанций
    /// </summary>
    public class Distances
    {
        private List<Distance> _distanses;
        private int _xpositiononimage;
        private int _ypositiononimage;

        /// <summary>
        /// Возвращает координату X точки для которой рассчитываются дистанции
        /// </summary>
        /// <value>
        ///Координата X на изображении
        /// </value>
        public int XPositionOnImage
        {
            get { return _xpositiononimage; }
        }


        /// <summary>
        /// Возвращает координату Y точки для которой рассчитываются дистанции
        /// </summary>
        /// <value>
        /// Координата Y на изображении
        /// </value>
        public int YPositionOnImage
        {
            get { return _ypositiononimage; }
        }


        /// <summary>
        /// Возвращает и задает дистанцию по индексу
        /// /// </summary>
        /// <value>
        /// Дистанция <see cref="Distance"/>.
        /// </value>
        /// <param name="index">Индекс</param>
        /// <returns></returns>
        public Distance this[int index]
        {
            get { return _distanses[index]; }
            set { _distanses[index] = value; }
        }


        /// <summary>
        /// Возвращает число дистанций в коллекции
        /// </summary>
        /// <value>
        /// Число дистанций
        /// </value>
        public int Count { get { return _distanses.Count; } }

        /// <summary>
        /// Инициализирует новую коллекцию дистанций
        /// </summary>
        public Distances()
        {
            _distanses = new List<Distance>();
            _xpositiononimage = 0;
            _ypositiononimage = 0;
        }

        /// <summary>
        ///Добавляет новую дистанцию в коллекцию
        /// </summary>
        /// <param name="marker">Маркер</param>
        /// <param name="onx">Расстояние по оси X  в пикселях</param>
        /// <param name="ony">Расстояние по оси Y  в пикселях</param>
        public void Add(Marker marker, double onx, double ony)
        {
            Distance nd = new Distance(marker, onx, ony);
            _distanses.Add(nd);
        }

        /// <summary>
        /// Добавляет новую дистанцию в коллекцию
        /// </summary>
        /// <param name="distance">Дистанция</param>
        public void Add(Distance distance)
        {
            _distanses.Add(distance);
        }

        /// <summary>
        /// Добавляет новую дистанцию в коллекцию
        /// </summary>
        /// <param name="marker">Маркер</param>
        /// <param name="XpositionOnImage">Координата X центра ячейки на изображении</param>
        /// <param name="YpositionOnImage">Координата Y центра ячейки на изображении</param>
        public void Add(Marker marker, int XpositionOnImage, int YpositionOnImage)
        {
            _xpositiononimage = XpositionOnImage;
            _ypositiononimage = YPositionOnImage;
            this.Add(marker, XpositionOnImage - marker.Blob.CenterOfGravity.X, YpositionOnImage - marker.Blob.CenterOfGravity.Y);
        }

        /// <summary>
        /// Ищет первую дистанцию с известным маркером в коллекции
        /// </summary>
        /// <returns>Первая дистанция с известным маркером в коллкции</returns>
        /// <exception cref="Exception">
        /// Отсутствуют известные маркеры в коллекции
        /// or
        /// Отсутствуют дистанции в коллекции
        /// </exception>
        public Distance FindOneGood()
        {
            Distance d = null;
            if (_distanses.Count != 0)
            {
                //d = _distanses.FirstOrDefault(distance => distance.Marker.Blob.Fullness == _distanses.Max(dst=>dst.Marker.Blob.Fullness));

                for (int i = 0; i < _distanses.Count; i++)
                {
                    if (_distanses[i].Marker != null)
                    {
                        d = _distanses[i];
                        break;
                    }
                }
                if (d == null) { throw new Exception("Отсутствуют известные маркеры в коллекции"); }
            }
            else { throw new Exception("Отсутствуют дистанции в коллекции"); }

            return d;
        }
    }
}
