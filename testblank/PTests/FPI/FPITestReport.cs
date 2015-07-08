using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DW.RtfWriter;
using Recog.DocPrinter;
using Recog.Data;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;

namespace Recog.PTests.FPI
{
    public class FPITestReport : RtfPrinter, ITestReport
    {
        private List<IScale> _listscales;
        private human _human;
        private testresult _testresult;
        private pBaseEntities _ge;
        private fBaseEntities _fe;
        private bool _withresult;
        public FPITestReport(human human, testresult testresult, pBaseEntities ge, fBaseEntities fe, bool WithResult)
      {
          _testresult = testresult;
          _human = human;
          _ge = ge;
          _fe = fe;
          _withresult = WithResult;
          _listscales = new List<IScale>();
          _listscales.Add(new FPIScaleI(this.GetAnswersFromBase(),_ge));
          _listscales.Add(new FPIScaleII(this.GetAnswersFromBase(), _ge));
          _listscales.Add(new FPIScaleIII(this.GetAnswersFromBase(), _ge));
          _listscales.Add(new FPIScaleIV(this.GetAnswersFromBase(), _ge));
          _listscales.Add(new FPIScaleV(this.GetAnswersFromBase(), _ge));
          _listscales.Add(new FPIScaleVI(this.GetAnswersFromBase(), _ge));
          _listscales.Add(new FPIScaleVII(this.GetAnswersFromBase(), _ge));
          _listscales.Add(new FPIScaleVIII(this.GetAnswersFromBase(), _ge));
          _listscales.Add(new FPIScaleIX(this.GetAnswersFromBase(), _ge));
          _listscales.Add(new FPIScaleX(this.GetAnswersFromBase(), _ge));
          _listscales.Add(new FPIScaleXI(this.GetAnswersFromBase(), _ge));
          _listscales.Add(new FPIScaleXII(this.GetAnswersFromBase(), _ge));
      }


        public void Print(bool WaitForExit = false)
        {
            string filename = _human.secondname.ToString() + "_" + _human.firstname.ToString() + "_" +
                _testresult.testdate.Date.ToShortDateString() + "_" + _testresult.testdate.Hour.ToString() + "_" +
                _testresult.testdate.Minute.ToString() + GetHashCode().ToString() + "_FPI.rtf";
            base.CreateDoc(filename);
           
            base.TypeParagraph(14, Align.Center, "Профиль личности FPI");
            base.TypeParagraph(12, Align.Left, "");
            base.TypeParagraph(12, Align.Left, "");
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

                base.TypeParagraph(10, Align.Center, _listscales[i].Name);
                base.TypeParagraph(10, Align.Center, "(" + _listscales[i].Description + "):");
                base.TypeParagraph(10, Align.Left, "Баллы: " + _listscales[i].Mark + " [Стены: " + _listscales[i].Stens + "]" + " {Уровень: " + _listscales[i].Level + "}");
                if (_withresult == true) { base.TypeParagraph(10, Align.FullyJustify, "Оценка: " + _listscales[i].ResultDescription); }
            }
            base.TypeParagraph(12, Align.Left, "");
            base.TypeParagraph(12, Align.Left, "Результаты теста проверены: ");

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

        private FPIAnswers GetAnswersFromBase()
        {
            FPIAnswers _answersfrombase;
            XmlSerializer mySerializer = new XmlSerializer(typeof(FPIAnswers));
            StringReader sr = new StringReader(_testresult.teststream);
            _answersfrombase = (FPIAnswers)mySerializer.Deserialize(sr);
            return _answersfrombase;

        }



    }
}
