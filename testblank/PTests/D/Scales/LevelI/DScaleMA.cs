using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.D
{

    public class DScaleMA : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private DAnswers _answers;
        private pBaseEntities _ge;
        private DScaleK _k;
        public DScaleMA(DAnswers DAnswers, pBaseEntities GlobalEntities,DScaleK K)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
            _k = K;
        }
        public string Name
        {
            get { return "Шкала первого уровня Ma"; }
        }

        public string Description
        {
            get { return "«Шкала гипомании»"; }
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

            List<int> ansyes = new List<int>() { 6, 7, 27, 36, 42, 49, 56, 59, 76, 77, 80, 89, 90, 93, 95 };
            List<int> ansno = new List<int>() { 40, 43, 64, 96 };
           _mark = DMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            List<int> Tmark = new List<int>() { 33, 36, 39, 42, 47, 50, 53, 55, 57, 62, 68, 71, 74, 77, 83, 86, 89, 92, 95, 98, 105, 109, 115, 119 };
            _k.GetMark();
            int m = (int)_mark + Convert.ToInt16(0.2 * _k.Mark);
            _sten = Tmark[m];
        }

       public void GetLevel()
        {
            if (_sten <=69) { _level = "Низкий с учетом шкалы К"; }
            if (_sten >= 70) { _level = "Высокий с учетом шкалы К"; }
        }
        public void GetResult()
        {

            if (_level == "Высокий с учетом шкалы К") { _result = "Гипертимный тип поведения (независимо от обстоятельств, приподнятое настроение, чрезмерная активность, бурная деятельность, «плещущая через край» энергия без четкой направленности). Хорошая коммуникабельность (охотное и быстрое установление контактов с окружающими людьми). Постоянное стремление к поиску «острых ощущений». Желание испытать себя и свои силы в экстремальных и нестандартных ситуациях. Ориентация на работу с частыми командировками, сменой коллективов и мест проживания. Однако, интересы, как правило, скоротечны, поверхностны, неустойчивы. Все быстро «приедается», дефицит выдержки и настойчивости. Эгоцентризм, эмоциональная незрелость, ненадежность моральных установок и привязанностей."; }
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
