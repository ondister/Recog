using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.D
{

    public class DScaleAC : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private DAnswers _answers;
        private pBaseEntities _ge;
        public DScaleAC(DAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала второго уровня AC"; }
        }

        public string Description
        {
            get { return "«Астенические реакции и состояния»"; }
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

            List<int> ansyes = new List<int>() { 6, 7, 12, 13, 14, 18, 27, 31, 32, 33, 34, 37, 41, 43, 46, 48, 49, 51, 52, 53, 55, 57, 58, 59, 60, 61, 63, 64, 71, 72, 73, 74 };
            List<int> ansno = new List<int>() { 1, 2, 9, 11, 21, 25, 26, 30, 38, 42, 67 };
           _mark = DMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            if (_mark <= 1) { _sten = 10; }
            if (_mark ==2) { _sten = 9; }
            if (_mark >= 3 & _mark <= 4) { _sten = 8; }
            if (_mark >= 5 & _mark <= 6) { _sten = 7; }
            if (_mark >=7 & _mark <= 9) { _sten = 6; }
            if (_mark >= 10 & _mark <= 15) { _sten = 5; }
            if (_mark >= 16 & _mark <= 21) { _sten = 4; }
            if (_mark >=22 & _mark <= 29) { _sten = 3; }
            if (_mark >= 30 & _mark <= 35) { _sten = 2; }
            if (_mark >=36) { _sten = 1; }
        }

       public void GetLevel()
        {
            if (_sten <= 3) { _level = "Низкий"; }
            else { _level = "Высокий"; }
        }
        public void GetResult()
        {

            if (_level == "Низкий") { _result = "Высокий уровень ситуационной тревожности, расстройства сна, ипохондрическая фиксация, повышенная утомляемость, истощаемость, слабость, резкое снижение способности к продолжительному физическому или умственному напряжению, низкая толерантность к неблагоприятным факторам профессиональной деятельности, особенно при чрезвычайных нагрузках, аффективная лабильность с преобладанием пониженного настроения, слезливость, гнетущая безысходность, тоска, хандра, восприятие настоящего окружения и своего будущего только в мрачном свете, наличие суицидальных мыслей, отсутствие мотивации к профессиональной деятельности и др."; }
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
