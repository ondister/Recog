using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.Kettell
{

    public class KettellScaleB : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private double _x;

        public double X
        {
            get { return _x; }
        }


        private KettellAnswers _answers;
        private pBaseEntities _ge;
        private EnumKettellType _ktype;
      

        public KettellScaleB(KettellAnswers KettellAnswers,pBaseEntities GlobalEntities,EnumKettellType KType)
        {
            _answers = KettellAnswers;
            _ge = GlobalEntities;
            _ktype = KType;
        }
        public string Name
        {
            get { return "Фактор В"; }
        }

        public string Description
        {
            get { return "«интеллект»"; }
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
            List<int> ans;
            if (_ktype == EnumKettellType.CForm)
            {
                ans = new List<int>();
                for (int i = 3; i <= 88; i += 17)
                {
                    ans.Add(i);
                }
                ans.Add(104);
                ans.Add(105);
            }
            else { ans = new List<int>() { 28, 53, 54, 77, 78, 102, 103, 127, 128, 152, 153, 177, 178 }; }
            _mark = KettellMarkExtractor.GetMark(_ge, _answers, ans, _ktype);
         this.GetSten();
         this.GetLevel();
         this.GetResult();
          

        }

       public void GetSten()
        {
            if (_ktype == EnumKettellType.CForm)
            {
                if (_mark <= 2) { _sten = 1; }
                if (_mark == 3) { _sten = 3; }
                if (_mark == 4) { _sten = 5; }
                if (_mark == 5) { _sten = 7; }
                if (_mark == 6) { _sten = 8; }
                if (_mark == 7 | _mark == 8) { _sten = 10; }
            }
            else 
            {
                if (_mark <= 4) { _sten = 1; }
                if (_mark == 5) { _sten = 2; }
                if (_mark == 6) { _sten = 4; }
                if (_mark ==7) { _sten = 5; }
                if (_mark ==8) { _sten = 6; }
                if (_mark==9) { _sten = 7; }
                if (_mark == 10) { _sten = 8; }
                if (_mark ==11) { _sten = 9; }
                if (_mark >= 12 & _mark <= 13) { _sten = 10; }
            }
        }

       public void GetLevel()
        {
            if (_ktype == EnumKettellType.CForm)
            {
                if (_sten >= 1 & _sten <= 3) { _level = "Низкий"; }
                if (_sten >= 4 & _sten <= 6) { _level = "Средний"; }
                if (_sten >= 7 & _sten <= 10) { _level = "Высокий"; }
            }
            else
            {
                if (_sten <= 5.5) { _level = "Низкий"; }
                else { _level = "Высокий"; }
            }
        }
        public void GetResult()
        {
            if (_sten >= 1 & _sten <= 3) { _result = "Склонен медленнее понимать материал при обучении. «Туповат», предпочитает конкретную, буквальную интерпретацию. Его «тупость» или отражает низкий интеллект, или является следствием снижения функций в результате психопатологии."; }
            if (_sten >= 4 & _sten <= 5) { _result = "Менее интеллектуально развит, конкретно мыслит, обладает меньшей способность к обучению."; }
            if (_sten >= 6 & _sten <= 7) { _result = "Более интеллектуально развит, абстрактно мыслящий, разумный,  обладает высокой способностью к обучению."; }
            if (_sten >= 8 & _sten <= 10) { _result = "Быстро воспринимает и усваивает новый учебный материал. Имеется некоторая корреляция с уровнем вербальной культурным, а также с эрудицией. Высокие баллы указывают на отсутствие снижения функций интеллекта в патологических состояниях."; }

        }

        public void GetX()
        {

            if (_ktype == EnumKettellType.AForm)
            {
               
                if (_mark < 3) { _x = 0.11; }
                if (_mark == 3) { _x = 0.22; }
                if (_mark == 4) { _x = 0.33; }
                if (_mark == 5) { _x = 0.44; }
                if (_mark == 6) { _x = 0.55; }
                if (_mark  >=7 & _mark<=8) { _x = 0.66; }
                if (_mark >= 9 & _mark <= 10) { _x = 0.77; }
                if (_mark == 11) { _x = 0.88; }
                if (_mark == 12) { _x = 0.99; }
                if (_mark >12) { _x = 1.10; }
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
