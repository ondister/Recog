using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.D
{

    public class DScalePC : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private DAnswers _answers;
        private pBaseEntities _ge;
        public DScalePC(DAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала второго уровня PC"; }
        }

        public string Description
        {
            get { return "«Психотические реакции и состояния»"; }
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

            List<int> ansyes = new List<int>() { 3, 4, 5, 8, 10, 15, 17, 19, 20, 22, 23, 24, 28, 29, 35, 36, 39, 40, 44, 45, 47, 50, 54, 56, 65, 66, 68, 69, 70, 76, 77 };
            List<int> ansno = new List<int>() { 16, 62, 75 };
           _mark = DMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            if (_mark ==0) { _sten = 10; }
            if (_mark ==1) { _sten = 9; }
            if (_mark >= 2 & _mark <= 3) { _sten = 8; }
            if (_mark >= 4 & _mark <= 5) { _sten = 7; }
            if (_mark >=6 & _mark <= 7) { _sten = 6; }
            if (_mark >= 8 & _mark <= 12) { _sten = 5; }
            if (_mark >= 13 & _mark <= 15) { _sten = 4; }
            if (_mark >=16 & _mark <= 21) { _sten = 3; }
            if (_mark >= 22 & _mark <= 26) { _sten = 2; }
            if (_mark >=27) { _sten = 1; }
        }

       public void GetLevel()
        {
            if (_sten <= 3) { _level = "Низкий"; }
            else { _level = "Высокий"; }
        }
        public void GetResult()
        {

            if (_level == "Низкий") { _result = "Выраженное нервно-психическое напряжение, импульсивные реакции, приступы неконтролируемого гнева, ухудшение межличностных контактов, нарушение морально-нравственной ориентации, отсутствие стремления соблюдать общепринятые нормы поведения, групповых и корпоративных требований, делинквентное поведение, чрезмерная агрессивность, озлобленность, подозрительность, иногда: аутизм, деперсонализация, наличие галлюцинаций и др."; }
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
