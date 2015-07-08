using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.D
{

    public class DScalePT : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private DAnswers _answers;
        private pBaseEntities _ge;
        private DScaleK _k;
        public DScalePT(DAnswers DAnswers, pBaseEntities GlobalEntities,DScaleK K)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
            _k = K;
        }
        public string Name
        {
            get { return "Шкала первого уровня Pt"; }
        }

        public string Description
        {
            get { return "«Шкала психастении»"; }
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

            List<int> ansyes = new List<int>() { 7, 10, 11, 16, 28, 30, 37, 41, 67, 73, 80, 88, 103, 104, 110, 117, 120, 122, 123 };
            List<int> ansno = new List<int>() { 2, 52 };
           _mark = DMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            List<int> Tmark = new List<int>() { 35, 37, 40, 43, 46, 49, 52, 55, 57, 59, 61, 63, 65, 67, 70, 73, 76, 79, 82, 85, 88, 91, 93, 96, 99, 102, 105, 108, 112, 115, 118 };
            _k.GetMark();
            int m = (int)_mark + (int)_k.Mark;
            _sten = Tmark[m];
        }

       public void GetLevel()
        {
            if (_sten <=69) { _level = "Низкий с учетом шкалы К"; }
            if (_sten >= 70) { _level = "Высокий с учетом шкалы К"; }
        }
        public void GetResult()
        {

            if (_level == "Высокий с учетом шкалы К") { _result = "Характерна излишняя тревожность по любым причинам, нерешительность и боязливость в принятии решений. Постоянные сомнения в правильности выбора решения и поставленных целей. Тенденция к тщательной перепроверке своих поступков и проделанной работы. Повышенное чувство вины за малейшие неудачи и ошибки. Мнительность, неуверенность в себе. Обязательная ориентация на мнение коллектива (группы), приверженность к общепринятым нормам. Склонность к альтруистическим проявлениям, действиям на маргинальном (предельном) уровне своих возможностей, только чтобы заслужить одобрение со стороны окружающих лиц."; }
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
