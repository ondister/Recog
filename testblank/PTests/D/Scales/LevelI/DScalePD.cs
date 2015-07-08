using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.D
{

    public class DScalePD : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private DAnswers _answers;
        private pBaseEntities _ge;
        private DScaleK _k;
        public DScalePD(DAnswers DAnswers, pBaseEntities GlobalEntities,DScaleK K)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
            _k = K;
        }
        public string Name
        {
            get { return "Шкала первого уровня Pd"; }
        }

        public string Description
        {
            get { return "«Шкала психопатии»"; }
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

            List<int> ansyes = new List<int>() { 6, 8, 11, 12, 14, 41, 42, 56, 72, 81, 82, 91, 114 };
            List<int> ansno = new List<int>() { 13, 35, 45, 48, 55, 79, 90, 97, 100, 102 };
           _mark = DMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            List<int> Tmark = new List<int>() { 30, 35, 38, 42, 45, 48, 52, 55, 60, 61, 65, 67, 69, 72, 75, 78, 81, 84, 87, 90, 93, 96, 99, 102, 105, 107, 112, 116, 119 };
            _k.GetMark();
            int m = (int)_mark + Convert.ToInt16(0.4 * _k.Mark);
            _sten = Tmark[m];
        }

       public void GetLevel()
        {
            if (_sten <=69) { _level = "Низкий с учетом шкалы К"; }
            if (_sten >= 70) { _level = "Высокий с учетом шкалы К"; }
        }
        public void GetResult()
        {

            if (_level == "Высокий с учетом шкалы К") { _result = "Признаки социальной дезадаптации. Тенденция к повышенной агрессивности, межперсональной конфликтности, частой перемене настроения, интересов и привязанностей, обидчивость. Склонность к аффектам, особенно в ситуациях ущемления чувства собственного достоинства. В ходе принятия решений преобладает импульсивность. Зачастую — пренебрежение к социальными и корпоративным нормами и ценностями. Временный подъем по этой шкале, возможно, вызван какой-нибудь ситуационной причиной."; }
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
