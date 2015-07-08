using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.D
{

    public class DScaleL : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private DAnswers _answers;
        private pBaseEntities _ge;
        public DScaleL(DAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала первого уровня L"; }
        }

        public string Description
        {
            get { return "«Шкала достоверности»"; }
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

            List<int> ansyes = new List<int>() { };
            List<int> ansno = new List<int>() { 1, 10, 19, 31, 51, 69, 78, 92, 101, 116, 128, 138, 148 };
           _mark = DMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            List<int> Tmark = new List<int>() { 35, 39, 43, 47, 52, 56, 60, 64, 67, 71, 76, 81, 87, 94, 101, 107 };
            _sten = Tmark[(int)_mark];

        }

       public void GetLevel()
        {
            if (_sten <=69) { _level = "Низкий"; }
            if (_sten >=70) { _level = "Высокий"; }
        }
        public void GetResult()
        {

            if (_level == "Высокий") { _result = "Полученные данные следует расценивать как недостоверные, ввиду неискренних ответов пациента на вопросы МЛО, интерпретация по остальным всем шкалам 1 уровня не производится"; }
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
