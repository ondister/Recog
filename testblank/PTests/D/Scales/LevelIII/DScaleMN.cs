using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.D
{

    public class DScaleMN : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private DAnswers _answers;
        private pBaseEntities _ge;
        public DScaleMN(DAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала третьего уровня Mn"; }
        }

        public string Description
        {
            get { return "«Моральная нормативность»"; }
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

            List<int> ansyes = new List<int>() { 14, 22, 36, 42, 50, 56, 59, 72, 77, 79, 91, 93, 125, 141, 145, 150, 164, 165 };
            List<int> ansno = new List<int>() { 13, 76, 97, 100, 160, 163 };
           _mark = DMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            if (_mark==0) { _sten = 10; }
            if (_mark ==1) { _sten = 9; }
            if (_mark ==2) { _sten = 8; }
            if (_mark >= 3& _mark <= 4) { _sten = 7; }
            if (_mark >=5 & _mark <= 6) { _sten = 6; }
            if (_mark >=7 & _mark <= 9) { _sten = 5; }
            if (_mark >= 10 & _mark <= 11) { _sten = 4; }
            if (_mark >=12 & _mark <= 14) { _sten = 3; }
            if (_mark >= 15 & _mark <= 17) { _sten = 2; }
            if (_mark >=18) { _sten = 1; }
        }

       public void GetLevel()
        {
            if (_sten <= 3) { _level = "Низкий"; }
            if (_sten >= 4 & _sten <= 6) { _level = "Средний"; }
            if (_sten >= 7) { _level = "Высокий"; }
        }
        public void GetResult()
        {
            if (_level == "Низкий") { _result = "Не может адекватно оценить свое место и роль в коллективе, не стремится соблюдать общепринятые нормы поведения."; }
            if (_level == "Средний") { _result = "Как правило, адекватно оценивает своё место и роль в коллективе. Старается соблюдать общепринятые нормы поведения, но не всегда это удается."; }
            if (_level == "Высокий") { _result = "Реально оценивает свою роль в коллективе, ориентируется на соблюдение общепринятых норм поведения."; }
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
