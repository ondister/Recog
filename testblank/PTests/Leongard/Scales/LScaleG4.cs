using System;
using System.Collections.Generic;
using Recog.Data;

namespace Recog.PTests.Leongard.Scales
{

    public class LScaleG4 : IScale
    {
        private double _mark;
        private int _sten;
        private const int KOOFICIENT = 2;
        private string _result;
        private string _level;
        private LAnswers _answers;
        private pBaseEntities _ge;
        public LScaleG4(LAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала Г4"; }
        }

        public string Description
        {
            get { return "«Педантичный тип»"; }
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

            List<int> ansyes = new List<int>() { 4, 14, 17, 26, 39, 48, 58, 61, 70, 80, 83 };
            List<int> ansno = new List<int>() { 36};
            _mark = LMarkExtractor.GetMark(_ge, _answers, ansyes, ansno)*KOOFICIENT;

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            _sten =(int) _mark;
        }

       public void GetLevel()
        {
            if (_sten <= 15) { _level = "Низкий"; }
            if (_sten >= 15 & _sten <= 18) { _level = "Средний"; }
            if (_sten >= 19) { _level = "Высокий"; }
        }
        public void GetResult()
        {

            if (_level == "Низкий") { _result = "Акцентуации черты характера не выявлено"; }
            if (_level == "Средний") { _result = "Имеется тенденция к акцентуации черты характера"; }
            if (_level == "Высокий") { _result = "Имеется акцентуация по данному типу. Характеризуется ригидностью, инертностью психических процессов, тяжелостью на подъем, долгим переживанием травмирующих событий. В конфликты вступает редко, выступая скорее пассивной, чем активной стороной. В то же время очень сильно реагирует на любое проявление нарушения порядка. На службе ведет себя как бюрократ, предъявляя окружающим много формальных требований. Пунктуален, аккуратен, особое внимание уделяет чистоте и порядку, скрупулезен, добросовестен, склонен жестко следовать плану, в выполнении действий нетороплив, усидчив, ориентирован на высокое качество работы и особую аккуратность, склонен к частым самопроверкам, сомнениям в правильности выполненной работы, брюзжанию, формализму. С охотой уступает лидерство другим людям."; }
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
