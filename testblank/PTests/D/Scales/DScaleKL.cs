using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
using System.Xml.Serialization;
using System.IO;

namespace Recog.PTests.D.Scales
{
    public class DScaleKL : IScale
    {
       private double _mark;
        private int _sten;
        private human _h;
        private string _result;
        private string _level;
        private DAnswers _answers;
        private pBaseEntities _ge;
        public DScaleKL(DAnswers DAnswers, human h, pBaseEntities GlobalEntities)
        {
            _answers = DAnswers;
            _ge = GlobalEntities;
            _h = h;
        }
        public string Name
        {
            get { return "Шкала Kl"; }
        }

        public string Description
        {
            get { return "Криминальность"; }
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

        public string ResultDescription
        {
            get { return _result; }
        }

        public string Level
        {
            get { return _level; }
        }

        public void GetSten()
        {
            _sten = (int)_mark;
        }

        public void GetMark()
        {

            List<IScale> _listscales = new List<IScale>();
            // 1 level
            _listscales.Add(new DScaleL(_answers, _ge));
            _listscales.Add(new DScaleF(_answers, _ge));
            _listscales.Add(new DScaleK(_answers, _ge));
            _listscales.Add(new DScaleHS(_answers, _ge, new DScaleK(_answers, _ge)));
            _listscales.Add(new DScaleD(_answers, _ge));
            _listscales.Add(new DScaleHY(_answers, _ge));
            _listscales.Add(new DScalePD(_answers, _ge, new DScaleK(_answers, _ge)));
            _listscales.Add(new DScaleMF(_answers, _ge));
            _listscales.Add(new DScalePA(_answers, _ge));
            _listscales.Add(new DScalePT(_answers, _ge, new DScaleK(_answers, _ge)));
            _listscales.Add(new DScaleSC(_answers, _ge, new DScaleK(_answers, _ge)));
            _listscales.Add(new DScaleMA(_answers, _ge, new DScaleK(_answers, _ge)));
            _listscales.Add(new DScaleSI(_answers, _ge));

            foreach (IScale s in _listscales)
            {
            s.GetMark();
            }
            if ((int)_h.educationid > 5) { throw new Exception("Образование не указано"); }
            int[] seduid = new int[5] { 2, 3, 4, 5, 1 };

            _mark = NeuralNet.GetCrime(seduid[(int)_h.educationid - 1], (int)_listscales[0].Mark, (int)_listscales[1].Mark, (int)_listscales[2].Mark, (int)_listscales[3].Mark, (int)_listscales[4].Mark, (int)_listscales[5].Mark, (int)_listscales[6].Mark, (int)_listscales[7].Mark, (int)_listscales[8].Mark, (int)_listscales[9].Mark, (int)_listscales[10].Mark, (int)_listscales[11].Mark, (int)_listscales[12].Mark);

            this.GetSten();
            this.GetLevel();
            this.GetResult();

        }

        public void GetLevel()
        {
            if (_sten ==0) { _level = "Низкий"; }
            if (_sten ==1) { _level = "Высокий"; }
        }
     
        public void GetResult()
        {
            if (_level == "Низкий") { _result = "Признаков криминального интеллекта не выявлено"; }
            if (_level == "Высокий") { _result = "Присутствуют признаки криминального интеллекта"; }
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
