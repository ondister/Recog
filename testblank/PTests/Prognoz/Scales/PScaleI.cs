using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.Prognoz.Scales
{

    public class PScaleI : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private PAnswers _answers;
        private pBaseEntities _ge;
        public PScaleI(PAnswers pAnswers, pBaseEntities GlobalEntities)
        {
            _answers = pAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала искренности"; }
        }

        public string Description
        {
            get { return "«Искренность»"; }
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

            List<int> ansyes = new List<int>() {  };
            List<int> ansno = new List<int>() { 1, 6, 10, 12, 15, 19, 21, 26, 33, 38, 44, 49, 52, 58, 61 };
           _mark = PMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            _sten = (int)_mark;
        }

       public void GetLevel()
        {
            if (_sten >=10) { _level = "Низкий"; }
        }
        public void GetResult()
        {

            if (_level == "Низкий") { _result = "Результаты теста недостоверны"; }
            else
            {
                _result = "Результаты теста достоверны";
            }
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
