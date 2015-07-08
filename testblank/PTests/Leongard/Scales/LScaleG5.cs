using System;
using System.Collections.Generic;
using Recog.Data;

namespace Recog.PTests.Leongard.Scales
{

    public class LScaleG5 : IScale
    {
        private double _mark;
        private int _sten;
        private const int KOOFICIENT = 3;
        private string _result;
        private string _level;
        private LAnswers _answers;
        private pBaseEntities _ge;
        public LScaleG5(LAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала Г5"; }
        }

        public string Description
        {
            get { return "«Тревожный тип»"; }
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

            List<int> ansyes = new List<int>() { 16, 27, 38, 49, 60, 71, 82 };
            List<int> ansno = new List<int>() {5};
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
            if (_level == "Высокий") { _result = "Имеется акцентуация по данному типу. Людям данного типа свойственны низкая контактность, минорное настроение, робость, пугливость, неуверенность в себе. Дети тревожного типа часто боятся темноты, животных, страшатся оставаться одни. Они сторонятся шумных и бойких сверстников, не любят чрезмерно шумных игр, испытывают чувство робости и застенчивости, тяжело переживают контрольные, экзамены, проверки. Часто стесняются отвечать перед классом. Охотно подчиняются опеке старших, нотации взрослых могут вызвать у них угрызения совести, чувство вины, слезы, отчаяние. У них рано формируется чувство долга, ответственности, высокие моральные и этические требования. Чувство собственной неполноценности стараются замаскировать в самоутверждении через те виды деятельности, где они могут в большей мере раскрыть свои способности. Свойственные им с детства обидчивость, чувствительность, застенчивость мешают сблизиться с теми, с кем хочется, особо слабым звеном является реакция на отношение к ним окружающих. Непереносимость насмешек, подозрения сопровождаются неумением постоять за себя, отстоять правду при несправедливых обвинениях. Редко вступают в конфликты с окружающими, играя в них в основном пассивную роль, в конфликтных ситуациях они ищут поддержки и опоры. Они обладают дружелюбием, самокритичностью, исполнительнотью. Вследствие своей беззащитности нередко служат козлами отпущения, мишенями для шуток "; }
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
