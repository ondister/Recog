using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recog.PTests.Contrasts
{
  public  class ContrastsScale:IScale
    {
      double  _mark;
      private int _sten;
      private string _result;
      private string _level;
      private ContrastsAnswers _answers;
      public ContrastsScale(ContrastsAnswers Answers)
      {
          _answers = Answers;
      }
        public string Name
        {
            get { return "Шкала Контрасты"; }
        }

        public string Description
        {
            get { return "Коэффициент цветового предпочтения"; }
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

        public string ResultDescription
        {
            get 
            {
                return _result;
            }
        }

       


        public void GetMark()
        {
            int likemark = _answers[0].PictureId + _answers[1].PictureId + _answers[2].PictureId;
            int unlikemark = _answers[3].PictureId + _answers[4].PictureId + _answers[5].PictureId; ;


            _mark = Math.Round((double)likemark / (double)unlikemark,2);
             
            this.GetSten();
            this.GetLevel();
            this.GetResult();
          
        }


        public string Level
        {
            get { return _level; }
        }
        public void GetSten()
        {
            if (_mark <= 0.25) { _sten = 1;  }
            if (_mark >= 0.26 & _mark <=0.33) { _sten = 2;  }
            if (_mark >= 0.34 & _mark <= 0.39) { _sten = 3;  }
            if (_mark >= 0.40 & _mark <= 0.45) { _sten = 4;  }
            if (_mark >= 0.46 & _mark <= 0.61) { _sten = 5;  }
            if (_mark >= 0.62 & _mark <= 0.76) { _sten = 6; }
            if (_mark >=0.77 & _mark <= 1.14) { _sten = 7;  }
            if (_mark >= 1.15 & _mark <= 1.60) { _sten = 8;  }
            if (_mark >= 1.61 & _mark <= 2.77) { _sten = 9;  }
            if (_mark >= 2.78) { _sten = 10; }
        }

        public void GetLevel()
        {
            if (_sten == 1)  {_level = "Низкий"; }
            if ( _sten == 2){ _level = "Низкий"; }
            if (_sten == 3) { _level = "Низкий"; }
            if (_sten == 4){ _level = "Средний"; }
            if ( _sten == 5){  _level = "Средний"; }
            if ( _sten == 6){ _level = "Средний"; }
            if ( _sten == 7){ _level = "Средний"; }
            if ( _sten == 8){ _level = "Высокий"; }
            if ( _sten == 9){_level = "Высокий"; }
            if (_sten ==10) { _level = "Высокий"; }
        }

        public void GetResult()
        {

            if (_sten >= 1 & _sten <= 3) { _result = "Склонность к астеническим и астено-невротическим реакциям"; }
            if (_sten >= 4 & _sten <= 7) { _result = "Оптимальное психофизиологическое состояние"; }
            if (_sten >= 8 & _sten <= 10) { _result = "Склонность к стеническим реакциям"; }

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
