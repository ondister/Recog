using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.D
{

    public class DScaleSC : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private DAnswers _answers;
        private pBaseEntities _ge;
        private DScaleK _k;
        public DScaleSC(DAnswers DAnswers, pBaseEntities GlobalEntities,DScaleK K)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
            _k = K;
        }
        public string Name
        {
            get { return "Шкала первого уровня Sc"; }
        }

        public string Description
        {
            get { return "«Шкала шизоидности»"; }
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

            List<int> ansyes = new List<int>() { 4, 6, 7, 8, 10, 11, 12, 14, 16, 21, 24, 36, 39, 56, 60, 63, 70, 80, 89, 98, 103, 105, 106, 108, 111, 119, 123, 124 };
            List<int> ansno = new List<int>() { 13, 38, 44, 66, 107 };
           _mark = DMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            List<int> Tmark = new List<int>() { 27, 31, 35, 39, 42, 45, 48, 51, 53, 55, 57, 59, 61, 63, 65, 67, 69, 71, 73, 75, 77, 80, 81, 83, 86, 87, 89, 91, 93, 95, 97, 99, 101, 103, 105, 109, 111, 113, 115, 117, 119, 120 };
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

            if (_level == "Высокий с учетом шкалы К") { _result = "Шизоидный тип поведения, проявляющийся сочетанием повышенной чувствительности с эмоциональной холодностью и отчужденностью в межличностных отношениях. Выраженная интуитивность, способность тонко чувствовать и воспринимать абстрактные образы. Повседневные (житейские) радости и горести, как правило, не вызывают должного эмоционального отклика. Склонность к фантазированию, ориентация на своё субъективное видение сущности явлений, нежели на общепринятые, устоявшиеся, шаблонные представления. Иногда — продуцирование нелепых и труднообъяснимых поступков, странных и непонятных идей и высказываний."; }
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
