using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.Kettell
{

    public class KettellScaleH : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private KettellAnswers _answers;
        private pBaseEntities _ge;
       private EnumKettellType _ktype;
        public KettellScaleH(KettellAnswers KettellAnswers,pBaseEntities GlobalEntities,EnumKettellType KType)
        {
            _answers = KettellAnswers;
            _ge = GlobalEntities;
            _ktype = KType;
        }
        public string Name
        {
            get { return "Фактор Н"; }
        }

        public string Description
        {
            get { return "«робость – смелость»"; }
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
               for (int i = 8; i <= 93; i += 17)
               {
                   ans.Add(i);
               }
           }
           else
           {
               ans = new List<int>() { 10, 35, 36, 60, 61, 85, 86, 110, 111, 135, 136, 161, 186 };
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
                if (_mark <= 3) { _sten = 1; }
                if (_mark == 4) { _sten = 2; }
                if (_mark == 5) { _sten = 3; }
                if (_mark == 6) { _sten = 4; }
                if (_mark == 7) { _sten = 5; }
                if (_mark == 8) { _sten = 6; }
                if (_mark == 9) { _sten = 7; }
                if (_mark == 10) { _sten = 8; }
                if (_mark == 11) { _sten = 9; }
                if (_mark == 12) { _sten = 10; }
            }
            else
            {
                if (_mark <= 2) { _sten = 1; }
                if (_mark >= 3 & _mark <= 4) { _sten = 2; }
                if (_mark >= 5 & _mark <= 7) { _sten = 3; }
                if (_mark >= 8 & _mark <= 10) { _sten = 4; }
                if (_mark >= 11 & _mark <=13) { _sten = 5; }
                if (_mark >= 14 & _mark <= 16) { _sten = 6; }
                if (_mark >= 17 & _mark <= 18) { _sten = 7; }
                if (_mark >= 19 & _mark <= 20) { _sten = 8; }
                if (_mark >= 21 & _mark <= 22) { _sten = 9; }
                if (_mark >= 23 & _mark <= 26) { _sten = 10; }
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
            if (_sten >= 1 & _sten <= 3) { _result = "Застенчивый, уклончивый, держится в стороне, «тушуется». Обычно испытывает чувство собственной недостаточности. Речь замедленна, затруднена, высказывается трудно. Избегает профессий, связанных с личными контактами. Предпочитает иметь 1-2 близких друзей, не склонен вникать во все, что происходит вокруг него."; }
            if (_sten >= 4 & _sten <= 5) { _result = "Застенчивый, сдержанный, неуверенный, боязливый, робкий."; }
            if (_sten >= 6 & _sten <= 7) { _result = "Авантюрный, социально-смелый, незаторможенный, спонтанный."; }
            if (_sten >= 8 & _sten <= 10) { _result = "Общительный, смелый, спонтанный и живой в эмоциональной сфере. Его «толстокожесть» позволяет ему переносить жалобы и слезы, трудности в общении с людьми в эмоционально напряженных ситуациях. Может небрежно относиться к деталям, не реагировать на сигналы об опасности."; }

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
