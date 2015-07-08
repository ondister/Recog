using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.Prognoz.Scales
{

    public class PScaleNPU : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private PAnswers _answers;
        private pBaseEntities _ge;
        public PScaleNPU(PAnswers pAnswers, pBaseEntities GlobalEntities)
        {
            _answers = pAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала NPU"; }
        }

        public string Description
        {
            get { return "«Нервно-психическая устойчивость»"; }
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

            List<int> ansyes = new List<int>() { 2, 3, 5, 7, 9, 11, 13, 14, 16, 18, 20, 22, 25, 27, 28, 29, 31, 32, 34, 36, 37, 39, 40, 42, 43, 45, 47, 48, 51, 53, 54, 56, 57, 59, 60, 62, 63, 65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,86,86 };
            List<int> ansno = new List<int>() { 4, 8, 17, 24, 30, 35, 41, 46, 50, 55, 64 };
           _mark = PMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            if (_mark<=1) { _sten = 10; }
            if (_mark >= 2 & _mark <= 3) { _sten = 9; }
            if (_mark >= 4 & _mark <= 5) { _sten = 8; }
            if (_mark >= 6 & _mark <= 9) { _sten = 7; }
            if (_mark >=10 & _mark <= 15) { _sten = 6; }
            if (_mark >= 16 & _mark <= 20) { _sten = 5; }
            if (_mark >= 21 & _mark <= 28) { _sten = 4; }
            if (_mark >=29 & _mark <= 34) { _sten = 3; }
            if (_mark >= 35 & _mark <= 40) { _sten = 2; }
            if (_mark >=41) { _sten = 1; }
        }

       public void GetLevel()
        {
            if (_sten <= 3) { _level = "Низкий"; }
            if (_sten >= 4 & _sten <= 6) { _level = "Средний"; }
            if (_sten >= 7) { _level = "Высокий"; }
        }
        public void GetResult()
        {
            if (_level == "Высокий") { _result = "Высокий уровень нервно-психической устойчивости. Низкая вероятность нервно-психических срывов, адекватные самооценка и оценка окружающей действительности. "; }
            if (_level == "Средний") { _result = "Возможны единичные, кратковременные нарушения поведения в экстремальных ситуациях при значительных физических и эмоциональных нагрузках. Существует вероятность нервно-психических срывов в напряженных, экстремальных ситуациях."; }
            if (_level == "Низкий") { _result = "Склонность к нарушениям психической деятельности при значительных психических и физических нагрузках. Необходима консультация психиатра."; }
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
