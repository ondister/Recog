using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.FPI
{

    public class FPIScaleXI : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private FPIAnswers _answers;
        private pBaseEntities _ge;
        public FPIScaleXI(FPIAnswers FPIAnswers,pBaseEntities GlobalEntities)
        {
            _answers = FPIAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала XI"; }
        }

        public string Description
        {
            get { return "«Эмоциональная лабильность»"; }
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
            get {
                 
                return _sten;
            }
            set { _sten = value; }
        }
        public string Level
        {
             
            get {
                 
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

            List<int> ansyes = new List<int>() { 24, 25, 40, 48, 80, 83, 84, 85, 87, 88, 102, 112, 113 };
            List<int> ansno = new List<int>() { 59 };
            //ans.Add(i);
         
         _mark=   FPIMarkExtractor.GetMark(_ge, _answers, ansyes,ansno);
         this.GetSten();
         this.GetLevel();
         this.GetResult();
          

        }

       public void GetSten()
        {
            if ( _mark ==0) { _sten = 1; }
            if (_mark==1) { _sten = 2; }
            if (_mark ==2) { _sten = 3; }
            if (_mark >= 3 & _mark <= 4) { _sten = 4; }
            if (_mark == 5) { _sten = 5; }
            if (_mark ==6) { _sten = 6; }
            if (_mark >= 7 & _mark <= 8) { _sten = 7; }
            if (_mark >= 9 & _mark <= 11) { _sten = 8; }
            if (_mark >= 12 & _mark <= 14) { _sten = 9; }
          
            
        }

       public void GetLevel()
        {
            if (_sten >=1 & _sten <= 3) { _level = "Низкий"; }
            if (_sten >= 4 & _sten <= 6) { _level = "Средний"; }
            if (_sten >= 7 & _sten <= 9) { _level = "Высокий"; }
        }
        public void GetResult()
        {

            if (_level == "Высокий") { _result = "Высокие оценки указывают на неустойчивость эмоционального состояния, проявляющуюся в частых колебаниях настроения, повышенной возбудимости, раздражительности, недостаточной саморегуляции."; }
            if (_level == "Низкий") { _result = "Низкие оценки могут характеризовать не только высокую стабильность эмоционального состояния как такового, но и хорошее умение владеть собой."; }
            if (_level == "Средний") { _result = "Без особенностей"; }
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
