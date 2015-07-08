using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.D
{

    public class DScaleCS : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private DAnswers _answers;
        private pBaseEntities _ge;
        public DScaleCS(DAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала третьего уровня Cs"; }
        }

        public string Description
        {
            get { return "«Коммуникативные способности»"; }
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

            List<int> ansyes = new List<int>() { 9, 24, 27, 33,43, 46, 61, 64, 81, 88, 90, 99, 104, 106, 114, 121, 126, 133, 142, 151, 152 };
            List<int> ansno = new List<int>() { 26, 34, 35, 48, 74, 85, 107, 130, 144, 147, 159 };
           _mark = DMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            if (_mark==0) { _sten = 10; }
            if (_mark >= 1 & _mark <= 2) { _sten = 9; }
            if (_mark >= 3 & _mark <= 4) { _sten = 8; }
            if (_mark >= 5 & _mark <= 6) { _sten = 7; }
            if (_mark >=7 & _mark <= 9) { _sten = 6; }
            if (_mark >= 10 & _mark <= 12) { _sten = 5; }
            if (_mark >= 13 & _mark <= 16) { _sten = 4; }
            if (_mark >=17 & _mark <= 21) { _sten = 3; }
            if (_mark >= 22 & _mark <= 26) { _sten = 2; }
            if (_mark >=27) { _sten = 1; }
        }

       public void GetLevel()
        {
            if (_sten <= 3) { _level = "Низкий"; }
            if (_sten >= 4 & _sten <= 6) { _level = "Средний"; }
            if (_sten >= 7) { _level = "Высокий"; }
        }
        public void GetResult()
        {
            if (_level == "Низкий") { _result = "Низкий уровень развития коммуникативных способностей, затруднение в построении контактов с окружающими, проявление агрессивности, повышенная конфликтность."; }
            if (_level == "Средний") { _result = "Обладает средним уровнем развития коммуникативных способностей. Способен устанавливать контакты с сослуживцами. Не конфликтен."; }
            if (_level == "Высокий") { _result = "Высокий уровень коммуникативных способностей, легко устанавливает контакты с сослуживцами, окружающими, не конфликтен."; }
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
