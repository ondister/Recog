using System;
using System.Collections.Generic;
using Recog.Data;

namespace Recog.PTests.Leongard.Scales
{

    public class LScaleG8 : IScale
    {
        private double _mark;
        private int _sten;
        private const int KOOFICIENT = 3;
        private string _result;
        private string _level;
        private LAnswers _answers;
        private pBaseEntities _ge;
        public LScaleG8(LAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала Г8"; }
        }

        public string Description
        {
            get { return "«Застревающий тип»"; }
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

            List<int> ansyes = new List<int>() { 8, 20, 30, 42, 52, 64, 74, 86 };
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
            if (_level == "Высокий") { _result = "Имеется акцентуация по данному типу. Его характеризует умеренная общительность, занудство, склонность к нравоучениям, неразговорчивость. Часто страдает от мнимой несправедливости по отношению к нему. В связи с этим проявляет настороженность и недоверчивость по отношению к людям, чувствителен к обидам и огорчениям, уязвим, подозрителен, отличается мстительностью, долго переживает происшедшее, не способен легко отходить от обид. Для него характерна заносчивость, часто выступает инициатором конфликтов. Самонадеянность, жесткость установок и взглядов, сильно развитое честолюбие часто приводят к настойчивому утверждению своих интересов, которые он отстаивает с особой энергичностью. Стремится добиться высоких показателей в любом деле, за которое берется, и проявляет большое упорство в достижении своих целей. Основной чертой является склонность к аффектам (правдолюбие, обидчивость, ревность, подозрительность), инертность в проявлении аффектов, в мышлении, в моторике."; }
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
