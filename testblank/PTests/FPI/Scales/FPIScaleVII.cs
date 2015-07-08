using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.FPI
{

    public class FPIScaleVII : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private FPIAnswers _answers;
        private pBaseEntities _ge;
        public FPIScaleVII(FPIAnswers FPIAnswers, pBaseEntities GlobalEntities)
        {
            _answers = FPIAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала VII"; }
        }

        public string Description
        {
            get { return "«Реактивная агрессивность»"; }
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

            List<int> ansyes = new List<int>() { 13, 17, 18, 36, 39, 43, 65, 75, 90, 98 };
            List<int> ansno = new List<int>() {};
            //ans.Add(i);
         
         _mark=   FPIMarkExtractor.GetMark(_ge, _answers, ansyes,ansno);
         this.GetSten();
         this.GetLevel();
         this.GetResult();
          

        }

       public void GetSten()
        {
            if ( _mark ==0) { _sten = 1; }
            if (_mark ==1) { _sten = 3; }
            if (_mark ==2) { _sten = 4; }
            if (_mark ==3) { _sten = 5; }
            if (_mark == 4) { _sten = 6; }
            if (_mark == 5) { _sten = 7; }
            if (_mark == 6) { _sten = 8; }
            if (_mark >= 7 & _mark <= 10) { _sten = 9; }
         }

       public void GetLevel()
        {
            if (_sten >=1 & _sten <= 3) { _level = "Низкий"; }
            if (_sten >= 4 & _sten <= 6) { _level = "Средний"; }
            if (_sten >= 7 & _sten <= 9) { _level = "Высокий"; }
        }
        public void GetResult()
        {

            if (_level == "Высокий") { _result = "Высокие оценки свидетельствуют о высоком уровне психопатизации, характеризующемся агрессивным отношением к социальному окружению и выраженным стремлением к доминированию."; }
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
