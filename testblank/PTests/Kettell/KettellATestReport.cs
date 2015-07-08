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

namespace Recog.PTests.Kettell
{
    public class KettellATestReport : RtfPrinter, ITestReport
    {

        private List<IScale> _listscales;
        private human _human;
        private testresult _testresult;
        private pBaseEntities _ge;
        private fBaseEntities _fe;
        private bool _withresult;
        public KettellATestReport(human human, testresult testresult, pBaseEntities ge, fBaseEntities fe, bool WithResult)
        {
            _testresult = testresult;
            _human = human;
            _ge = ge;
            _fe = fe;
            _withresult = WithResult;
            _listscales = new List<IScale>();
            _listscales.Add(new KettellScaleA(this.GetAnswersFromBase(), _ge,EnumKettellType.AForm));
            _listscales.Add(new KettellScaleB(this.GetAnswersFromBase(), _ge, EnumKettellType.AForm));
            _listscales.Add(new KettellScaleC(this.GetAnswersFromBase(), _ge, EnumKettellType.AForm));
            _listscales.Add(new KettellScaleE(this.GetAnswersFromBase(), _ge, EnumKettellType.AForm));
            _listscales.Add(new KettellScaleF(this.GetAnswersFromBase(), _ge, EnumKettellType.AForm));
            _listscales.Add(new KettellScaleG(this.GetAnswersFromBase(), _ge, EnumKettellType.AForm));
            _listscales.Add(new KettellScaleH(this.GetAnswersFromBase(), _ge, EnumKettellType.AForm));
            _listscales.Add(new KettellScaleI(this.GetAnswersFromBase(), _ge, EnumKettellType.AForm));
            _listscales.Add(new KettellScaleL(this.GetAnswersFromBase(), _ge, EnumKettellType.AForm));
            _listscales.Add(new KettellScaleM(this.GetAnswersFromBase(), _ge, EnumKettellType.AForm));
            _listscales.Add(new KettellScaleN(this.GetAnswersFromBase(), _ge, EnumKettellType.AForm));
            _listscales.Add(new KettellScaleO(this.GetAnswersFromBase(), _ge, EnumKettellType.AForm));
            _listscales.Add(new KettellScaleQ1(this.GetAnswersFromBase(), _ge, EnumKettellType.AForm));
            _listscales.Add(new KettellScaleQ2(this.GetAnswersFromBase(), _ge, EnumKettellType.AForm));
            _listscales.Add(new KettellScaleQ3(this.GetAnswersFromBase(), _ge, EnumKettellType.AForm));
            _listscales.Add(new KettellScaleQ4(this.GetAnswersFromBase(), _ge, EnumKettellType.AForm));
           
        }

        public void Print(bool WaitForExit = false)
        {
            //rtf generating
            string filename = _human.secondname.ToString() + "_" + _human.firstname.ToString() + "_" 
                + _testresult.testdate.Date.ToShortDateString() + "_" + _testresult.testdate.Hour.ToString() + "_"
                + _testresult.testdate.Minute.ToString() + GetHashCode().ToString() + "_КеттеллА.rtf";
            base.CreateDoc(filename);

            base.TypeParagraph(14, Align.Center, "Многофакторный личностный опросник Кеттелла форма А");
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

              
                if (_withresult == true)
                {
                    base.TypeParagraph(10, Align.FullyJustify, "        " + _listscales[i].ResultDescription);
                }
                else
                {
                    base.TypeParagraph(10, Align.Center, _listscales[i].Name);
                    base.TypeParagraph(10, Align.Center, "(" + _listscales[i].Description + "):");
                    if (i == 1)
                    {
                        KettellScaleB b = (KettellScaleB)_listscales[i];
                        b.GetX();
                        base.TypeParagraph(10, Align.Left, "Баллы: " + b.Mark + " [Стены: " + b.Stens + ", X-баллы: " + b.X.ToString() + "]" + " {Уровень: " + b.Level + "}");
                    }
                    else if (i == 13)
                    {
                        KettellScaleQ2 q2 = (KettellScaleQ2)_listscales[i];
                        q2.GetX();
                        base.TypeParagraph(10, Align.Left, "Баллы: " + q2.Mark + " [Стены: " + q2.Stens + ", X-баллы: " + q2.X.ToString() + "]" + " {Уровень: " + q2.Level + "}");
                    }
                    else if (i == 15)
                    {
                        KettellScaleQ4 q4 = (KettellScaleQ4)_listscales[i];
                        q4.GetX();
                        base.TypeParagraph(10, Align.Left, "Баллы: " + q4.Mark + " [Стены: " + q4.Stens + ", X-баллы: " + q4.X.ToString() + "]" + " {Уровень: " + q4.Level + "}");
                    }
                    else
                    { base.TypeParagraph(10, Align.Left, "Баллы: " + _listscales[i].Mark + " [Стены: " + _listscales[i].Stens + "]" + " {Уровень: " + _listscales[i].Level + "}"); }
                    base.TypeParagraph(10, Align.FullyJustify, "Оценка: " + _listscales[i].ResultDescription); 
                }
              
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
        private KettellAnswers GetAnswersFromBase()
        {
            KettellAnswers _answersfrombase;
            XmlSerializer mySerializer = new XmlSerializer(typeof(KettellAnswers));
            StringReader sr = new StringReader(_testresult.teststream);
            _answersfrombase = (KettellAnswers)mySerializer.Deserialize(sr);
            return _answersfrombase;

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
    }
}
