using System;
using System.Collections.Generic;
using Recog.Data;

namespace Recog.PTests.Leongard.Scales
{

    public class LScaleG10 : IScale
    {
        private double _mark;
        private int _sten;
        private const int KOOFICIENT = 6;
        private string _result;
        private string _level;
        private LAnswers _answers;
        private pBaseEntities _ge;
        public LScaleG10(LAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала Г10"; }
        }

        public string Description
        {
            get { return "«Экзальтированный тип»"; }
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

            List<int> ansyes = new List<int>() { 10, 32, 54, 76 };
            List<int> ansno = new List<int>() {};
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
            if (_level == "Высокий") { _result = "Имеется акцентуация по данному типу. Яркая черта этого типа — способность восторгаться, восхищаться, а также улыбчивостъ, ощущение счастья, радости, наслаждения. Эти чувства у них могут часто возникать по причине, которая у других не вызывает большого подъема, они легко приходят в восторг от радостных событий и в полное отчаяние — от печальных. Им свойственна высокая контактность, словоохотливость, влюбчивость. Такие люди часто спорят, но не доводят дела до открытых конфликтов. В конфликтных ситуациях они бывают как активной, так и пассивной стороной. Они привязаны к друзьям и близким, альтруистичны, имеют чувство сострадания, хороший вкус, проявляют яркость и искренность чувств. Могут быть паникерами, подвержены сиюминутным настроениям, порывисты, легко переходят от состояния восторга к состоянию печали, обладают лабильностью психики."; }
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
