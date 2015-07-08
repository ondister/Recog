using System;
using System.Collections.Generic;
using Recog.Data;

namespace Recog.PTests.NPNA.Scales
{

    public class NPNScalePp : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private NPNAnswers _answers;
        private pBaseEntities _ge;
        public NPNScalePp(NPNAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала Пп"; }
        }

        public string Description
        {
            get { return "«Шкала психопатии»"; }
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

            List<int> ansyes = new List<int>() { 14, 15, 17, 36, 37, 38, 39, 58, 59, 60, 61, 80, 81, 82, 83, 102, 103, 105, 124, 125, 126, 127, 146, 147, 148, 168, 169, 170, 171, 190, 192, 212, 234, 235, 256, 257, 258 };
            List<int> ansno = new List<int>() { 16, 104, 149, 191, 213, 214, 236 };
            _mark = NPNMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            if (_mark >=30) { _sten = 10; }
            if (_mark >= 27 & _mark <= 29) { _sten = 9; }
            if (_mark >=23 & _mark <=26) { _sten = 8; }
            if (_mark >= 20 & _mark <= 22) { _sten = 7; }
            if (_mark >= 16 & _mark <=19) { _sten = 6; }
            if (_mark >=13 & _mark<=15) { _sten = 5; }
            if (_mark >= 10 & _mark <= 12) { _sten = 4; }
            if (_mark >= 6 & _mark <= 9) { _sten = 3; }
            if (_mark >= 3 & _mark <= 5) { _sten = 2; }
            if (_mark >= 0 & _mark <= 2) { _sten = 1; }
        }

       public void GetLevel()
        {
            if (_sten <= 3) { _level = "Низкий"; }
            if (_sten >= 4 & _sten <= 7) { _level = "Средний"; }
            if (_sten >= 8) { _level = "Высокий"; }
        }
        public void GetResult()
        {

            if (_level == "Высокий") { _result = "Повышенные возбудимость, агрессивность, неуживчивость, эксплозивность, упрямство и настойчивость; склонность к бурным реакциям протеста и прямолинейной критике; низкий уровень самоконтроля, властность, высокое чувство соперничества, стремление любой ценой отстоять, оправдать свои поступки и убеждения; непредсказуемость эмоций и поступков."; }
            else { _result = "Без особенностей."; }
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
