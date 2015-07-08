using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.FPI
{

    public class FPIScaleII : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private FPIAnswers _answers;
        private pBaseEntities _ge;
        public FPIScaleII(FPIAnswers FPIAnswers,pBaseEntities GlobalEntities)
        {
            _answers = FPIAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала II"; }
        }

        public string Description
        {
            get { return "«Спонтанная агрессивность»"; }
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
            get {
                 
                return _sten;
            }
            set { _sten = value; }
        }
        public string Level
        {
             
            get {
                 
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

            List<int> ansyes = new List<int>() { 32, 35, 45, 50, 64, 73, 77, 93, 97, 98, 103, 112, 114 };
            List<int> ansno = new List<int>() { 99};
            //ans.Add(i);
         
         _mark=   FPIMarkExtractor.GetMark(_ge, _answers, ansyes,ansno);
         this.GetSten();
         this.GetLevel();
         this.GetResult();
          

        }

       public void GetSten()
        {
            if ( _mark <= 1) { _sten = 1; }
            if (_mark==2) { _sten = 3; }
            if (_mark ==3) { _sten = 4; }
            if (_mark >=4 & _mark<=5) { _sten = 5; }
            if (_mark == 6) { _sten = 7; }
            if (_mark >= 7 & _mark <= 9) { _sten = 8; }
            if (_mark >= 10 & _mark <= 13) { _sten = 9; }
          
          
            
        }

       public void GetLevel()
        {
            if (_sten >=1 & _sten <= 3) { _level = "Низкий"; }
            if (_sten >= 4 & _sten <= 6) { _level = "Средний"; }
            if (_sten >= 7 & _sten <= 9) { _level = "Высокий"; }
        }
        public void GetResult()
        {

            if (_level == "Высокий") { _result = "Высокие оценки свидетельствуют о повышенном уровне психопатизации, создающем предпосылки для импульсивного поведения."; }
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
