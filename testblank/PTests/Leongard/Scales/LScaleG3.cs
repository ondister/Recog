using System;
using System.Collections.Generic;
using Recog.Data;

namespace Recog.PTests.Leongard.Scales
{

    public class LScaleG3 : IScale
    {
        private double _mark;
        private int _sten;
        private const int KOOFICIENT = 3;
        private string _result;
        private string _level;
        private LAnswers _answers;
        private pBaseEntities _ge;
        public LScaleG3(LAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала Г3"; }
        }

        public string Description
        {
            get { return "«Эмотивный тип»"; }
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

            List<int> ansyes = new List<int>() { 3,13, 35, 47, 57, 69, 79};
            List<int> ansno = new List<int>() {25 };
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
            if (_level == "Высокий") { _result = "Имеется акцентуация по данному типу. Этот тип родствен экзальтированному, но проявления его не столь бурны. Для них характерны эмоциональность, чувствительность, тревожность, болтливость, боязливость, глубокие реакции в области тонких чувств. Наиболее сильно выраженная их черта — гуманность, сопереживание другим людям или животным, отзывчивость, мягкосердечность, они радуются чужим успехам. Впечатлительны, слезливы, любые жизненные события воспринимают серьезнее, чем другие люди. Подростки остро реагируют на сцены из фильмов, где кому-либо угрожает опасность, сцена насилия может вызвать у них сильное потрясение, которое долго не забудется и может нарушить сон. Редко вступают в конфликты, обиды носят в себе, не выплескивая их наружу. Им свойственно обостренное чувство долга, исполнительность. Бережно относятся к природе, любят выращивать растения, ухаживать за животными."; }
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
