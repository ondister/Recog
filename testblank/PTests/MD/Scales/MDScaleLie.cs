using System;
using System.Collections.Generic;
using Recog.Data;
using System.Linq;
namespace Recog.PTests.MD.Scales
{

    public class MDScaleLie : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private MDAnswers _answers;
        private pBaseEntities _ge;
        private List<int> _ans;
        private List<string> _multiresult;
        public MDScaleLie(MDAnswers mdAnswers, pBaseEntities GlobalEntities)
        {
            _answers = mdAnswers;
            _ge = GlobalEntities;

        }
        public string Name
        {
            get { return "Шкала лжи"; }
        }

        public string Description
        {
            get { return "«Достоверность результатов»"; }
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

            _ans = new List<int>() { 1,18,34,54,61,66,74,81,87,97,108,119,139};
            _mark = MDMarkExtractor.GetMark(_ge, _answers, _ans);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
            this.GetMultiResult();

        }

       public void GetSten()
        {
        
                if (_mark == 13) { _sten = 1; }
                if (_mark == 12) { _sten = 2; }
                if (_mark == 11) { _sten = 3; }
                if (_mark == 10) { _sten = 4; }
                if (_mark <= 9 & _mark >= 7) { _sten = 5; }
                if (_mark <= 6 & _mark >= 4) { _sten = 6; }
                if (_mark == 3) { _sten = 7; }
                if (_mark == 2) { _sten = 8; }
                if (_mark == 1) { _sten = 9; }
                if (_mark == 0) { _sten = 10; }
          
        }

       public void GetLevel()
        {
            if (_sten >= 1 & _sten <= 3) { _level = "Неудовлетворительный уровень НПУ"; }
            if (_sten >= 4 & _sten <= 5) { _level = "Удовлетворительный уровень НПУ"; }
            if (_sten >= 6 & _sten <= 8) { _level = "Хороший уровень НПУ"; }
            if (_sten >= 9 & _sten <= 10) { _level = "Высокий уровень НПУ"; }
        }
        public void GetResult()
        {

            if (_mark>=10) { _result += "Результаты теста недостоверны "; }
            else { _result = "Результаты теста достоверны "; }
        }




        public List<string> MultiResult
        {
            get { return _multiresult; }
        }

        public void GetMultiResult()
        {
            _multiresult = new List<string>();
            if (_mark >= 10) { _multiresult.Add("Результаты теста недостоверны "); }
            else { _multiresult.Add("Результаты теста достоверны "); }
        }
    }
}
