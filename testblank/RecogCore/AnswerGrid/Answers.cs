using System.Collections.Generic;
using Recog.RecogCore;
using System.Drawing;
using System.Linq;
namespace Recog.RecogCore.AnswerGrid
{




    /// <summary>
    /// Инкапсулирует коллекцию ответов
    /// </summary>
    public class Answers
    {

        private List<Answer> _answers;
        public int CountWithMiss
        {
            get {
                                 return _answers.Count(a => a.IsWithMiss == true); 
            }
        }
        public int CountWithDoubleCross
        {
            get {
                return _answers.Count(a => a.IsDoubleCross == true); 
            }
        }
        public int CountWithEmpty
        {
            get { 
                return _answers.Count(a => a.IsEmpty == true); 
            }
        }
        /// <summary>
        /// Инициализирует новую коллекцию ответов
        /// </summary>
        public Answers()
        { _answers = new List<Answer>(); }

        /// <summary>
        /// Добавляет ответ в коллекцию
        /// </summary>
        /// <param name="answer">Ответ</param>
        public void Add(Answer answer)
        {
            _answers.Add(answer);
        }

        /// <summary>
        /// Добавляет ответ в коллекцию на основе данных о ячейках
        /// </summary>
        /// <param name="image">Ссылка на изображение</param>
        /// <param name="ID">Идентификатор ответа</param>
        /// <param name="CellsCount">Число ячеек</param>
        /// <param name="FirstCellDistances">Коллекция расстояний до превой ячейки</param>
        /// <param name="intercentresdistX">Расстояние между сетнтрами ячеек в пискселях</param>
        /// <param name="cellswidth">Ширина ячеек</param>
        /// <param name="cellsheight">Высота ячеек</param>
        public void Add(Bitmap image, int ID, int CellsCount, Distances FirstCellDistances, int intercentresdistX, int cellswidth, int cellsheight)
        {
            Answer a = new Answer(image, ID, CellsCount, FirstCellDistances, intercentresdistX, cellswidth, cellsheight);
            this.Add(a);
        }

        /// <summary>
        /// Возращает ответ из коллекции по указанному индексу
        /// </summary>
        /// <value>
        /// Ответ 
        /// </value>
        /// <param name="index">Индекс</param>
        /// <returns></returns>
        public Answer this[int index]
        {
            get { return _answers[index]; }
            set { _answers[index] = value; }
        }

        /// <summary>
        /// Возвращает количество ответов в коллекции
        /// </summary>
        /// <value>
        /// Количество ответов
        /// </value>
        public int Count { get { return _answers.Count; ;} }


        /// <summary>
        /// Запускает распознавание всех ответов
        /// </summary>
        public void GetContent(double mincross, double maxcross)
        {
            for (int i = 0, cnt = _answers.Count; i < cnt; i++) { _answers[i].GetContent(mincross, maxcross); }
        }



        /// <summary>
        /// Выделяет все ответы
        /// </summary>
        public void Select()
        {
            for (int i = 0, cnt = _answers.Count; i < cnt; i++) { _answers[i].Select(); }
        }

        /// <summary>
        /// Выделяет все ответы белвм цветом
        /// </summary>
        public void Clear()
        {
            for (int i = 0, cnt = _answers.Count; i < cnt; i++) { _answers[i].Clear(); }
        }
        /// <summary>
        /// Выделяет все ячейки с ответом true во всех ответах
        /// </summary>
        public void SelectTrueCell()
        {
            for (int i = 0, cnt = _answers.Count; i < cnt; i++) { _answers[i].SelectTrueCell(); }
        }

        /// <summary>
        /// Выделяет все ячейки с ответом false во всех ответах
        /// </summary>
        public void SelectFalseCell()
        {
            for (int i = 0, cnt = _answers.Count; i < cnt; i++) { _answers[i].SelectFalseCell(); }
        }

        /// <summary>
        /// Возвращает максимальную разницу яркостей
        /// </summary>
        /// <returns></returns>
        public double FindMaxDisp()
        {
            double d = 0;
            for (int a = 0; a < _answers.Count; a++)
            {
                for (int c = 0; c < _answers[a].Cells.Count; c++)
                {
                    if (_answers[a].Cells[c].NeuroContent == CellContent.Cross)
                    {
                        if (_answers[a].Cells[c].BritnessDispertion > d) { d = _answers[a].Cells[c].BritnessDispertion; }
                    }
                }
            }

            return d;
        }

        /// <summary>
        /// Возвращает минимальную разницу яркостей
        /// </summary>
        /// <returns></returns>
        public double FindMinDisp()
        {
            double d = 1;
            for (int a = 0; a < _answers.Count; a++)
            {
                for (int c = 0; c < _answers[a].Cells.Count; c++)
                {
                    if (_answers[a].Cells[c].NeuroContent == CellContent.Cross)
                    {
                        if (_answers[a].Cells[c].BritnessDispertion < d) { d = _answers[a].Cells[c].BritnessDispertion; }
                    }
                }
            }



            return d;
        }

        public void ClearContent()
        {
            for (int i = 0; i < _answers.Count; i++)
            {
                _answers[i].ClearContent();

            }

        }

        /// <summary>
        /// Возвращает индекс ответа в массиве к которому принадлежат координаты
        /// </summary>
        /// <param name="clickpoint">Координаты</param>
        /// <returns></returns>
        public int GetAnswerIndex(Point clickpoint)
        {
            int i = -1;
            for (int a = 0; a < _answers.Count; a++)
            {
                for (int c = 0; c < _answers[a].Cells.Count; c++)
                {
                    if (_answers[a].Cells[c].Rect.Contains(clickpoint))
                    {
                        i = a;
                        break;
                    }
                }
            }
            return i;
        }

        /// <summary>
        /// Возвращает описание ячейки по координатам
        /// </summary>
        /// <param name="clickpoint">Координаты</param>
        /// <returns></returns>
        public string GetCellDescription (Point clickpoint)
        {
           string s= "-1";
            for (int a = 0; a < _answers.Count; a++)
            {
                for (int c = 0; c < _answers[a].Cells.Count; c++)
                {
                    if (_answers[a].Cells[c].Rect.Contains(clickpoint))
                    {
                        s = _answers[a].Cells[c].ContentDescription;
                        break;
                    }
                }
            }
            return s;
        }

        /// <summary>
        /// Возвращает индекс ячейки по координатам
        /// </summary>
        /// <param name="clickpoint">Координаты</param>
        /// <returns></returns>
        public int GetCellIndex(Point clickpoint)
        {
           int i = -1;
            for (int a = 0; a < _answers.Count; a++)
            {
                for (int c = 0; c < _answers[a].Cells.Count; c++)
                {
                    if (_answers[a].Cells[c].Rect.Contains(clickpoint))
                    {
                        i = c;
                        break;
                    }
                }
            }
            return i;
        }

    }
}
