using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.D
{

    public class DScaleDS : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private DAnswers _answers;
        private pBaseEntities _ge;
        public DScaleDS(DAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала третьего уровня Ds"; }
        }

        public string Description
        {
            get { return "«Достоверность»"; }
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

            List<int> ansyes = new List<int>() {};
            List<int> ansno = new List<int>() {1, 10, 19, 31, 51, 69, 78, 92, 101, 116, 128, 138, 148};
           _mark = DMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

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
            if (_sten > 10) { _level = "Низкий"; }
            else { _level = "Высокий"; }
        }
        public void GetResult()
        {
            if (_level == "Низкий") { _result = "Полученные результаты по шкалам 3-4 уровней целесообразно считать необъективными, вследствие стремления пациента как можно «больше» соответствовать социально желаемому личностному типу."; }
            else { _result = "Полученные данные достоверны."; }
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
