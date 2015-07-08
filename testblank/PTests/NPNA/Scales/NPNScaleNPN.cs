using System;
using System.Collections.Generic;
using Recog.Data;

namespace Recog.PTests.NPNA.Scales
{

    public class NPNScaleNPN : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private NPNAnswers _answers;
        private pBaseEntities _ge;
        public NPNScaleNPN(NPNAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала НПН"; }
        }

        public string Description
        {
            get { return "«Шкала нервно-психической неустойчивости»"; }
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

            List<int> ansyes = new List<int>() { 3, 5, 23, 26, 48, 68, 89, 90, 91, 94, 110, 111, 113, 115, 134, 135, 136, 138, 155, 157, 158, 159, 160, 176, 177, 178, 181, 199, 200, 202, 203, 204, 221, 222, 223, 225, 226, 243, 244, 245, 246, 247, 248, 249, 265, 266, 267, 268, 269, 270, 271 };
            List<int> ansno = new List<int>() { 2, 28, 45, 46, 67, 69, 71, 92, 116, 133, 156, 179, 180, 182, 201, 224 };
            _mark = NPNMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            if (_mark >=13) { _sten = 10; }
            if (_mark ==12) { _sten = 9; }
            if (_mark >=10 & _mark <=11) { _sten = 8; }
            if (_mark >= 8 & _mark <= 9) { _sten = 7; }
            if (_mark ==7) { _sten = 6; }
            if (_mark >=5 & _mark<=6) { _sten = 5; }
            if (_mark >= 3 & _mark <= 4) { _sten = 4; }
            if (_mark ==2) { _sten = 3; }
            if (_mark ==1) { _sten = 2; }
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

            if (_level == "Высокий") { _result = "Низкий уровень поведенческой регуляции, нарушение межличностных отношений, недостаточная социальная зрелость, нарушение профессиональной деятельности, нарушения дисциплинарных и моральных норм поведения, отсутствие адекватной самооценки и реального восприятия действительности, низкие адаптационные возможности.Высокие показатели по шкале НПН свидетельствуют о наличии у обследуемого признаков нервно-психической неустойчивости, характер которой уточняется при интерпретации профиля личности."; }
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
