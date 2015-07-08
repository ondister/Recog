using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.D
{

    public class DScaleNPU : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private DAnswers _answers;
        private pBaseEntities _ge;
        public DScaleNPU(DAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала третьего уровня NPU"; }
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

            List<int> ansyes = new List<int>() { 4, 6, 7, 8, 11, 12, 15, 16, 17, 18, 20, 21, 28, 29, 30, 37, 39, 40, 41, 47, 57, 60, 63, 65, 67, 68, 70, 71, 73, 80, 82, 83, 84, 86, 89, 94, 95, 96, 98, 102, 103, 108, 109, 110, 111, 112, 113, 115, 117, 118, 119, 120, 122, 123, 124,127, 129, 131, 135, 136, 137, 139, 143, 146, 149, 153, 154, 155, 156, 157, 158, 161, 162 };
            List<int> ansno = new List<int>() { 2, 3, 5, 23, 25, 32, 38, 44, 45, 49, 52, 53, 54, 55, 58, 62,66,75, 87, 105, 132, 134, 140 };
           _mark = DMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            if (_mark<=3) { _sten = 10; }
            if (_mark >= 4 & _mark <= 5) { _sten = 9; }
            if (_mark >= 6 & _mark <= 8) { _sten = 8; }
            if (_mark >= 9 & _mark <= 12) { _sten = 7; }
            if (_mark >=13 & _mark <= 15) { _sten = 6; }
            if (_mark >= 16 & _mark <= 21) { _sten = 5; }
            if (_mark >= 22 & _mark <= 29) { _sten = 4; }
            if (_mark >=30 & _mark <= 37) { _sten = 3; }
            if (_mark >= 38 & _mark <= 45) { _sten = 2; }
            if (_mark >=46) { _sten = 1; }
        }

       public void GetLevel()
        {
            if (_sten <= 3) { _level = "Низкий"; }
            if (_sten >= 4 & _sten <= 6) { _level = "Средний"; }
            if (_sten >= 7) { _level = "Высокий"; }
        }
        public void GetResult()
        {
            if (_level == "Низкий") { _result = "Низкий уровень поведенческой регуляции, определенная склонность к нервно-психическим срывам, отсутствие адекватности самооценки и реального восприятия действительности."; }
            if (_level == "Средний") { _result = "Обладает средним уровнем поведенческой регуляции, наблюдается адекватная самооценка и реальное восприятие действительности."; }
            if (_level == "Высокий") { _result = "Высокий уровень нервно-психической устойчивости и поведенческой регуляции, высокая самооценка и реальное восприятие действительности."; }
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
