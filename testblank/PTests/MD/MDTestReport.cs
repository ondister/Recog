using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DW.RtfWriter;
using Recog.DocPrinter;
using Recog.Data;
using System.Diagnostics;
using System.Xml.Serialization;
using System.IO;
using Recog.PTests.MD.Scales;
namespace Recog.PTests.MD
{
    public class MDTestReport : RtfPrinter, ITestReport
    {

        private List<IScale> _listscales;
        private human _human;
        private testresult _testresult;
        private pBaseEntities _ge;
        private fBaseEntities _fe;
        private bool _withresult;
        public MDTestReport(human human, testresult testresult, pBaseEntities ge, fBaseEntities fe, bool WithResult)
        {
            _testresult = testresult;
            _human = human;
            _ge = ge;
            _fe = fe;
            _withresult = WithResult;
            _listscales = new List<IScale>();
            int ages = (_testresult.testdate.Date - _human.birthday.Value.Date).Days / 365;
            MDAnswers _answers = GetAnswersFromBase();
            MDScaleAnamnes _anamnes = new MDScaleAnamnes(_answers, _ge);
            MDScaleLie _lie = new MDScaleLie(_answers, _ge);
            MDScaleM1_1 _m1_1 = new MDScaleM1_1(_answers, _ge);
            MDScaleM1_2 _m1_2 = new MDScaleM1_2(_answers, _ge);
            MDScaleM1 _m1 = new MDScaleM1(_answers, _ge, _m1_1, _m1_2);

            MDScaleM2 _m2 = new MDScaleM2(_answers, _ge);
            MDScaleM2_1 _m2_1 = new MDScaleM2_1(_answers, _ge);
            MDScaleM2_2 _m2_2 = new MDScaleM2_2(_answers, _ge);
            MDScaleM2_3 _m2_3 = new MDScaleM2_3(_answers, _ge);

            MDScaleM3 _m3 = new MDScaleM3(_answers, _ge);
            MDScaleM3_1 _m3_1 = new MDScaleM3_1(_answers, _ge);
            MDScaleM3_2 _m3_2 = new MDScaleM3_2(_answers, _ge);
            MDScaleM3_3 _m3_3 = new MDScaleM3_3(_answers, _ge);
            MDScaleM3_4 _m3_4 = new MDScaleM3_4(_answers, _ge);
            MDScaleM3_5 _m3_5 = new MDScaleM3_5(_answers, _ge);
            MDScaleM3_6 _m3_6 = new MDScaleM3_6(_answers, _ge);

            MDScaleIntegral _integral = new MDScaleIntegral(_anamnes, _lie, _m1, _m2, _m3);

            _listscales.Add(_lie);
            _listscales.Add(_anamnes);
            _listscales.Add(_m1);
            if (_withresult == true)
            {
                _listscales.Add(_m1_1);
                _listscales.Add(_m1_2);
            }
            _listscales.Add(_m2);
            if (_withresult == true)
            {
                _listscales.Add(_m2_1);
                _listscales.Add(_m2_2);
                _listscales.Add(_m2_3);
            }
            _listscales.Add(_m3);
            if (_withresult == true)
            {
                _listscales.Add(_m3_1);
                _listscales.Add(_m3_2);
                _listscales.Add(_m3_3);
                _listscales.Add(_m3_4);
                _listscales.Add(_m3_5);
                _listscales.Add(_m3_6);
            }
            _listscales.Add(_integral);
        }


        public void Print(bool WaitForExit = false)
        {
            base.SplashShow();
            string filename = _human.secondname.ToString() + "_" + _human.firstname.ToString() + "_"
                + _testresult.testdate.Date.ToShortDateString() + "_" + _testresult.testdate.Hour.ToString() + "_"
                + _testresult.testdate.Minute.ToString() + GetHashCode().ToString() + "_Модуль_2.rtf";
            base.CreateDoc(filename);
            doc.Margins[Direction.Top] = 30;
            doc.Margins[Direction.Bottom] = 30;
            doc.Margins[Direction.Left] = 50;
            doc.Margins[Direction.Right] = 30;
            base.TypeParagraph(14, Align.Center, "Психопатологический опросник Модуль 2", true);
            base.TypeParagraph(12, Align.Center, "");
            base.TypeParagraph(12, Align.Left, "Дата проведения теста: " + _testresult.testdate.ToString());
            base.TypeParagraph(12, Align.Left, "ФИО: " + _human.secondname.ToString() + " " + _human.firstname.ToString() + " " + _human.lastname.ToString());
            base.TypeParagraph(12, Align.Left, "Дата рождения: " + _human.birthday.Value.Date.ToLongDateString() + " (" + ((_testresult.testdate.Date - _human.birthday.Value.Date).Days / 365) + ")");
            base.TypeParagraph(12, Align.Left, "Пол: " + _fe.gensers.First(g => g.idg == _human.genderid).description);
            base.TypeParagraph(12, Align.Left, "Образование: " + _fe.educations.First(e => e.ide == _human.educationid).description);
            base.TypeParagraph(12, Align.Left, "Подразделение: " + _fe.departments.First(d => d.idd == _human.departmentid).description);
            if (_human.additinfo.Length != 0)
            {
                base.TypeParagraph(12, Align.Left, "Дополнительная информация: " + _human.additinfo);
            }
            base.TypeParagraph(12, Align.Left, "");



            for (int i = 0; i < _listscales.Count(); i++)
            {
                _listscales[i].GetMark();

                base.TypeParagraph(12, Align.Center, _listscales[i].Name + " (" + _listscales[i].Description + "):", true);

                if (i == 0)
                {
                    base.TypeParagraph(12, Align.Left, "Баллы: " + _listscales[i].Mark + " [Стены: " + _listscales[i].Stens + "]");
                }


                if (_withresult == true)
                {
                    if (i == 1 | i == 2 | i == 5 | i == 9 | i == 16) { base.TypeParagraph(12, Align.Left, "Баллы: " + _listscales[i].Mark + " [Стены: " + _listscales[i].Stens + "]" + " {Уровень: " + _listscales[i].Level + "}"); }
                }

                if (_withresult == false)
                {
                    if (i == 1 | i == 2 | i == 3 | i == 4 | i == 5) { base.TypeParagraph(12, Align.Left, "Баллы: " + _listscales[i].Mark + " [Стены: " + _listscales[i].Stens + "]" + " {Уровень: " + _listscales[i].Level + "}"); }
                }


                if (_withresult == true)
                {
                    foreach (string result in _listscales[i].MultiResult)
                    {
                        this.TypeParagraph(12, Align.FullyJustify, result);
                    }
                }
                base.TypeParagraph(12, Align.Left, "");
            }

            base.TypeParagraph(12, Align.Left, "");
            base.TypeParagraph(12, Align.Left, "Результаты теста проверены: ");

            base.SplashHide();
            base.SaveDoc();
            base.OpenDoc(WaitForExit);
        }

        public void Save(string filename)
        {
            doc.save(filename);
        }

        public List<IScale> ListScales
        {
            get { return _listscales; }
        }

        public human Human
        {
            get { return _human; }
        }

        public testresult TestResult
        {
            get { return _testresult; }
        }

        public void GetMarks()
        {
            for (int i = 0; i < _listscales.Count(); i++) { _listscales[i].GetMark(); }
        }


        private MDAnswers GetAnswersFromBase()
        {
            MDAnswers _answersfrombase;
            XmlSerializer mySerializer = new XmlSerializer(typeof(MDAnswers));
            StringReader sr = new StringReader(_testresult.teststream);
            _answersfrombase = (MDAnswers)mySerializer.Deserialize(sr);
            return _answersfrombase;

        }

    }
}
