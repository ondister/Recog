﻿using System;
using System.Collections.Generic;
using Recog.Data;
namespace Recog.PTests.Addictive.Scales
{

    public class AScaleS : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private AAnswers _answers;
        private pBaseEntities _ge;
        private const double N = 2.15;
        private const double M = 2.14;
        public AScaleS(AAnswers aAnswers, pBaseEntities GlobalEntities)
        {
            _answers = aAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Аддиктивная склонность"; }
        }

        public string Description
        {
            get { return "«Шкала Аддиктивная склонность»"; }
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

            List<int> ansyes = new List<int>() { 4, 5, 6, 10, 14, 16, 18, 19, 22 };
            List<int> ansno = new List<int>() {  };
            _mark = AMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            _sten = (int)_mark;
        }

       public void GetLevel()
        {
            if ((_mark-N)<M) { _level = "Маловыраженное свойство"; }
            else { _level = "Ярковыраженное свойство"; }
        }
        public void GetResult()
        {

            _result = _level;
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
