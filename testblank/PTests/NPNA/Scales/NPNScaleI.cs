using System;
using System.Collections.Generic;
using Recog.Data;

namespace Recog.PTests.NPNA.Scales
{

    public class NPNScaleI : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private NPNAnswers _answers;
        private pBaseEntities _ge;
        public NPNScaleI(NPNAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала И"; }
        }

        public string Description
        {
            get { return "«Шкала истерии»"; }
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

            List<int> ansyes = new List<int>() { 7, 8, 9, 10, 29, 31, 32, 51, 52, 53, 54, 73, 74, 75, 76, 95, 96, 97, 98, 117, 118, 119, 120, 140, 141, 142, 161, 162, 163, 164, 183, 184, 185, 205, 206, 207, 227, 229, 250, 251, 272, 273 };
            List<int> ansno = new List<int>() { 30, 139, 228 };
            _mark = NPNMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            if (_mark >=36) { _sten = 10; }
            if (_mark >= 33 & _mark <= 35) { _sten = 9; }
            if (_mark >=29 & _mark <=32) { _sten = 8; }
            if (_mark >= 25 & _mark <= 28) { _sten = 7; }
            if (_mark >= 22 & _mark <= 24) { _sten = 6; }
            if (_mark >=18 & _mark<=21) { _sten = 5; }
            if (_mark >= 15 & _mark <= 17) { _sten = 4; }
            if (_mark >= 11 & _mark <= 14) { _sten = 3; }
            if (_mark >= 7 & _mark <= 10) { _sten = 2; }
            if (_mark >= 0 & _mark <= 6) { _sten = 1; }
        }

       public void GetLevel()
        {
            if (_sten <= 3) { _level = "Низкий"; }
            if (_sten >= 4 & _sten <= 7) { _level = "Средний"; }
            if (_sten >= 8) { _level = "Высокий"; }
        }
        public void GetResult()
        {

            if (_level == "Высокий") { _result = "Для лиц с высокими показателями характерны позерство, эгоцентризм, самовлюбленность, демонстративность и театральность поведения, желание быть в центре внимания, стремление показаться в глазах окружающих значительной личностью, жажда признания и оригинальности, склонность к преувеличениям. Поверхностное отношение к поставленным задачам, небрежное их исполнение. Болезненная и неадекватная реакция на общественное порицание, непризнание «заслуг». Деятельность и поведение ориентированы на внешний эффект."; }
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
