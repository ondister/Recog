using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using AForge.Imaging;
using AForge.Imaging.Filters;
using Recog.RecogCore;

namespace Recog.RecogCore.AnswerGrid
{
    /// <summary>
    /// Ответ на бланке, содержащий коллекцию ячеек
    /// </summary>
    public class Answer
    {

        private Distances _firstcelldistances;
        private int _intercentresdistx;
        private int _cellscount;
        private int _cellsheight;
        private int _cellswidth;
        private string _contentdescription;
        private Cells _cells;
        private int _id;
        private bool _isempty;


        public bool IsEmpty
        {
            get { if (_cells.CrossCount == 0) { return true; } else { return false; } }//return _isempty; }

        }
        private bool _isdoublecross;

        public bool IsDoubleCross
        {
            get { return _isdoublecross; }

        }
        private bool _iswithmiss;

        public bool IsWithMiss
        {
            get { return _iswithmiss; }

        }
        private string _remarks;

        /// <summary>
        /// Возвращает замечания по распознованию ответа
        /// </summary>
        /// <value>
        /// Замечания
        /// </value>
        public string RecognitionRemarks
        {
            get
            {
                if (_isdoublecross == true) { return "Возможно отмечены несколько ячеек"; }
                else if (_isempty == true) { return "Возможно ни одной ячейки не отмечено"; }
                else if (_iswithmiss == true) { return "Возможно ответ содержит ячейку с ошибкой"; }
                else { return "Замечаний не выявлено"; }
            }
        }



        /// <summary>
        ///Возвращает число ячеек в ответе
        /// </summary>
        /// <value>
        /// Число ячеек
        /// </value>
        public int CellsCount
        {
            get { return _cellscount; }
        }

        /// <summary>
        /// Возвращает растояние в пикселях по оси X между центрами ячеек в ответе
        /// </summary>
        /// <value>
        /// Расстояние в пикселях
        /// </value>
        public int InterCentresDistX
        {
            get { return _intercentresdistx; }
        }


        /// <summary>
        /// Возвращает ширину ячеек
        /// </summary>
        /// <value>
        /// Ширина ячеек в пикселях
        /// </value>
        public int CellsWidth
        {
            get { return _cellswidth; }
        }


        /// <summary>
        ///Возвращает высоту ячеек
        /// </summary>
        /// <value>
        ///Высота ячеек в пикселях
        /// </value>
        public int CellsHeight
        {
            get { return _cellsheight; }
            set { _cellsheight = value; }
        }

        /// <summary>
        ///Возвращает коллекцию дистанций до первой ячейки ответа
        /// </summary>
        /// <value>
        /// Коллекция дистанция до первого ответа
        /// </value>
        public Distances FirstCellDistances
        {
            get { return _firstcelldistances; }
        }


        /// <summary>
        /// Возвращает и задает номер ответа 
        /// </summary>
        /// <value>
        /// Номер ответа
        /// </value>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// Инициализирует новый объект ответа на основе класса 
        /// </summary>
        /// <param name="image">Ссылка ни изображение</param>
        /// <param name="ID">Идентификатор</param>
        /// <param name="CellsCount">Количество ячеек для добавления в ответ </param>
        /// <param name="FirstCellDistances">Колекция дистанций от маркеров до первой ячейки</param>
        /// <param name="intercentresdistX">Расстояние между центрами ячеек</param>
        /// <param name="cellswidth">Длина ячеек</param>
        /// <param name="cellsheight">Высота ячеек</param>
        public Answer(Bitmap image, int ID, int CellsCount, Distances FirstCellDistances, int intercentresdistX, int cellswidth, int cellsheight)
        {
            _id = ID;
            _firstcelldistances = FirstCellDistances;
            _intercentresdistx = intercentresdistX;
            _cellscount = CellsCount;
            _cellsheight = cellsheight;
            _cellswidth = cellswidth;
            _contentdescription = string.Empty;
            _cells = new Cells();
            _isempty = false;
            _isdoublecross = false;
            _iswithmiss = false;
            _remarks = string.Empty;
            _cells.IntelligentAdd(image, CellsCount, FirstCellDistances, intercentresdistX, cellswidth, cellsheight);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Answer"/> class.
        /// </summary>
        public Answer() { _cells = new Cells(); }

        /// <summary>
        /// Возвращает описание ответа (описание ответа ячейки, содержащей true)
        /// </summary>
        /// <value>
        /// Описание ответа
        /// </value>
        public string ContentDescription
        {
            get { return _contentdescription; }
            set { _contentdescription = value; }
        }

        /// <summary>
        /// Возвращает коллекцию ячеек
        /// </summary>
        /// <value>
        /// Коллекция ячеек
        /// </value>
        public Cells Cells
        {
            get { return _cells; }
        }

       
        /// <summary>
        ///Распознает ответ и получает описание ответа с поиском ошибок заполнения
        /// </summary>
        public void GetContent(double mincross, double maxcross)
        {

            for (int i = 0, cnt = _cells.Count; i < cnt; i++)
            {
                _cells[i].GetContent(mincross, maxcross);
                if (_cells[i].Content == true) { _contentdescription = _cells[i].ContentDescription; }
            }
            if (_cells.CrossCount == 0) { _isempty = true; }
            if (_cells.CrossCount > 1) { _isdoublecross = true; }
            if (_cells.MissCount != 0) { _iswithmiss = true; }
            //варианты постобработки

            if (_isdoublecross == true)
            {
                _cells.SetTrueForMax();
            }
            if (_isempty == true & _iswithmiss == true)
            {
                _cells.SetTrueForMax();
            }

        }




        /// <summary>
        /// Выделяет все ячейки ответа
        /// </summary>
        public void Select()
        {
            for (int i = 0, cnt = _cells.Count; i < cnt; i++) { _cells[i].Select(); }
            _cells[0].SetLeftMarker();
            _cells[_cells.Count-1].SetRightMarker();
        }

        /// <summary>
        /// Выделяет ячейку с указанным описанием
        /// </summary>
        /// <param name="description">Описание ячейки</param>
        public void Select(string description)
        {
            for (int i = 0, cnt = _cells.Count; i < cnt; i++)
            {
                if (_cells[i].ContentDescription == description) { _cells[i].Select(); }
            }
        }

        /// <summary>
        /// Выделяет все ячейки белым цветом
        /// </summary>
        public void Clear()
        {
            for (int i = 0, cnt = _cells.Count; i < cnt; i++) { _cells[i].Clear(); }
            _cells[0].ClearLeftMarker();
            _cells[_cells.Count - 1].ClearRightMarker();
        }

        /// <summary>
        /// Выделяет все ячейки с ответом true
        /// </summary>
        public void SelectTrueCell()
        {
            for (int i = 0, cnt = _cells.Count; i < cnt; i++)
            {
                if (_cells[i].Content == true)
                { _cells[i].Select(); }
            }
        }

        /// <summary>
        /// Выделяет все ячейки с ответом false
        /// </summary>
        public void SelectFalseCell()
        {
            for (int i = 0, cnt = _cells.Count; i < cnt; i++)
            {
                if (_cells[i].Content == false)
                { _cells[i].Select(); }
            }
        }

        /// <summary>
        /// Возвращает индекс выделеной ячейки. Индекс начинается с 0
        /// </summary>
        /// <returns></returns>
        public int SelectedCellIndex()
        {
            int index = 0;
            for (int i = 0, cnt = _cells.Count; i < cnt; i++)
            {
                if (_cells[i].Content == true)
                { index = i + 1; break; }
            }
            return index;
        }

        /// <summary>
        /// Корректирует центр первой ячейки ответа
        /// </summary>
        /// <param name="image">ссылка на изображение</param>
        public void CorrectFirstCellCenter(Bitmap image)
        {

            //увеличиваем ячейки
            int maxWidth = _cellswidth + Convert.ToInt16(_cellswidth * 2 / 3);
            int maxHeigth = _cellsheight + Convert.ToInt16(_cellsheight * 2 / 3);
            _cells.ReMeasure(_firstcelldistances, _intercentresdistx, maxWidth, maxHeigth);
            BitmapData data = image.LockBits(_cells[0].Rect, ImageLockMode.ReadWrite, image.PixelFormat);
            BlobCounter blobCounter = new BlobCounter();

            Invert invertfilter = new Invert();
            invertfilter.ApplyInPlace(data);
            blobCounter.ProcessImage(data);

            Blob[] blobs = blobCounter.GetObjectsInformation();
            int maxar = 0;
            int b = 0;
            for (int i = 0; i < blobs.Count(); i++)
            {
                if (blobs[i].Area > maxar) { maxar = blobs[i].Area; b = i; }
            }
            invertfilter.ApplyInPlace(data);
            image.UnlockBits(data);


            System.Drawing.Point p = new System.Drawing.Point(_cells[0].CenterOfGravity.X - ((maxWidth / 2) - Convert.ToInt16(blobs[b].CenterOfGravity.X)), _cells[0].CenterOfGravity.Y - ((maxHeigth / 2) - Convert.ToInt16(blobs[b].CenterOfGravity.Y)));
            _cells.ReMeasure(p, _intercentresdistx, _cellswidth, _cellsheight);

        }

        public void ClearContent()
        {
            _cells.ClearContent();
            _isdoublecross = false;
            _isempty = false;
            _iswithmiss = false;
        }

    }
}
