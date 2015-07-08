using System;
using System.Collections.Generic;
using Recog.Data;

namespace Recog.PTests.Leongard.Scales
{

    public class LScaleG9 : IScale
    {
        private double _mark;
        private int _sten;
        private const int KOOFICIENT = 3;
        private string _result;
        private string _level;
        private LAnswers _answers;
        private pBaseEntities _ge;
        public LScaleG9(LAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала Г9"; }
        }

        public string Description
        {
            get { return "«Дистимный тип»"; }
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

            List<int> ansyes = new List<int>() { 9, 21, 43, 75, 87};
            List<int> ansno = new List<int>() {31, 53, 65};
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
            if (_level == "Высокий") { _result = "Имеется акцентуация по данному типу. Люди этого типа отличаются серьезностью, даже подавленностью настроения, медлительностью слабостью волевых усилий. Для них характерны пессимистическое отношение к будущему, заниженная самооценка, а также низкая контактность, немногословность в беседе, даже молчаливость. Такие люди являются домоседами, индивидуалистами; общества, шумной компании обычно избегают, ведут замкнутый образ жизни. Часто угрюмы, заторможенны, склонны фиксироваться на теневых сторонах жизни. Они добросовестны, ценят тех, кто с ними дружит, и готовы им подчиниться, располагают обостренным чувством справедливости, а также замедленностью мышления."; }
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
