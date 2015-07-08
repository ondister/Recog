using System;
using System.Collections.Generic;
using Recog.Data;
namespace Recog.PTests.MD.Scales
{

    public class MDScaleIntegral : IScale
    {
        private double _mark;
        private int _sten;

        private string _result;
        private string _level;

        MDScaleAnamnes _anamnes;
        MDScaleLie _lie;
        MDScaleM1 _m1;
        MDScaleM2 _m2;
        MDScaleM3 _m3;
        private List<string> _multiresult;

        public MDScaleIntegral(MDScaleAnamnes anamnes, MDScaleLie lie, MDScaleM1 m1, MDScaleM2 m2, MDScaleM3 m3)
        {
            _anamnes = anamnes;
            _lie = lie;
            _m1 = m1;
            _m2 = m2;
            _m3 = m3;
            
        }
        public string Name
        {
            get { return "Интегральный показатель"; }
        }

        public string Description
        {
            get { return "«Совокупность всех показателей»"; }
        }

        public double Mark
        {
            get
            {

                return _mark;
            }
            set { _mark = value; }
        }

        public int Stens
        {
            get
            {
                return _sten;
            }
            set { _sten = value; }
        }
        public string Level
        {

            get
            {

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

            _mark += _anamnes.Mark;
            _mark += _lie.Mark;
            _mark += _m1.Mark;
            _mark += _m2.Mark;
            _mark += _m3.Mark;
            this.GetSten();
            this.GetLevel();
            this.GetResult();
            this.GetMultiResult();

        }

        public void GetSten()
        {
                if (_mark > 97) { _sten = 1; }
                if (_mark <= 97 & _mark >= 84) { _sten = 2; }
                if (_mark <= 83 & _mark >= 72) { _sten = 3; }
                if (_mark <= 71 & _mark >= 59) { _sten = 4; }
                if (_mark <= 58 & _mark >= 47) { _sten = 5; }
                if (_mark <= 46 & _mark >= 37) { _sten = 6; }
                if (_mark <= 36 & _mark >= 25) { _sten = 7; }
                if (_mark <= 24 & _mark >= 12) { _sten = 8; }
                if (_mark <= 11 & _mark >= 1) { _sten = 9; }
                if (_mark ==0) { _sten = 10; }

           
        }

        public void GetLevel()
        {
            if (_sten >= 1 & _sten <= 3) { _level = "Неудовлетворительный уровень НПУ"; }
            if (_sten >= 4 & _sten <= 5) { _level = "Удовлетворительный уровень НПУ"; }
            if (_sten >= 6 & _sten <= 8) { _level = "Хороший уровень НПУ"; }
            if (_sten>=9) { _level = "Высокий уровень НПУ"; }

        }
        public void GetResult()
        {

            if (_sten >= 1 & _sten <= 3) { _result = "4-я категория НПУ"; }
            if (_sten >= 4 & _sten <= 5) { _result = "3-я категория НПУ"; }
            if (_sten >= 6 & _sten <= 8) { _result = "2-я категория НПУ"; }
            if (_sten >= 9) { _result = "1-я категория НПУ"; }
           
        }


        public List<string> MultiResult
        {
            get { return _multiresult; }
        }

        public void GetMultiResult()
        {
            _multiresult = new List<string>();
            if (_sten >= 1 & _sten <= 3) { _multiresult.Add( "4-я категория НПУ"); }
            if (_sten >= 4 & _sten <= 5) { _multiresult.Add("3-я категория НПУ"); }
            if (_sten >= 6 & _sten <= 8) { _multiresult.Add( "2-я категория НПУ"); }
            if (_sten >= 9) { _multiresult.Add( "1-я категория НПУ"); }
        }
    }
}
