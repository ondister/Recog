using System;
using System.Collections.Generic;
using Recog.Data;
namespace Recog.PTests.D
{

    public class DScaleHS : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private DAnswers _answers;
        private pBaseEntities _ge;
        private DScaleK _k;
        public DScaleHS(DAnswers DAnswers, pBaseEntities GlobalEntities, DScaleK K)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
            _k = K;
        }
        public string Name
        {
            get { return "Шкала первого уровня Hs"; }
        }

        public string Description
        {
            get { return "«Шкала ипохондрии»"; }
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

            List<int> ansyes = new List<int>() { 17, 67 };
            List<int> ansno = new List<int>() { 2, 3, 5, 23, 38, 53, 55, 58, 62, 75, 93 };
            _mark = DMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            List<int> Tmark = new List<int>() { 37, 40, 45, 47, 49, 51, 54, 57, 60, 65, 70, 75, 77, 80, 85, 90, 95, 100, 105, 110 };
            _k.GetMark();
            int m = (int)_mark + Convert.ToInt16(0.5 * _k.Mark);
            _sten = Tmark[m];
        }

       public void GetLevel()
        {
            if (_sten <= 69) { _level = "Низкий с учетом шкалы К"; }
            if (_sten >= 70) { _level = "Высокий с учетом шкалы К"; }
        }
        public void GetResult()
        {

            if (_level == "Высокий с учетом шкалы К") { _result = "Тенденция к астеноневротическому типу реагирования. Склонность к социальной пассивности, подчиняемости. Медленная адаптация к профессиональным условиям деятельности, климатическим факторам и новому коллективу. Плохая переносимость смены обстановки. Плохое самообладание в ходе межперсональных конфликтов."; }
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
