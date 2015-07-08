using System;
using System.Collections.Generic;
using Recog.Data;

namespace Recog.PTests.Leongard.Scales
{

    public class LScaleG1 : IScale
    {
        private double _mark;
        private int _sten;
        private const int KOOFICIENT = 3;
        private string _result;
        private string _level;
        private LAnswers _answers;
        private pBaseEntities _ge;
        public LScaleG1(LAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала Г1"; }
        }

        public string Description
        {
            get { return "«Гипертимный тип»"; }
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

            List<int> ansyes = new List<int>() { 1, 11, 23, 33, 45, 55, 67, 77 };
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
            if (_level == "Высокий") { _result = "Имеется акцентуация по данному типу. Людей этого типа отличает большая подвижность, общительность, болтливость, выраженность жестов, мимики, пантомимики, чрезмерная самостоятельность, склонность к озорству, недостаток чувства дистанции в отношениях с другими. Часто спонтанно отклоняются от первоначальной темы в разговоре. Везде вносят много шума, любят компании сверстников, стремятся ими командовать. Они почти всегда имеют очень хорошее настроение, хорошее самочувствие, высокий жизненный тонус, нередко цветущий вид, хороший аппетит, здоровый сон, склонность к чревоугодию и иным радостям жизни. Это люди с повышенной самооценкой, веселые, легкомысленные, поверхностные и вместе с тем деловитые, изобретательные, блестящие собеседники; люди, умеющие развлекать других, энергичные, деятельные, инициативные. Большое стремление к самостоятельности может служить источником конфликтов. Им характерны вспышки гнева, раздражения, особенно когда они встречают сильное противодействие, терпят неудачу. Склонны к аморальным поступкам, повышенной раздражительности, прожектерству. Испытывают недостаточно серьезное отношение к своим обязанностям. Они трудно переносят условия жесткой дисциплины монотонную деятельность, вынужденное одиночество."; }
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
