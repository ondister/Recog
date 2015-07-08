using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.Kettell
{

    public class KettellScaleQ3 : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private KettellAnswers _answers;
        private pBaseEntities _ge;
       private EnumKettellType _ktype;
        public KettellScaleQ3(KettellAnswers KettellAnswers,pBaseEntities GlobalEntities,EnumKettellType KType)
        {
            _answers = KettellAnswers;
            _ge = GlobalEntities;
            _ktype = KType;
        }
        public string Name
        {
            get { return "Фактор Q3"; }
        }

        public string Description
        {
            get { return "«низкий самоконтроль – высокий самоконтроль»"; }
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
                for (int i = 16; i <= 101; i += 17)
                {
                    ans.Add(i);
                }
            }
            else
            {
                ans = new List<int>() { 23, 24, 48, 73, 98, 123, 147, 148, 172, 173 };
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
            if ( _mark <= 2) { _sten = 1; }
            if (_mark ==3) { _sten = 2; }
            if (_mark ==4) { _sten = 3; }
            if (_mark ==5) { _sten = 4; }
            if (_mark ==6) { _sten = 5; }
            if (_mark ==7) { _sten = 6; }
            if (_mark ==8) { _sten = 7; }
            if (_mark ==9) { _sten = 8; }
            if (_mark ==10) { _sten = 9; }
            if (_mark >=11) { _sten = 10; }
            }
            else
            {
                if (_mark <= 3) { _sten = 1; }
                if (_mark >= 4 & _mark <= 5) { _sten = 2; }
                if (_mark ==6) { _sten = 3; }
                if (_mark >= 7 & _mark <= 8) { _sten = 4; }
                if (_mark >= 9 & _mark <=10) { _sten = 5; }
                if (_mark ==11) { _sten = 6; }
                if (_mark >= 12 & _mark <= 13) { _sten = 7; }
                if (_mark==14) { _sten = 8; }
                if (_mark >= 15 & _mark <= 16) { _sten = 9; }
                if (_mark >= 17 & _mark <= 20) { _sten = 10; }
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
            if (_sten >= 1 & _sten <= 3) { _result = "Не способен руководствуется волевым контролем, не обращает внимания на социальные требования, невнимателен к другим. Может чувствовать себя недостаточно приспособленным."; }
            if (_sten >= 4 & _sten <= 5) { _result = "Внутренне недисциплинированный, внутренняя конфликтность представлений о себе."; }
            if (_sten >= 6 & _sten <= 7) { _result = "Контролируемый, социально точный, следующий «Я»-образу. Доводит дело до конца. Целенаправлен."; }
            if (_sten >= 8 & _sten <= 10) { _result = "Имеет тенденцию к сильному контролю своих эмоций и общего поведения. Социально внимателен и тщателен; проявляет то, что обычно называют «самоуважением», и заботу о социальной репутации. Иногда, однако, склонен к упрямству."; }

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
