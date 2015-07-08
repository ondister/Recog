using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recog.PTests.PNN
{
    public class PNNScale : IScale
    {
      private double _mark;
      private int _sten;
      private string _result;
      private string _level;
      private PNNAnswers _answers;
      public PNNScale(PNNAnswers Answers)
      {
          _answers = Answers;
      }
        public string Name
        {
            get { return "Шкала ПНН"; }
        }

        public string Description
        {
            get { return "Показатель функциональности подвижности нервных процессов"; }
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
            _mark = _answers.Count;
             
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
            if (_mark <= 152) { _sten = 1;  }
            if (_mark >= 153 & _mark <= 165) { _sten = 2;  }
            if (_mark >= 166 & _mark <= 175) { _sten = 3;  }
            if (_mark >= 176 & _mark <= 183) { _sten = 4;  }
            if (_mark >= 184 & _mark <= 193) { _sten = 5;  }
            if (_mark >= 194 & _mark <= 202) { _sten = 6; }
            if (_mark >= 203 & _mark <= 212) { _sten = 7;  }
            if (_mark >= 213 & _mark <= 222) { _sten = 8;  }
            if (_mark >= 223 & _mark <= 230) { _sten = 9;  }
            if (_mark >= 231) { _sten = 10; }
        }

        public void GetLevel()
        {
            if (_sten == 1)  {_level = "Низкий"; }
            if ( _sten == 2){ _level = "Низкий"; }
            if (_sten == 3) { _level = "Средний"; }
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

            if (_sten == 1) { _result = "Низкий показатель функциональности подвижности нервных процессов"; }
            if (_sten == 2) { _result = "Низкий показатель функциональности подвижности нервных процессов"; }
            if (_sten == 3) { _result = "Средний показатель функциональности подвижности нервных процессов"; }
            if (_sten == 4) { _result = "Средний показатель функциональности подвижности нервных процессов"; }
            if (_sten == 5) { _result = "Среднийпоказатель функциональности подвижности нервных процессов"; }
            if (_sten == 6) { _result = "Среднийпоказатель функциональности подвижности нервных процессов"; }
            if (_sten == 7) { _result = "Средний показатель функциональности подвижности нервных процессов"; }
            if (_sten == 8) { _result = "Высокий показатель функциональности подвижности нервных процессов"; }
            if (_sten == 9) { _result = "Высокий показатель функциональности подвижности нервных процессов"; }
            if (_sten == 10) { _result = "Высокий показатель функциональности подвижности нервных процессов"; }

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
