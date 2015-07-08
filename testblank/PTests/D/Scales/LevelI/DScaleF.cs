using System;
using System.Collections.Generic;
using Recog.Data;
namespace Recog.PTests.D
{

    public class DScaleF : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private DAnswers _answers;
        private pBaseEntities _ge;
        public DScaleF(DAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала первого уровня F"; }
        }

        public string Description
        {
            get { return "«Шкала надежности»"; }
        }

        public double Mark
        {
            get
            {
                 
                return _mark;
            }
            set { _mark = value;   }
        }

        public int Stens
        {
            get
            {
                 
                return _sten;
            }
            set { _sten = value; }
        }
        public string Level
        {

            get
            {
                 
                return _level;
            }
        }

        public string ResultDescription
        {
            get
            {
                 
                return _result;
            }
        }

        public void GetMark()
        {

            List<int> ansyes = new List<int>() { 4, 8, 11, 18, 20, 22, 37, 41, 47, 60, 72, 82, 84, 86, 91, 96, 98, 103, 115, 153 };
            List<int> ansno = new List<int>() { 2, 25, 43, 44, 53 };
            _mark = DMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            List<int> Tmark = new List<int>() { 32, 35, 38, 41, 44, 47, 50, 53, 56, 59, 62, 69, 73, 76, 79, 82, 85, 88, 91, 94, 97, 100, 103, 106, 109 };
            _sten = Tmark[(int)_mark];
        }

       public void GetLevel()
        {
            if (_sten <= 69) { _level = "Низкий"; }
            if (_sten >= 70) { _level = "Высокий"; }
        }
        public void GetResult()
        {

            if (_level == "Высокий") { _result = "Отмечается излишняя самокритичность. Тенденция к преувеличению существующих проблем, стремление подчеркнуть дефекты своего характера. Признаки отсутствия гармонии и психологического комфорта. Признаки защитных реакций: возможно, неосознанная попытка изобразить другое (выдуманное) лицо, а не свои личностные особенности. Повышенные значения по данной шкале, возможно, являются следствием излишней взволнованности при проведении процедур обследования."; }
            else { _result = "Без особенностей"; }
        }


        public List<string> MultiResult
        {
            get { throw new NotImplementedException(); }
        }

        public void GetMultiResult()
        {
            throw new NotImplementedException();
        }
    }
}
