using System;
using System.Collections.Generic;
using Recog.Data;

namespace Recog.PTests.Leongard.Scales
{

    public class LScaleG7 : IScale
    {
        private double _mark;
        private int _sten;
        private const int KOOFICIENT = 2;
        private string _result;
        private string _level;
        private LAnswers _answers;
        private pBaseEntities _ge;
        public LScaleG7(LAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала Г7"; }
        }

        public string Description
        {
            get { return "«Демонстративный тип»"; }
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

            List<int> ansyes = new List<int>() { 7, 19, 22, 29, 41, 44, 63, 66, 73, 85, 88 };
            List<int> ansno = new List<int>() {51};
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
            if (_level == "Высокий") { _result = "Имеется акцентуация по данному типу. Характеризуется повышенной способностью к вытеснению, демонстративностью поведения, живостью, подвижностью, легкостью в установлении контактов. Склонен к фантазерству, лживости и притворству, направленным на приукрашивание своей персоны, к авантюризму, артистизму, позерству. Им движет стремление к лидерству, потребность в признании, жажда постоянного внимания к своей персоне, жажда власти, похвалы; перспектива быть незамеченным отягощает его. Он демонстрирует высокую приспосабливаемость к людям, эмоциональную лабильность (легкую смену настроений) при отсутствии действительно глубоких чувств, склонность к интригам (при внешней мягкости манеры общения). Отмечается беспредельный эгоцентризм, жажда восхищения, сочувствия, почитания, удивления. Обычно похвала других в его присутствии вызывает у него особо неприятные ощущения, он этого не выносит. Стремление компании обычно связано с потребностью ощутить себя лидером, занять исключительное положение. Самооценка сильно далека от объективности. Может раздражать своей самоуверенностью и высокими притязаниями, сам систематически провоцирует конфликты, но при этом активно защищается. Обладая патологической способностью к вытеснению, он может полностью забыть то, о чем он не желает знать. Это расковывает его во лжи. Обычно лжет с невинным лицом, поскольку то, о чем он говорит, в данный момент для него является правдой; по-видимому, внутренне он не осознает свою ложь или же осознает очень неглубоко, без заметных угрызений совести. Способен увлечь других неординарностью мышления и поступков."; }
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
