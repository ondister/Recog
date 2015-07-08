using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.D
{

    public class DScaleHY : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private DAnswers _answers;
        private pBaseEntities _ge;
        public DScaleHY(DAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала первого уровня Hy"; }
        }

        public string Description
        {
            get { return "«Шкала истерии»"; }
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

            List<int> ansyes = new List<int>() { 11, 17, 20, 21, 28, 65, 67 };
            List<int> ansno = new List<int>() { 2, 3, 23, 33, 38, 42, 45, 48, 53, 58, 61, 62, 64, 75, 88, 90, 95, 97, 99 };
           _mark = DMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            List<int> Tmark = new List<int>() { 30, 33, 36, 39, 42, 45, 47, 49, 52, 54, 56, 60, 62, 65, 68, 70, 73, 75, 78, 82, 85, 89, 95, 100, 105, 111, 118 };
            _sten = Tmark[(int)_mark];
        }

       public void GetLevel()
        {
            if (_sten <=69) { _level = "Низкий"; }
            if (_sten >=70) { _level = "Высокий"; }
        }
        public void GetResult()
        {

            if (_level == "Высокий") { _result = "Повышение показателей по шкале выявляет эмоциональную лабильность, вытеснение сложных психологических проблем, социальную и эмоциональную незрелость личности, вплоть до истерических проявлений (при повышении показателей выше 80 Т). Признаки истероидных черт характера. Стремление казаться значительнее, лучше, чем это есть на самом деле. Склонность к эгоцентризму и самосожалению. Выраженное желание во что бы то ни стало обратить на себя внимание окружающих."; }
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
