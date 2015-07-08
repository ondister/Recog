using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.Kettell
{

    public class KettellScaleQ4 : IScale
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
        public KettellScaleQ4(KettellAnswers KettellAnswers,pBaseEntities GlobalEntities,EnumKettellType KType)
        {
            _answers = KettellAnswers;
            _ge = GlobalEntities;
            _ktype = KType;
        }
        public string Name
        {
            get { return "Фактор Q4"; }
        }

        public string Description
        {
            get { return "«расслабленность – напряженность»"; }
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
              for (int i = 17; i <= 102; i += 17)
              {
                  ans.Add(i);
              }
          }
          else
          {
              ans = new List<int>() { 25, 49, 50, 74, 75, 99, 100, 124, 125, 149, 150, 174, 175 };
          }
            _mark = KettellMarkExtractor.GetMark(_ge, _answers, ans, _ktype);
         this.GetSten();
         this.GetLevel();
         this.GetResult();
          

        }

       public void GetSten()
        {
            if (_ktype == EnumKettellType.CForm)
            {
            if ( _mark <= 1) { _sten = 1; }
            if (_mark ==2) { _sten = 2; }
            if (_mark ==3) { _sten = 3; }
            if (_mark ==4) { _sten = 4; }
            if (_mark ==5) { _sten = 5; }
            if (_mark ==6 |_mark==7) { _sten = 6; }
            if (_mark ==8) { _sten = 7; }
            if (_mark ==9) { _sten = 8; }
            if (_mark ==10) { _sten = 9; }
            if (_mark >=11) { _sten = 10; }
            }
            else
            {
                if (_mark <= 3) { _sten = 1; }
                if (_mark ==4) { _sten = 2; }
                if (_mark >= 5 & _mark <= 7) { _sten = 3; }
                if (_mark >= 8 & _mark <=9) { _sten = 4; }
                if (_mark >= 10 & _mark <= 12) { _sten = 5; }
                if (_mark >= 13 & _mark <=14) { _sten = 6; }
                if (_mark >= 15 & _mark <= 17) { _sten = 7; }
                if (_mark >= 18 & _mark <=19) { _sten = 8; }
                if (_mark >= 20 & _mark <= 21) { _sten = 9; }
                if (_mark >= 22 & _mark <= 26) { _sten = 10; }
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
            if (_sten >= 1 & _sten <= 3) { _result = "Склонен к расслабленности, уравновешенности, удовлетворенности. В некоторых ситуациях его сверхудовлетворенность может вести к лени, к достижению низких результатов. Напротив, высокий уровень напряжения может нарушить эффективность учебы или работы."; }
            if (_sten >= 4 & _sten <= 5) { _result = "Расслабленный (ненапряженный), нефрустрированный."; }
            if (_sten >= 6 & _sten <= 7) { _result = "Напряженный, фрустрированный, побуждаемый, сверхреактивный (высокое энергетическое напряжение)."; }
            if (_sten >= 8 & _sten <= 10) { _result = "Cклонен к напряженности, возбудимости. Присутствует повышенная мотивация, активен, несмотря на утомляемость. Обладает слабым чувством порядка."; }

        }
        public void GetX()
        {

            if (_ktype == EnumKettellType.AForm)
            {
                if (_mark <= 2) { _x = 1.40; }
                if (_mark == 3) { _x =1.26; }
                if (_mark == 4) { _x = 1.12; }
                if (_mark == 5) { _x = 0.98; }
                if (_mark == 6) { _x = 0.84; }
                if (_mark ==7) { _x = 0.70; }
                if (_mark ==8) { _x = 0.56; }
                if (_mark == 9) { _x = 0.42; }
                if (_mark == 10) { _x = 0.28; }
                if (_mark >= 11) { _x = 0.14; }
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
