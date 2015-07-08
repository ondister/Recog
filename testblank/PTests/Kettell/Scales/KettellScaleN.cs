﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.Kettell
{

    public class KettellScaleN : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private KettellAnswers _answers;
        private pBaseEntities _ge;
       private EnumKettellType _ktype;
        public KettellScaleN(KettellAnswers KettellAnswers,pBaseEntities GlobalEntities,EnumKettellType KType)
        {
            _answers = KettellAnswers;
            _ge = GlobalEntities;
            _ktype = KType;
        }
        public string Name
        {
            get { return "Фактор N"; }
        }

        public string Description
        {
            get { return "«прямолинейность – дипломатичность»"; }
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
            get {
                 
                return _sten;
            }
            set { _sten = value; }
        }
        public string Level
        {
             
            get {
                 
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

             List<int> ans;
             if (_ktype == EnumKettellType.CForm)
             {
                 ans = new List<int>();
                 for (int i = 12; i <= 97; i += 17)
                 {
                     ans.Add(i);
                 }
             }
             else
             {
                 ans = new List<int>() { 6, 17, 41, 42, 66, 67, 92, 117, 142, 167 };
             }
            _mark = KettellMarkExtractor.GetMark(_ge, _answers, ans, _ktype);
         this.GetSten();
         this.GetLevel();
         this.GetResult();
          

        }

       public void GetSten()
        {
            if (_ktype == EnumKettellType.CForm)
            {
            if ( _mark <= 1) { _sten = 1; }
            if (_mark ==2) { _sten = 2; }
            if (_mark ==3) { _sten = 3; }
            if (_mark ==4) { _sten = 4; }
            if (_mark ==5) { _sten = 5; }
            if (_mark ==6) { _sten = 6; }
            if (_mark ==7) { _sten = 7; }
            if (_mark ==8) { _sten = 8; }
            if (_mark ==9) { _sten = 9; }
            if (_mark >=10) { _sten = 10; }
            }
            else
            {
                if (_mark <= 5) { _sten = 1; }
                if (_mark >= 6 & _mark <=7) { _sten = 2; }
                if (_mark==8) { _sten = 3; }
                if (_mark ==9) { _sten = 4; }
                if (_mark ==10) { _sten = 5; }
                if (_mark >= 11 & _mark <= 12) { _sten = 6; }
                if (_mark==13) { _sten = 7; }
                if (_mark >= 14 & _mark <= 15) { _sten = 8; }
                if (_mark ==16) { _sten = 9; }
                if (_mark >= 17 & _mark <= 20) { _sten = 10; }
            }
        }

       public void GetLevel()
        {
            if (_ktype == EnumKettellType.CForm)
            {
                if (_sten >= 1 & _sten <= 3) { _level = "Низкий"; }
                if (_sten >= 4 & _sten <= 6) { _level = "Средний"; }
                if (_sten >= 7 & _sten <= 10) { _level = "Высокий"; }
            }
            else
            {
                if (_sten <= 5.5) { _level = "Низкий"; }
                else { _level = "Высокий"; }
            }
        }
        public void GetResult()
        {
            if (_sten >= 1 & _sten <= 3) { _result = "Склонен к отсутствию утонченности, к сентиментальности и простоте. Иногда грубоват и резок, обычно естественен и спонтанен."; }
            if (_sten >= 4 & _sten <= 5) { _result = "Прямой, естественный, бесхитростный, сентиментальный."; }
            if (_sten >= 6 & _sten <= 7) { _result = "Хитрый, нерасчетливый, светский, проницательный (утонченный)."; }
            if (_sten >= 8 & _sten <= 10) { _result = "Утонченный, опытный, светский, хитрый. Склонен к анализу. Интеллектуальный подход к оценке ситуации, близкий к цинизму."; }

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
