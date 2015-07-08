using System;
using System.Collections.Generic;
using Recog.Data;
using System.Linq;
namespace Recog.PTests.MD.Scales
{

    public class MDScaleM1_2 : IScale
    {
        private double _mark;
        private int _sten;
         
        private string _result;
        private string _level;
        private MDAnswers _answers;
        private pBaseEntities _ge;
        List<int> _ans;
        private List<string> _multiresult;
        public MDScaleM1_2(MDAnswers mdAnswers, pBaseEntities GlobalEntities)
        {
            _answers = mdAnswers;
            _ge = GlobalEntities;
        }
        public string Name
        {
            get { return "Группа B (F30-39)"; }
        }

        public string Description
        {
            get { return "«Аффективные расстройства настроения»"; }
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

           _ans = new List<int>() { 10, 11, 14, 49, 55, 57, 65, 67, 69, 84, 126, 128, 147, 148, 151, 153, 157, 162, 187, 190, 192, 206, 209, 231 };
            _mark = MDMarkExtractor.GetMark(_ge, _answers, _ans);

            this.GetSten();
            this.GetLevel();
            this.GetResult();
            this.GetMultiResult();

        }

       public void GetSten()
        {
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
                        _sten++;
                    }
                }
            }
        }

       public void GetLevel()
        {
            if (_sten != 0) { _level = "Обратите внимание"; }
            else { _level = "Без патологии"; }
            
        }
        public void GetResult()
        {

          if (_sten == 0) { _result = "Расстройств не выявлено."; }
          else if (_sten == _ans.Count)
            {
                _result = "Mожно говорить о соответствии диагностическим критериям рубрик F30-39 «Аффективные расстройства настроения» (группа В).";
            }
            else
            {
                _result += " Контрольные вопросы шкалы: ";

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
        }


        public List<string> MultiResult
        {
            get { return _multiresult; }
        }

        public void GetMultiResult()
        {
            _multiresult = new List<string>();

            if (_sten == 0) { _multiresult.Add("Расстройств не выявлено."); }
            else if (_sten == _ans.Count)
            {
                _multiresult.Add("Mожно говорить о соответствии диагностическим критериям рубрик F30-39 «Аффективные расстройства настроения» (группа В).");
            }
            else
            {
                _multiresult.Add("Контрольные вопросы шкалы: ");

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
