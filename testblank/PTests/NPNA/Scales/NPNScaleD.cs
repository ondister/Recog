using System;
using System.Collections.Generic;
using Recog.Data;

namespace Recog.PTests.NPNA.Scales
{

    public class NPNScaleD : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private NPNAnswers _answers;
        private pBaseEntities _ge;
        public NPNScaleD(NPNAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала D"; }
        }

        public string Description
        {
            get { return "«Шкала достоверности»"; }
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

            List<int> ansyes = new List<int>() {  };
            List<int> ansno = new List<int>() { 1, 4, 6, 24, 25, 27, 47, 49, 50, 70, 72, 93, 112, 114, 137 };
            _mark = NPNMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            if (_mark >=10) { _sten = 10; }
            if (_mark ==9) { _sten = 9; }
            if (_mark ==8) { _sten = 8; }
            if (_mark >= 6 & _mark <= 7) { _sten = 7; }
            if (_mark >= 4 & _mark <= 5) { _sten = 6; }
            if (_mark ==3) { _sten = 5; }
            if (_mark ==2) { _sten = 4; }
            if (_mark ==1) { _sten = 3; }
            if (_mark ==0) { _sten = 2; }
            if (_mark ==0) { _sten = 1; }
        }

       public void GetLevel()
        {
            if (_sten <= 3) { _level = "Низкий"; }
            if (_sten >= 4 & _sten <= 7) { _level = "Средний"; }
            if (_sten >= 8) { _level = "Высокий"; }
        }
        public void GetResult()
        {

            if (_level == "Высокий") { _result = "Результаты теста не достоверны."; }
            else { _result = "Результаты теста достоверны."; }
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
