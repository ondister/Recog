using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.Kettell
{

    public class KettellScaleQ1 : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private KettellAnswers _answers;
        private pBaseEntities _ge;
      private EnumKettellType _ktype;
        public KettellScaleQ1(KettellAnswers KettellAnswers,pBaseEntities GlobalEntities,EnumKettellType KType)
        {
            _answers = KettellAnswers;
            _ge = GlobalEntities;
            _ktype = KType;
        }
        public string Name
        {
            get { return "Фактор Q1"; }
        }

        public string Description
        {
            get { return "«консерватизм – радикализм»"; }
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
               for (int i = 14; i <= 99; i += 17)
               {
                   ans.Add(i);
               }
           }
           else
           {
               ans = new List<int>() { 20, 21, 45, 46, 70, 95, 120, 145, 169, 170 };
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
            if ( _mark <= 4) { _sten = 1; }
            if (_mark ==5) { _sten = 2; }
            if (_mark ==6) { _sten = 3; }
            if (_mark ==7) { _sten = 5; }
            if (_mark ==8) { _sten = 6; }
            if (_mark ==9) { _sten = 7; }
            if (_mark ==10) { _sten = 8; }
            if (_mark ==11) { _sten = 9; }
            if (_mark >=12) { _sten = 10; }
            }
            else
            {
                if (_mark <= 4) { _sten = 1; }
                if (_mark ==5) { _sten = 2; }
                if (_mark ==6) { _sten = 3; }
                if (_mark >= 7 & _mark <= 8) { _sten = 4; }
                if (_mark ==9) { _sten = 5; }
                if (_mark==10) { _sten = 6; }
                if (_mark >= 11 & _mark <= 12) { _sten = 7; }
                if (_mark ==13) { _sten = 8; }
                if (_mark >= 14 & _mark <= 15) { _sten = 9; }
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
            if (_sten >= 1 & _sten <= 3) { _result = "Убежден в правильности того, чему его учили, и принимает все как проверенное, несмотря на противоречия. Склонен к осторожности и к компромиссам в отношении новых людей. Имеет тенденцию препятствовать и противостоять изменениям и откладывать их, придерживается традиций."; }
            if (_sten >= 4 & _sten <= 5) { _result = "Консервативный, уважающий принципы, терпимый к традиционным трудностям."; }
            if (_sten >= 6 & _sten <= 7) { _result = "Экспериментирующий, критический, либеральный, аналитический, свободно мыслящий."; }
            if (_sten >= 8 & _sten <= 10) { _result = "Поглощен интеллектуальными проблемами, имеет сомнения по различным фундаментальным вопросам. Он скептичен и старается вникнуть в сущность идей старых и новых. Он часто лучше информирован, менее склонен к морализированию, более – к эксперименту в жизни, терпим к несообразностям и к изменениям."; }

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
