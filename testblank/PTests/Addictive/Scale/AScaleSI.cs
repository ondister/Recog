using System;
using System.Collections.Generic;
using Recog.Data;
namespace Recog.PTests.Addictive.Scales
{

    public class AScaleSI : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private AAnswers _answers;
        private pBaseEntities _ge;
      
        public AScaleSI(AAnswers aAnswers, pBaseEntities GlobalEntities)
        {
            _answers = aAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Аддиктивная склонность"; }
        }

        public string Description
        {
            get { return "«Интегральная шкала Аддиктивная склонность»"; }
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

            List<int> ansyes = new List<int>() { 1, 2, 3, 7, 15, 17, 25, 26, 4, 5, 6, 10, 14, 16, 18, 19, 22, 9, 11, 12, 20, 24, 27, 29, 8, 13, 21, 23, 28, 30 };
            List<int> ansno = new List<int>() {  };
            _mark = AMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            if (_mark == 0) { _sten = 10; }
            if (_mark ==1) { _sten = 9; }
            if (_mark ==2) { _sten = 8; }
            if (_mark >= 3 & _mark <=4) { _sten = 7; }
            if (_mark ==5) { _sten = 6; }
            if (_mark ==6) { _sten = 5; }
            if (_mark >= 7 & _mark <= 9) { _sten = 4; }
            if (_mark >= 10 & _mark <= 12) { _sten = 3; }
            if (_mark >= 13 & _mark <= 15) { _sten = 2; }
            if (_mark >= 16 & _mark <= 30) { _sten = 1; }
        }

       public void GetLevel()
        {
            if (_sten >= 1 & _sten <= 2) { _level = "Высокий"; }
            if (_sten >= 3 & _sten <= 4) { _level = "Выше среднего"; }
            if (_sten >=5 & _sten <= 7) { _level = "Средний"; }
            if (_sten >= 8 & _sten <= 10) { _level = "Низкий"; }
        }
        public void GetResult()
        {

            if (_sten >= 1 & _sten <= 2) { _result = "Респондент имеет аддиктивное расстройство в связи с приёмом психоактивных веществ и/или эпизодическим употреблением алкоголя. Характерен активный поиск психоактивных веществ. Воспитывался в дисгармоничной семье и общался со сверстниками с девиантным поведением."; }
            if (_sten >= 3 & _sten <= 4) { _result = "Респондент имеет аддиктивную склонность к приёму психоактивных веществ и/или алкоголя, проявляющуюся в аддиктивном поведении. Воспитывался в дисгармоничной семье и/или общался со сверстниками с девиантным поведением."; }
            if (_sten >= 5 & _sten <= 7) { _result = "У респондента имеется предрасположенность к аддиктивной зависимости. Иногда проявляется аддиктивное поведение в связи с приёмом слабых психоактивных веществ и/или приёмом алкоголя. Неблагоприятная наследственная отягощённость."; }
            if (_sten >= 8 & _sten <= 10) { _result = "У респондента отсутствует аддиктивная склонность к алкогольной и наркотической зависимостям."; }
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
