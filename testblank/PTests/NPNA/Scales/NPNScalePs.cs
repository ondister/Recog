using System;
using System.Collections.Generic;
using Recog.Data;

namespace Recog.PTests.NPNA.Scales
{

    public class NPNScalePs : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private NPNAnswers _answers;
        private pBaseEntities _ge;
        public NPNScalePs(NPNAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала Пс"; }
        }

        public string Description
        {
            get { return "«Шкала психастении»"; }
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

            List<int> ansyes = new List<int>() { 11, 12, 13, 33, 34, 55, 56, 57, 77, 78, 79, 99, 100, 101, 121, 122, 123, 143, 144, 145, 165, 166, 167, 186, 187, 188, 189, 208, 209, 210, 211, 231, 232, 233, 252, 253, 254, 255, 274, 275, 276 };
            List<int> ansno = new List<int>() { 35, 230 };
            _mark = NPNMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            if (_mark >=27) { _sten = 10; }
            if (_mark >= 23 & _mark <= 26) { _sten = 9; }
            if (_mark >=19 & _mark <=22) { _sten = 8; }
            if (_mark >= 16 & _mark <= 18) { _sten = 7; }
            if (_mark >= 12 & _mark <= 15) { _sten = 6; }
            if (_mark >=9 & _mark<=11) { _sten = 5; }
            if (_mark >= 5 & _mark <= 8) { _sten = 4; }
            if (_mark >= 2 & _mark <= 4) { _sten = 3; }
            if (_mark ==1) { _sten = 2; }
            if (_mark ==0) { _sten = 1; }
        }

       public void GetLevel()
        {
            if (_sten <= 3) { _level = "Низкий"; }
            if (_sten >= 4 & _sten <= 7) { _level = "Средний"; }
            if (_sten >= 8) { _level = "Высокий"; }
        }
        public void GetResult()
        {

            if (_level == "Высокий") { _result = "Характерны высокая тревожность, мнительность, нерешительность, неуверенность в себе, особенно в условиях динамичной обстановки, дефицита времени и информации; повышенная ранимость и чувство неполноценности, бесконечное анализирование своих действий, склонность к сомнениям, пониженной самооценке и недовольству собой; требовательность в выполнении формальностей, деликатность и тактичность, робость, пониженная активность; трудность в принятии решений, избегание ответственных задач."; }
            else { _result = "Без особенностей."; }
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
