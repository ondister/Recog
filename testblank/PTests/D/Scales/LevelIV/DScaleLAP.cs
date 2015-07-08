using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.D
{

    public class DScaleLAP : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private DAnswers _answers;
        private pBaseEntities _ge;
        public DScaleLAP(DAnswers DAnswers, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Шкала четвертого уровня LAP"; }
        }

        public string Description
        {
            get { return "«Личностно-адаптационный потенциал»"; }
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

            List<int> ansyes = new List<int>() { 4, 6, 7, 8, 9, 11, 12, 14, 15, 16, 17, 18, 20, 21, 22, 24, 27, 28, 29, 30, 33, 36, 37, 39, 40, 41, 42, 43, 46, 47, 50, 56, 57, 59, 60, 61, 63, 64, 65, 67, 68, 70, 71, 72, 73, 75, 77, 79, 80, 81, 82, 83, 84, 86, 88, 89, 90, 91, 93, 94, 95, 96, 98, 99, 102, 103, 104, 106, 108, 109, 110, 111, 112, 113, 114, 115, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127,129, 131, 133, 135, 136, 137, 139, 141, 142, 143, 145, 146, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 161, 162, 164, 165 };
            List<int> ansno = new List<int>() { 2, 3, 5, 13, 23, 25, 26, 32, 34, 35, 38, 44, 45, 48, 49, 52, 53, 54, 55, 58, 62, 66, 74, 75,76, 85, 87, 97, 100, 105, 107, 130, 132, 134, 140, 144, 147, 159, 160, 163 };
           _mark = DMarkExtractor.GetMark(_ge, _answers, ansyes, ansno);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
             

        }

       public void GetSten()
        {
            if (_mark <= 5) { _sten = 10; }
            if (_mark >= 6 & _mark <= 10) { _sten = 9; }
            if (_mark >= 11 & _mark <= 15) { _sten = 8; }
            if (_mark >= 16 & _mark <= 21) { _sten = 7; }
            if (_mark >= 22 & _mark <= 27) { _sten = 6; }
            if (_mark >= 28 & _mark <= 32) { _sten = 5; }
            if (_mark >= 33 & _mark <= 39) { _sten = 4; }
            if (_mark >= 40 & _mark <= 50) { _sten = 3; }
            if (_mark >= 51 & _mark <= 61) { _sten = 2; }
            if (_mark >=62) { _sten = 1; }
        }

       public void GetLevel()
        {
            if (_sten <=2) { _level = "Низкий"; }
            if (_sten >=3 & _sten<=4) { _level = "Средний"; }
            if (_sten >=5) { _level = "Высокий"; }
        }
        public void GetResult()
        {

            if (_level == "Низкий") { _result = "Относится к группе с низким уровнем адаптации. Обладает признаками явных  акцентуаций характера и некоторыми признаками психопатий, а психическое состояние можно охарактеризовать как пограничное. Возможны нервно-психические срывы. Так же обладает низкой нервно-психической устойчивостью, конфликтен, может допускать асоциальные поступки. Требуют наблюдения психолога и врача–невропатолога (психиатра)."; }
            if (_level == "Средний") { _result = "Относится к группе с удовлетворительным уровнем адаптации. Обладает признаками различных акцентуаций, которые в привычных условиях частично компенсированы и могут проявляться при смене деятельности. Поэтому успех адаптации зависит от внешних условий среды. Как правило обладает невысокой эмоциональной устойчивостью. Возможны асоциальные срывы, проявление агрессии и конфликтности. Требует индивидуального подхода, постоянного наблюдения, коррекционных мероприятий."; }
            if (_level == "Высокий") { _result = "Относится к группе с высоким и нормальным уровнем адаптации. Достаточно легко адаптируются к новым условиям деятельности, быстро входят в новый коллектив, достаточно легко и адекватно ориентируются в ситуации, быстро вырабатывает стратегию своего поведения. Как правило, не конфликтен, обладает высокой эмоциональной устойчивостью."; }
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
