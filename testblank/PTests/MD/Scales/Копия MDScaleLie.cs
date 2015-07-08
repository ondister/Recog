using System;
using System.Collections.Generic;
using Recog.Data;
namespace Recog.PTests.MD.Scales
{

    public class MDScaleLie : IScale
    {
        private int _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private MDAnswers _answers;
        private pBaseEntities _ge;
        private int _ages;
        public MDScaleLie(MDAnswers mdAnswers, pBaseEntities GlobalEntities,int ages)
        {
            _answers = mdAnswers;
            _ge = GlobalEntities;
            _ages = ages;
        }
        public string Name
        {
            get { return "Шкала лжи"; }
        }

        public string Description
        {
            get { return "«Достоверность результатов»"; }
        }

        public int Mark
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

            List<int> ans = new List<int>() { 1,16,29,45,51,55,61,67,72,81,91,101,119};
            _mark = MDMarkExtractor.GetMark(_ge, _answers, ans);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            if (_ages <= 24)
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
            else
            {
                if (_mark ==13 | _mark==12) { _sten = 1; }
                if (_mark == 11 |_mark==10) { _sten = 2; }
                if (_mark == 9|_mark==8) { _sten = 3; }
                if (_mark == 7) { _sten = 4; }
                if (_mark == 6 |_mark == 5) { _sten = 5; }
                if (_mark ==4) { _sten = 6; }
                if (_mark == 3) { _sten = 7; }
                if (_mark == 2) { _sten = 8; }
                if (_mark == 1) { _sten = 9; }
                if (_mark == 0) { _sten = 10; }
            }
        }

       public void GetLevel()
        {
            if (_sten == 1 &  _sten <= 2) { _level = "4 группа НПУ"; }
            if (_mark >= 3 & _mark <= 4) { _level = "3 группа НПУ"; }
            if (_mark >= 5 & _mark <= 7) { _level = "2 группа НПУ"; }
            if (_mark >= 8 & _mark <= 10) { _level = "1 группа НПУ"; }
            
        }
        public void GetResult()
        {

            if (_mark>=10) { _result = "Результаты теста недостоверны"; }
            else { _result = "Результаты теста достоверны"; }
        }
    }
}
