using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.D
{

    public class DScaleDAN : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private DAnswers _answers;
        private pBaseEntities _ge;
        public DScaleDAN(DAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала второго уровня DAN"; }
        }

        public string Description
        {
            get { return "«Дезадаптационные нарушения»"; }
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

            List<int> ansyes = new List<int>() { 3, 4, 5, 6, 7, 8, 10, 12, 13, 14, 15, 17, 18, 19, 20, 22, 23, 24, 27, 28, 29, 31, 32, 33, 34, 35, 36, 37, 39, 40, 41, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 63, 64, 65, 66, 68, 69, 70, 71, 72, 73, 74, 76, 77 };
            List<int> ansno = new List<int>() { 1, 2, 9, 11, 16, 21, 25, 26, 30, 38, 42, 62, 67, 75 };
           _mark = DMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            if (_mark <=2) { _sten = 10; }
            if (_mark >= 3 & _mark <= 5) { _sten = 9; }
            if (_mark >= 6 & _mark <= 10) { _sten = 8; }
            if (_mark >= 11 & _mark <= 15) { _sten = 7; }
            if (_mark >=16 & _mark <= 20) { _sten = 6; }
            if (_mark >= 21 & _mark <= 30) { _sten = 5; }
            if (_mark >= 31 & _mark <= 35) { _sten = 4; }
            if (_mark >=36 & _mark <= 42) { _sten = 3; }
            if (_mark >= 43 & _mark <= 50) { _sten = 2; }
            if (_mark >=51) { _sten = 1; }
        }

       public void GetLevel()
        {
            if (_sten <= 3) { _level = "Низкий"; }
            else { _level = "Высокий"; }
        }
        public void GetResult()
        {

            if (_level == "Низкий") { _result = "Выраженные (достаточно выраженные) признаки дезадаптационных нарушений. Требуется консультация психиатра. Показана комплексная психологическая и фармакологическая коррекция."; }
            else { _result = "Без особенностей"; }
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
