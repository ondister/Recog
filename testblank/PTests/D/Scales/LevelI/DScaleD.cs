using System;
using System.Collections.Generic;
using Recog.Data;
namespace Recog.PTests.D
{

    public class DScaleD : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private DAnswers _answers;
        private pBaseEntities _ge;
        public DScaleD(DAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала первого уровня D"; }
        }

        public string Description
        {
            get { return "«Шкала депрессии»"; }
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

            List<int> ansyes = new List<int>() { 16, 17, 30, 39, 46 };
            List<int> ansno = new List<int>() { 5, 14, 23, 26, 27, 32, 34, 50, 52, 53, 54, 55, 67, 68, 77, 102 };
            _mark = DMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            List<int> Tmark = new List<int>() { 35, 39, 42, 45, 48, 51, 56, 58, 63, 65, 70, 74, 78, 80, 83, 86, 89, 92, 95, 98, 105, 110 };
            _sten = Tmark[(int)_mark];
        }

       public void GetLevel()
        {
            if (_sten <= 69) { _level = "Низкий"; }
            if (_sten >= 70) { _level = "Высокий"; }
        }
        public void GetResult()
        {

            if (_level == "Высокий") { _result = "Тенденция к сниженному фону настроения, неуверенности в своих силах, тревоге, повышенном чувстве вины, ослаблении волевого контроля. Признаки излишней сензитивности (повышенная чувствительность, обидчивость). Низкая толерантность (устойчивость) к психическим и физическим нагрузкам. Неспособность быстро принимать самостоятельные решения. При неудачах — склонность впадать в отчаяние."; }
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
