using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.Kettell
{

    public class KettellScaleE : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private KettellAnswers _answers;
        private pBaseEntities _ge;
        private EnumKettellType _ktype;
        public KettellScaleE(KettellAnswers KettellAnswers,pBaseEntities GlobalEntities,EnumKettellType KType)
        {
            _answers = KettellAnswers;
            _ge = GlobalEntities;
            _ktype = KType;
        }
        public string Name
        {
            get { return "Фактор Е"; }
        }

        public string Description
        {
            get { return "«подчиненность-доминантность»"; }
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
                 for (int i = 5; i <= 90; i += 17)
                 {
                     ans.Add(i);
                 }
             }
             else
             { ans = new List<int>() { 6, 7, 31, 32, 56, 57, 81, 106, 131, 155, 156, 180, 181 }; }
            _mark = KettellMarkExtractor.GetMark(_ge, _answers, ans, _ktype);
         this.GetSten();
         this.GetLevel();
         this.GetResult();
          

        }

       public void GetSten()
        {
            if (_ktype == EnumKettellType.CForm)
            {
                if (_mark <= 1) { _sten = 1; }
                if (_mark == 2) { _sten = 2; }
                if (_mark == 3) { _sten = 3; }
                if (_mark == 4) { _sten = 4; }
                if (_mark == 5) { _sten = 5; }
                if (_mark == 6) { _sten = 6; }
                if (_mark == 7) { _sten = 7; }
                if (_mark == 8) { _sten = 8; }
                if (_mark == 9) { _sten = 9; }
                if (_mark >= 10) { _sten = 10; }
            }
            else 
            {
                if (_mark <= 5) { _sten = 1; }
                if (_mark >= 7 & _mark <= 8) { _sten = 2; }
                if (_mark ==9) { _sten = 3; }
                if (_mark >= 10 & _mark <= 11) { _sten = 4; }
                if (_mark >= 12 & _mark <= 13) { _sten = 5; }
                if (_mark >= 14 & _mark <= 16) { _sten = 6; }
                if (_mark >= 17 & _mark <= 18) { _sten = 7; }
                if (_mark == 19) { _sten = 8; }
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
            if (_sten >= 1 & _sten <= 3) { _result = "Способен уступать другим, покорный. Часто зависим, признает свою вину. Стремится к навязчивому соблюдению корректности, правил. Эта пассивность является частью многих невротических синдромов."; }
            if (_sten >= 4 & _sten <= 5) { _result = "Скромный, покорный, мягкий, уступчивый, податливый, конформный, приспособляющийся."; }
            if (_sten >= 6 & _sten <= 7) { _result = "Самоутверждающийся, независимый, агрессивный, упрямый (доминантный)."; }
            if (_sten >= 8 & _sten <= 10) { _result = "Утверждающий себя, свое «Я», самоуверенный, независимо мыслящий. Склонен к аскетизму, руководствуется собственными правилами поведения, враждебный, авторитарный, командует другими, не признает авторитетов."; }

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
