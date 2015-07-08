using System.Collections.Generic;
using Recog.RecogCore;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Imaging;
using AForge.Imaging.Filters;
using System.Linq;
using System;
namespace Recog.RecogCore.AnswerGrid
{
    /// <summary>
    /// Коллекция ячеек
    /// </summary>
    public class Cells
    {
        private List<Cell> _cells;

        public int FreeCount
        {
            get { return _cells.Count(c => c.NeuroContent == CellContent.Free); }
        }

        public int CrossCount
        {
            get { return _cells.Count(c => c.NeuroContent == CellContent.Cross); }
        }
        public int MissCount
        {
            get { return _cells.Count(c => c.NeuroContent == CellContent.Miss); }
        }

       
        /// <summary>
        /// Инициализирует новый объект класса <see cref="Cells"/> 
        /// </summary>
        public Cells()
        { _cells = new List<Cell>(); }

        /// <summary>
        ///Возвращает и получает ячейку <see cref="Cell"/> из коллекции по указанному индексу
        /// </summary>
        /// <value>
        /// The <see cref="Cell"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Cell this[int index]
        {
            get
            {
                return _cells[index];
            }
            set
            {
                _cells[index] = value;
            }
        }

        /// <summary>
        ///Возвращает число ячеек в коллекции
        /// </summary>
        /// <value>
        /// Число ячеек
        /// </value>
        public int Count { get { return _cells.Count; } }

        /// <summary>
        /// Добавляет ячейку в коллекцию
        /// </summary>
        /// <param name="cell">Ячейка</param>
        public void Add(Cell cell)
        {
            _cells.Add(cell);
        }

        /// <summary>
        /// Добавляет несколько ячеек в коллекцию ячеек
        /// </summary>
        /// <param name="image">Ссылка на изображение</param>
        /// <param name="CellsCount">Число ячеек для добавления</param>
        /// <param name="FirstCellDistanses">Коллекция дистанций до первой ячейки коллекции</param>
        /// <param name="intercentresdistX">Расстояние в пикселях между сентрами ячеек</param>
        /// <param name="Width">Ширина ячеек</param>
        /// <param name="Height">Высота ячеек</param>
        /// <exception cref="Exception">Количество ячеек должно быть больше нуля</exception>
        public void Add(Bitmap image, int CellsCount, Distances FirstCellDistanses,int intercentresdistX, int Width, int Height)
    {
        if (CellsCount > 0)
        {
            //находим первую доступную дистанцию
           Distance d= FirstCellDistanses.FindOneGood();
            //делаем первую ячейку
           Cell c1 = new Cell(image, d.GetsCenterOfGravity, Width, Height);
           this.Add(c1);
            //делаем остальные ячейки
            for (int i = 1; i < CellsCount; i++)
            {
                Point p=new Point(_cells[i-1].CenterOfGravity.X+intercentresdistX,_cells[i-1].CenterOfGravity.Y);
                Cell c = new Cell(image, p, Width, Height);
                this.Add(c);
            }
        }
        else { throw new Exception("Количество ячеек доблжно быть больше нуля"); }
    }

        /// <summary>
        /// Добавляет несколько несколько ячеек в ответ начиная с первой
        /// </summary>
        /// <param name="image">Ссылка ни изображение</param>
        /// <param name="CellsCount">Количество ячеек для добавления в ответ</param>
        /// <param name="FirstCellDistanses">Коллекция дистанций между первой ячейкой и маркерами</param>
        /// <param name="intercentresdistX">Расстояние между центрами ячеек</param>
        /// <param name="Width">Длина ячеек</param>
        /// <param name="Height">Высота ячеек</param>
        public void IntelligentAdd(Bitmap image, int CellsCount, Distances FirstCellDistanses, int intercentresdistX, int Width, int Height)
        {
            int maxslice = intercentresdistX/2;

            //находим первую доступную дистанцию
            Distance d = FirstCellDistanses.FindOneGood();
            int maxWidth = Width +  Convert.ToInt16(Width/2);
            int maxHeigth = Height + Convert.ToInt16(Height/2);
            //увеличиваем ячейки
          
            this.Add(image,CellsCount,FirstCellDistanses,intercentresdistX,maxWidth,maxHeigth);


            BitmapData data = image.LockBits(_cells[0].Rect, ImageLockMode.ReadWrite, image.PixelFormat);
            BlobCounter blobCounter = new BlobCounter();

            Invert invertfilter = new Invert();
            invertfilter.ApplyInPlace(data);
            blobCounter.ProcessImage(data);

            Blob[] blobs = blobCounter.GetObjectsInformation();
            if (blobs.Length != 0)
            {
                int maxar = 0;
                int b = 0;
                for (int i = 0; i < blobs.Count(); i++)
                {
                    if (blobs[i].Area > maxar) { maxar = blobs[i].Area; b = i; }
                }
                invertfilter.ApplyInPlace(data);
               

                System.Drawing.Point p = new System.Drawing.Point(_cells[0].CenterOfGravity.X - ((maxWidth / 2) - Convert.ToInt16(blobs[b].CenterOfGravity.X)), _cells[0].CenterOfGravity.Y - ((maxHeigth / 2) - Convert.ToInt16(blobs[b].CenterOfGravity.Y)));
                if (Math.Abs(_cells[0].CenterOfGravity.Y - p.Y) <= maxslice) { this.ReMeasure(p, intercentresdistX, Width, Height); }
                else { this.ReMeasure(_cells[0].CenterOfGravity, intercentresdistX, Width, Height); }
            }
            image.UnlockBits(data);
        }



        /// <summary>
        /// Изменяет положение и размер ячейки
        /// </summary>
        /// <param name="FirstCellDistanses">Коллекция дистнаций до ячейки</param>
        /// <param name="intercentresdistX">Расстояние между центрами ячеек</param>
        /// <param name="Width">Длина ячейки</param>
        /// <param name="Height">Высота ячейки</param>
        public void ReMeasure(Distances FirstCellDistanses, int intercentresdistX, int Width, int Height)
        {
            
            //делаем первую ячейку
             Distance d= FirstCellDistanses.FindOneGood();
             Rectangle rect = new Rectangle(_cells[0].Rect.X, _cells[0].Rect.Y, Width, Height);
             _cells[0].Rect = rect;
             _cells[0].CenterOfGravity = d.GetsCenterOfGravity;
            
            //делаем остальные ячейки
            for (int i = 1; i <Count; i++)
            {
                Point p = new Point(_cells[i - 1].CenterOfGravity.X + intercentresdistX, _cells[i - 1].CenterOfGravity.Y);
                rect = new Rectangle(_cells[i].Rect.X, _cells[i].Rect.Y, Width, Height);
                _cells[i].Rect = rect;
                _cells[i].CenterOfGravity = p;

            }
        }

        /// <summary>
        /// Изменяет положение и размер ячейки
        /// </summary>
        /// <param name="CenterOfGravity">Центр ячейки</param>
        /// <param name="intercentresdistX">Расстояние между центрами ячеек</param>
        /// <param name="Width">Длина ячейки</param>
        /// <param name="Height">Высота ячейки</param>
        public void ReMeasure(Point CenterOfGravity, int intercentresdistX, int Width, int Height)
        {

            //делаем первую ячейку
            Rectangle rect = new Rectangle(_cells[0].Rect.X, _cells[0].Rect.Y, Width, Height);
            _cells[0].Rect = rect;
            _cells[0].CenterOfGravity = CenterOfGravity;

            //делаем остальные ячейки
            for (int i = 1; i < Count; i++)
            {
                Point p = new Point(_cells[i - 1].CenterOfGravity.X + intercentresdistX, _cells[i - 1].CenterOfGravity.Y);
                rect = new Rectangle(_cells[i].Rect.X, _cells[i].Rect.Y, Width, Height);
                _cells[i].Rect = rect;
                _cells[i].CenterOfGravity = p;
            }
        }
        
        public void SetTrueForMax()
        {
            int c = 0;
            double max = 0;
            for (int i = 0; i < _cells.Count; i++)
            {
                _cells[i].Content = false;
                if (_cells[i].BritnessDispertion >= max) { max = _cells[i].BritnessDispertion; c = i; }
            }
            _cells[c].Content = true;
            _cells[c].NeuroContent = CellContent.Cross;
        }

        public void ClearContent()
        { for (int i = 0; i < _cells.Count; i++) { _cells[i].ClearContent(); } }

    }
}
