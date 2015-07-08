using System;
using System.Collections.Generic;
using Recog.Data;

namespace Recog.PTests.Leongard.Scales
{

    public class LScaleG2 : IScale
    {
        private double _mark;
        private int _sten;
        private const int KOOFICIENT = 2;
        private string _result;
        private string _level;
        private LAnswers _answers;
        private pBaseEntities _ge;
        public LScaleG2(LAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала Г2"; }
        }

        public string Description
        {
            get { return "«Возбудимый тип»"; }
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

            List<int> ansyes = new List<int>() { 2, 15, 24, 34, 37, 56, 68, 78, 81 };
            List<int> ansno = new List<int>() { 12, 46, 59 };
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
            if (_level == "Высокий") { _result = "Имеется акцентуация по данному типу. Недостаточная управляемость, ослабление контроля над влечениями и побуждениями сочетаются у людей такого типа с властью физиологических влечений. Ему характерна повышенная импульсивность, инстинктивность, грубость, занудство, угрюмость, гневливость, склонность к хамству и брани, к трениям и конфликтам, в которых сам и является активной, провоцирующей стороной. Раздражителен, вспыльчив, часто меняет место работы, неуживчив в коллективе. Отмечается низкая контактность в общении, замедленность вербальных и невербальных реакций, тяжеловесность поступков. Для него никакой труд не становится привлекательным, работает лишь по мере необходимости, проявляет такое же нежелание учиться. Равнодушен к будущему, целиком живет настоящим, желая извлечь из него массу развлечений. Повышенная импульсивность или возникающая реакция возбуждения гасятся с трудом и могут быть опасны для окружающих. Он может быть властным, выбирая для общения наиболее слабых."; }
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
