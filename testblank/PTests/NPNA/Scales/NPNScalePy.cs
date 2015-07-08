﻿using System;
using System.Collections.Generic;
using Recog.Data;

namespace Recog.PTests.NPNA.Scales
{

    public class NPNScalePy : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private NPNAnswers _answers;
        private pBaseEntities _ge;
        public NPNScalePy(NPNAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала Пя"; }
        }

        public string Description
        {
            get { return "«Шкала паранойи»"; }
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

            List<int> ansyes = new List<int>() { 18, 19, 20, 40, 63, 85, 86, 107, 128, 129, 151, 172, 193, 215, 237, 238 };
            List<int> ansno = new List<int>() { 41, 42, 62, 64, 84, 106, 150, 173, 194, 195, 216, 217, 239, 259, 260, 261 };
            _mark = NPNMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            if (_mark >=16) { _sten = 10; }
            if (_mark ==15) { _sten = 9; }
            if (_mark ==14) { _sten = 8; }
            if (_mark ==13) { _sten = 7; }
            if (_mark ==12) { _sten = 6; }
            if (_mark==11) { _sten = 5; }
            if (_mark >= 9 & _mark <= 10) { _sten = 4; }
            if (_mark ==8) { _sten = 3; }
            if (_mark ==7) { _sten = 2; }
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