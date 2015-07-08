using System;
using System.Collections.Generic;
using Recog.Data;

namespace Recog.PTests.NPNA.Scales
{

    public class NPNScaleS : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private NPNAnswers _answers;
        private pBaseEntities _ge;
        public NPNScaleS(NPNAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала Ш"; }
        }

        public string Description
        {
            get { return "«Шкала шизофрении»"; }
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

            List<int> ansyes = new List<int>() { 21, 22, 43, 44, 65, 66, 87, 88, 108, 109, 110, 130, 131, 132, 152, 153, 154, 174, 175, 176, 196, 197, 198, 218, 219, 220, 240, 241,242, 262, 263, 264 };
            List<int> ansno = new List<int>() {  };
            _mark = NPNMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            if (_mark >=11) { _sten = 10; }
            if (_mark ==10) { _sten = 9; }
            if (_mark ==9) { _sten = 8; }
            if (_mark >= 7 & _mark <= 8) { _sten = 7; }
            if (_mark ==6) { _sten = 6; }
            if (_mark >=4 & _mark<=5) { _sten = 5; }
            if (_mark ==3) { _sten = 4; }
            if (_mark >= 1 & _mark <= 2) { _sten = 3; }
            if (_mark ==0) { _sten = 2; }
            if (_mark ==0) { _sten = 1; }
        }

       public void GetLevel()
        {
            if (_sten <= 3) { _level = "Низкий"; }
            if (_sten >= 4 & _sten <= 7) { _level = "Средний"; }
            if (_sten >= 8) { _level = "Высокий"; }
        }
        public void GetResult()
        {

            if (_level == "Высокий") { _result = "Склонность к теоретическим построениям и неожиданным умозаключениям, часто не совпадающим с выводами и суждениями окружающих, оригинальность и созерцательность; эмоциональная холодность, поверхностное сопереживание, непонимание товарищей, бесцеремонность и жесткость или, наоборот, повышенная ранимость и чувствительность; стремление к погружению в собственный мир, отчужденность, замкнутость, бесплодная мечтательность, нарастающие затруднения в общении."; }
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
