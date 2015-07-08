﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DW.RtfWriter;
using Recog.DocPrinter;
using Recog.Data;
using System.Diagnostics;
using System.Xml.Serialization;
using System.IO;
using Recog.PTests.D.Scales;
using System.Threading.Tasks;
using System.Threading;
namespace Recog.PTests.D
{
    public class DTestReport : RtfPrinter, ITestReport
    {

        private List<IScale> _listscales;
        private human _human;
        private testresult _testresult;
        private pBaseEntities _ge;
        private fBaseEntities _fe;
        private bool _withresult;
        public DTestReport(human human, testresult testresult, pBaseEntities ge, fBaseEntities fe, bool WithResult)
      {
          _testresult = testresult;
          _human = human;
          _ge = ge;
          _fe = fe;
          _withresult = WithResult;
          _listscales = new List<IScale>();
            // 1 level
          _listscales.Add(new DScaleL(GetAnswersFromBase(), _ge));
          _listscales.Add(new DScaleF(GetAnswersFromBase(), _ge));
          _listscales.Add(new DScaleK(GetAnswersFromBase(), _ge));
          _listscales.Add(new DScaleHS(GetAnswersFromBase(), _ge, new DScaleK(GetAnswersFromBase(), _ge)));
          _listscales.Add(new DScaleD(GetAnswersFromBase(), _ge));
          _listscales.Add(new DScaleHY(GetAnswersFromBase(), _ge));
          _listscales.Add(new DScalePD(GetAnswersFromBase(), _ge, new DScaleK(GetAnswersFromBase(), _ge)));
          _listscales.Add(new DScaleMF(GetAnswersFromBase(), _ge));
          _listscales.Add(new DScalePA(GetAnswersFromBase(), _ge));
          _listscales.Add(new DScalePT(GetAnswersFromBase(), _ge, new DScaleK(GetAnswersFromBase(), _ge)));
          _listscales.Add(new DScaleSC(GetAnswersFromBase(), _ge, new DScaleK(GetAnswersFromBase(), _ge)));
          _listscales.Add(new DScaleMA(GetAnswersFromBase(), _ge, new DScaleK(GetAnswersFromBase(), _ge)));
          _listscales.Add(new DScaleSI(GetAnswersFromBase(), _ge));
            //2 level
          _listscales.Add(new DScaleAC(GetAnswersFromBase(), _ge));
          _listscales.Add(new DScalePC(GetAnswersFromBase(), _ge));
          _listscales.Add(new DScaleDAN(GetAnswersFromBase(), _ge));
            //3 level
          _listscales.Add(new DScaleDS(GetAnswersFromBase(), _ge));
          _listscales.Add(new DScaleNPU(GetAnswersFromBase(), _ge));
          _listscales.Add(new DScaleCS(GetAnswersFromBase(), _ge));
          _listscales.Add(new DScaleMN(GetAnswersFromBase(), _ge));
            //4 level
          _listscales.Add(new DScaleLAP(GetAnswersFromBase(), _ge));
        //  _listscales.Add(new  DScaleKL(GetAnswersFromBase(),_human, _ge));
      }


        public void Print(bool WaitForExit = false)
        {
            base.SplashShow();
            string filename = _human.secondname.ToString() + "_" + _human.firstname.ToString() + "_" +
                _testresult.testdate.Date.ToShortDateString() + "_" + _testresult.testdate.Hour.ToString() + "_" +
                _testresult.testdate.Minute.ToString() + GetHashCode().ToString() + "_Адаптивность.rtf";
            base.CreateDoc(filename);
            doc.Margins[Direction.Top] = 30;
            doc.Margins[Direction.Bottom] = 30;
            doc.Margins[Direction.Left] = 50;
            doc.Margins[Direction.Right] = 30;
            base.TypeParagraph(14, Align.Center, "Опросник Адаптивность");
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

                base.TypeParagraph(10, Align.Center, _listscales[i].Name + " (" + _listscales[i].Description + "):");
                base.TypeParagraph(10, Align.Left, "Баллы: " + _listscales[i].Mark + " [Стены или Т-баллы: " + _listscales[i].Stens + "]" + " {Уровень: " + _listscales[i].Level + "}");
                if (_withresult == true) { this.TypeParagraph(10, Align.FullyJustify, "Оценка: " + _listscales[i].ResultDescription); }
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


        private DAnswers GetAnswersFromBase()
        {
            DAnswers _answersfrombase;
            XmlSerializer mySerializer = new XmlSerializer(typeof(DAnswers));
            StringReader sr = new StringReader(_testresult.teststream);
            _answersfrombase = (DAnswers)mySerializer.Deserialize(sr);
            return _answersfrombase;

        }

    }
}