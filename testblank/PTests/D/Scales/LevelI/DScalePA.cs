using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.D
{

    public class DScalePA : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private DAnswers _answers;
        private pBaseEntities _ge;
        public DScalePA(DAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала первого уровня Pa"; }
        }

        public string Description
        {
            get { return "«Шкала параноидальности»"; }
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

            List<int> ansyes = new List<int>() { 4, 7, 8, 10, 18, 39, 43, 46, 48, 98, 104, 125, 150, 152 };
            List<int> ansno = new List<int>() { 33, 42, 84, 137, 145, 155 };
           _mark = DMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            List<int> Tmark = new List<int>() { 27, 31, 36, 40, 43, 46, 49, 52, 55, 57, 63, 67, 71, 74, 79, 81, 84, 87, 91, 95, 100 };
            _sten = Tmark[(int)_mark];
        }

       public void GetLevel()
        {
            if (_sten <=69) { _level = "Низкий"; }
            if (_sten >=70) { _level = "Высокий"; }
        }
        public void GetResult()
        {

            if (_level == "Высокий") { _result = "Склонность к ригидной (негибкой) системе в подходе к решению различных жизненных проблем, медленной смене настроения, постепенному накапливанию аффекта. Конкретность мышления, излишняя детализации и педантизм. Тенденция к упорному и активному насаждению своих взглядов и ценностей, что является причиной частых конфликтов с окружающими. Зачастую — переоценка собственных удач и достижений, формирующих совершенную идею исключительности. Склонность к соперничеству, ревности, злопамятству, мстительности, формированию сверхценных идей отношений."; }
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
