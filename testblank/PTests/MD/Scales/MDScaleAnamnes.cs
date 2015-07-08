using System;
using System.Collections.Generic;
using Recog.Data;
using System.Linq;
namespace Recog.PTests.MD.Scales
{

    public class MDScaleAnamnes : IScale
    {
        private double _mark;
        private int _sten;

        private string _result;
        private string _level;
        private MDAnswers _answers;
        private pBaseEntities _ge;
        private List<int> _ans;
        private List<string> _multiresult;
        public MDScaleAnamnes(MDAnswers mdAnswers, pBaseEntities GlobalEntities)
        {
            _answers = mdAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Анамнез жизни"; }
        }

        public string Description
        {
            get { return "«Анамнестический блок вопросов»"; }
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

            _ans = new List<int>() { 21, 25, 44, 53, 60, 63, 82, 94, 101, 127, 136, 146, 178, 185, 193, 203, 207, 214, 219, 226, 232 };
            _mark = MDMarkExtractor.GetMark(_ge, _answers, _ans);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
            this.GetMultiResult();

        }

        public void GetSten()
        {
          
                if (_mark >= 14) { _sten = 1; }
                if (_mark <= 13 & _mark >= 11) { _sten = 2; }
                if (_mark == 10 | _mark == 9) { _sten = 3; }
                if (_mark == 8) { _sten = 4; }
                if (_mark == 7 | _mark == 6) { _sten = 5; }
                if (_mark == 5 | _mark == 4) { _sten = 6; }
                if (_mark == 3) { _sten = 7; }
                if (_mark == 2) { _sten = 8; }
                if (_mark == 1) { _sten = 9; }
                if (_mark == 0) { _sten = 10; }
           
        }

        public void GetLevel()
        {
            if (_sten >= 1 & _sten <= 3) { _level = "Неудовлетворительный уровень НПУ"; }
            if (_sten >= 4 & _sten <= 5) { _level = "Удовлетворительный уровень НПУ"; }
            if (_sten >= 6 & _sten <= 8) { _level = "Хороший уровень НПУ"; }
            if (_sten >= 9 & _sten <= 10) { _level = "Высокий уровень НПУ"; }

        }
        public void GetResult()
        {
            if (_mark != 0)
            {
                _result = "В анамнезе жизни установлено:";
                testsparam t = _ge.testsparams.First(tp => tp.idt == (int)EnumPTests.Modul2);
                t.answersparams.Load();

                for (int i = 0; i < _ans.Count; i++)
                {
                    answersparam a = t.answersparams.First(ap => ap.num == _ans[i]);
                    a.cellsparams.Load();
                    if (_answers[_ans[i] - 1].SelectedCellDescription.Trim() != "")
                    {
                        cellsparam selectedcell = a.cellsparams.First(cell => cell.description == _answers[_ans[i] - 1].SelectedCellDescription);

                        if (selectedcell.mark != 0)
                        {
                            _result += a.buttondescription + ": " + selectedcell.description;
                            if (i != _ans.Count - 1)
                            {
                                _result += ", ";
                            }
                        }
                    }
                }
                
            }
            else
            { _result = "В анамнезе психопатологических признаков не выявлено."; }
        }

        public List<string> MultiResult
        {
            get { return _multiresult; }
        }

        public void GetMultiResult()
        {
            _multiresult = new List<string>();

            if (_mark == 0) { _multiresult.Add("В анамнезе психопатологических признаков не выявлено."); }
            {
                _multiresult.Add("В анамнезе жизни установлено:");

                testsparam t = _ge.testsparams.First(tp => tp.idt == (int)EnumPTests.Modul2);
                t.answersparams.Load();

                for (int i = 0; i < _ans.Count; i++)
                {
                    answersparam a = t.answersparams.First(ap => ap.num == _ans[i]);
                    a.cellsparams.Load();
                    if (_answers[_ans[i] - 1].SelectedCellDescription.Trim() != "")
                    {
                        cellsparam selectedcell = a.cellsparams.First(cell => cell.description == _answers[_ans[i] - 1].SelectedCellDescription);

                        if (selectedcell.mark != 0)
                        {
                            _multiresult.Add(a.buttondescription + ": " + selectedcell.description);

                        }
                    }
                }
            }
        }
    }
}
