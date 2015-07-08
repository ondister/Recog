using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.Kettell
{

    public class KettellScaleI : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private KettellAnswers _answers;
        private pBaseEntities _ge;
       private EnumKettellType _ktype;
        public KettellScaleI(KettellAnswers KettellAnswers,pBaseEntities GlobalEntities,EnumKettellType KType)
        {
            _answers = KettellAnswers;
            _ge = GlobalEntities;
            _ktype = KType;
        }
        public string Name
        {
            get { return "Фактор I"; }
        }

        public string Description
        {
            get { return "«жесткость – чувствительность»"; }
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
                for (int i = 9; i <= 94; i += 17)
                {
                    ans.Add(i);
                }
            }
            else
            {
                ans = new List<int>() { 11, 12, 37, 62, 87, 112, 137, 138, 162, 163 };
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
                if (_mark ==3) { _sten = 2; }
                if (_mark >= 4 & _mark <= 5) { _sten = 3; }
                if (_mark==6) { _sten = 4; }
                if (_mark >= 7 & _mark <= 8) { _sten = 5; }
                if (_mark >= 9 & _mark <= 10) { _sten = 6; }
                if (_mark >=11 & _mark <= 12) { _sten = 7; }
                if (_mark >= 13 & _mark <= 14) { _sten = 8; }
                if (_mark ==15) { _sten = 9; }
                if (_mark >= 16 & _mark <= 20) { _sten = 10; }
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
            if (_sten >= 1 & _sten <= 3) { _result = "Практичный, реалистичный, мужественный, независимый, имеет чувство ответственности, но скептически относится к субъективным и культурным аспектам жизни. Иногда безжалостный, жестокий, самодовольный. Руководя группой, заставляет ее работать на практической и реалистической основе."; }
            if (_sten >= 4 & _sten <= 5) { _result = "Сильный, независимый, полагается на себя, реалистичный, не терпит бессмысленности."; }
            if (_sten >= 6 & _sten <= 7) { _result = "Слабый, зависимый, недостаточно самостоятельный, беспомощный, сензитивный."; }
            if (_sten >= 8 & _sten <= 10) { _result = "Слабый, мечтательный, разборчивый, капризный, преобладает женственный тип, иногда требовательный к вниманию, помощи, зависимый, непрактичный. Не любит грубых людей и грубых профессий. Склонен замедлять деятельность группы и нарушать ее моральное состояние нереалистическим копанием в мелочах и деталях."; }

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
