using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests.Kettell
{

    public class KettellScaleA : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private KettellAnswers _answers;
        private pBaseEntities _ge;
        private EnumKettellType _ktype;
        public KettellScaleA(KettellAnswers KettellAnswers,pBaseEntities GlobalEntities,EnumKettellType KType)
        {
            _answers = KettellAnswers;
            _ge = GlobalEntities;
            _ktype = KType;
        }
        public string Name
        {
            get { return "Фактор А"; }
        }

        public string Description
        {
            get { return "«замкнутость – общительность»"; }
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
                for (int i = 2; i <= 87; i += 17)
                {
                    ans.Add(i);
                }
            }
            else { ans = new List<int>() { 3, 26, 27, 51, 52, 76, 101, 126, 151, 176 }; }
         _mark=   KettellMarkExtractor.GetMark(_ge, _answers, ans,_ktype);
         this.GetSten();
         this.GetLevel();
         this.GetResult();
          

        }

       public void GetSten()
        {
            if (_ktype == EnumKettellType.CForm)
            {
                if (_mark <= 4) { _sten = 1; }
                if (_mark == 5) { _sten = 2; }
                if (_mark == 6) { _sten = 3; }
                if (_mark == 7) { _sten = 4; }
                if (_mark == 8) { _sten = 5; }
                if (_mark == 9) { _sten = 7; }
                if (_mark == 10) { _sten = 8; }
                if (_mark == 11) { _sten = 9; }
                if (_mark == 12) { _sten = 10; }
            }
            else 
            {
                if (_mark <= 3) { _sten = 1; }
                if (_mark == 4) { _sten = 2; }
                if (_mark >=5 & _mark<=6) { _sten = 3; }
                if (_mark ==7) { _sten = 4; }
                if (_mark >= 8 & _mark <= 9) { _sten = 5; }
                if (_mark >= 10 & _mark <= 11) { _sten = 6; }
                if (_mark >= 12 & _mark <= 13) { _sten = 7; }
                if (_mark ==14) { _sten = 8; }
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
            if (_sten >= 1 & _sten <= 3) { _result = "Склонен к ригидности, холодности, скептицизму и отчужденности. Вещи его привлекают больше, чем люди. Предпочитает работать сам, избегая компромиссов. Склонен к точности, ригидности в деятельности, личных установках. Во многих профессиях это желательно. Иногда он склонен быть критически настроенным, несгибаемым, твердым, жестким."; }
            if (_sten >= 4 & _sten <= 5) { _result = "Является человеком сдержанным, обособленный, критическим и холодный в общении."; }
            if (_sten >= 6 & _sten <= 7) { _result = "В общении обращенный вовне (экстраверт), легкий в общении, участвующий аффективно."; }
            if (_sten >= 8 & _sten <= 10) { _result = "Преобладает склонность к добродушию, легкости в общении, эмоциональному выражению. Готов к сотрудничеству, присутствует внимательность к людям, мягкосердечность, доброта, приспособляемость. Предпочитает ту деятельность, где есть занятия с людьми, ситуации с социальным значением. Легко включается в активные группы. Он щедр в личных отношениях, не боится критики. Хорошо запоминает события, фамилии, имена и отчества."; }

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
