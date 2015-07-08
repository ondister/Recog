using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.PTests;
using Recog.PTests.FPI;
using Recog.PTests.Kettell;
using Recog.PTests.PNN;
using Recog.PTests.References;
using Recog.PTests.D;
using Recog.PTests.ResultReader;
using Recog.PTests.MD;
using Recog.PTests.Prognoz;
using Recog.PTests.NPNA;
using Recog.PTests.Addictive;
using Recog.Data;
using System.Windows.Forms;
using Recog.PTests.Leongard;
namespace Recog.PTests.References
{
    public class ReferenceFactory
    {
        private human _human;
        private List<string[]> _evalrefs;
        private pBaseEntities _ge;
        private fBaseEntities _fe;
        private static Dictionary<EnumPReferences, string> _referencesdict;

        public List<string[]> EvalRefs
        {
            get { return _evalrefs; }
        }

        public ReferenceFactory(human human,pBaseEntities ge, fBaseEntities fe)
        {
            _ge = ge;
            _fe = fe;
            _human = human;
            _human.testresults.Load();
            _evalrefs = new List<string[]>();
            this.GetEvalRefs();
        }

        /// <summary>
        /// Определяет, какие тесны нужно отметить для выбранной характеристики
        /// </summary>
        /// <param name="SelectedRef">Выбранная характеристика</param>
        /// <returns></returns>
        public List<int> GetUsedTestIds(EnumPReferences SelectedRef)
        {
            List<int> _checkedtest = new List<int>();


            switch (SelectedRef)
            {
               
                case EnumPReferences.KettellC:
                    _checkedtest.Add(_human.testresults.LastOrDefault(test => test.testid == (int)EnumPTests.KettellC).idtr);
                    break;
                case EnumPReferences.Adaptability:
                    _checkedtest.Add(_human.testresults.LastOrDefault(test => test.testid == (int)EnumPTests.Adaptability).idtr);
                    break;
                case EnumPReferences.FPI:
                    _checkedtest.Add(_human.testresults.LastOrDefault(test => test.testid == (int)EnumPTests.FPI).idtr);
                    break;
                case EnumPReferences.KettellA:
                    _checkedtest.Add(_human.testresults.LastOrDefault(test => test.testid == (int)EnumPTests.KettellA).idtr);
                    break;
                case EnumPReferences.Modul:
                    _checkedtest.Add(_human.testresults.LastOrDefault(test => test.testid == (int)EnumPTests.Modul2).idtr);
                    break;
                case EnumPReferences.Integrative:
                    _checkedtest.Add(_human.testresults.LastOrDefault(test => test.testid == (int)EnumPTests.KettellC).idtr);
                    break;
                case EnumPReferences.Prognoz:
                    _checkedtest.Add(_human.testresults.LastOrDefault(test => test.testid == (int)EnumPTests.Prognoz).idtr);
                    break;
                case EnumPReferences.Addictive:
                    _checkedtest.Add(_human.testresults.LastOrDefault(test => test.testid == (int)EnumPTests.Addictive).idtr);
                    break;
                case EnumPReferences.NPNA:
                    _checkedtest.Add(_human.testresults.LastOrDefault(test => test.testid == (int)EnumPTests.NPNA).idtr);
                    break;
                case EnumPReferences.Leongard:
                    _checkedtest.Add(_human.testresults.LastOrDefault(test => test.testid == (int)EnumPTests.Leongard).idtr);
                    break;
            }

            return _checkedtest;
        }


        /// <summary>
        /// Создает характеристику по выбранным тестам
        /// </summary>
        /// <param name="checkedtestsid">Отмеченные тесты</param>
        /// <param name="SelectedRef">Выбранная характеристика</param>
        /// <returns></returns>
        public IReference GetReference(List<int> checkedtestsid, EnumPReferences SelectedRef)
        {
            IReference _reference = null;
            List<testresult> testresults = new List<testresult>();

            foreach (int testid in checkedtestsid)
            {//выбираем все отмеченные тесты
                testresults.Add(_human.testresults.FirstOrDefault(test => test.idtr == testid));
            }

            switch (SelectedRef)
            {
                
                case EnumPReferences.KettellC:
                    if (testresults.Count(test => test.testid == (int)EnumPTests.KettellC) != 0)
                    {
                        testresult kettellctestresult = testresults.LastOrDefault(test => test.testid == (int)EnumPTests.KettellC);
                        ITestReport kettellcreport = new KettellCTestReport(_human, kettellctestresult, _ge, _fe, true);
                        _reference = new KettellCTestReference(kettellcreport);
                    }
                    else
                    { MessageBox.Show("Для выбранной характеристики необходим тест Кеттелла С \nОтметьте его галочной в списке тестов"); }
                    break;

                case EnumPReferences.Adaptability:
                    if (testresults.Count(test => test.testid == (int)EnumPTests.Adaptability) != 0)
                    {
                        testresult dtestresult = testresults.LastOrDefault(test => test.testid == (int)EnumPTests.Adaptability);
                        ITestReport dreport = new DTestReport(_human, dtestresult, _ge, _fe, true);
                        _reference = new DTestReference(dreport);
                    }
                    else
                    { MessageBox.Show("Для выбранной характеристики необходим тест Адаптивность \nОтметьте его галочной в списке тестов"); }
                    break;

                case EnumPReferences.FPI:
                    if (testresults.Count(test => test.testid == (int)EnumPTests.FPI) != 0)
                    {
                        testresult fpitestresult = testresults.LastOrDefault(test => test.testid == (int)EnumPTests.FPI);
                        ITestReport fpireport = new FPITestReport(_human, fpitestresult, _ge, _fe, true);
                        _reference = new FPITestReference(fpireport);
                    }
                    else
                    { MessageBox.Show("Для выбранной характеристики необходим тест FPI \nОтметьте его галочной в списке тестов"); }
                    break;

                case EnumPReferences.KettellA:
                    if (testresults.Count(test => test.testid == (int)EnumPTests.KettellA) != 0)
                    {
                        testresult kettellatestresult = testresults.LastOrDefault(test => test.testid == (int)EnumPTests.KettellA);
                        ITestReport kettellareport = new KettellATestReport(_human, kettellatestresult, _ge, _fe, true);
                        _reference = new KettellATestReference(kettellareport);
                    }
                    else
                    { MessageBox.Show("Для выбранной характеристики необходим тест Кеттелла А \nОтметьте его галочной в списке тестов"); }
                    break;

                case EnumPReferences.Modul:
                    if (testresults.Count(test => test.testid == (int)EnumPTests.Modul2) != 0)
                    {
                        testresult mdtestresult = testresults.LastOrDefault(test => test.testid == (int)EnumPTests.Modul2);
                        ITestReport mdreport = new MDTestReport(_human, mdtestresult, _ge, _fe, true);
                        _reference = new MDTestReference(mdreport);
                    }
                    else
                    { MessageBox.Show("Для выбранной характеристики необходим тест Модуль \nОтметьте его галочной в списке тестов"); }
                    break;

                case EnumPReferences.Integrative:
                    if (testresults.Count(test => test.testid == (int)EnumPTests.KettellC) != 0)
                    {
                        testresult kettelltestresult = testresults.LastOrDefault(test => test.testid == (int)EnumPTests.KettellC);
                        ITestReport kettellreport = new KettellCTestReport(_human, kettelltestresult, _ge, _fe, true);
                        _reference = new IntegrativeReference(kettellreport,_fe);
                    }
                    else
                    { MessageBox.Show("Для выбранной характеристики необходим тест Кеттелла С \nОтметьте его галочной в списке тестов"); }
                    break;
                case EnumPReferences.Prognoz:
                    if (testresults.Count(test => test.testid == (int)EnumPTests.Prognoz) != 0)
                    {
                        testresult prognoztestresult = testresults.LastOrDefault(test => test.testid == (int)EnumPTests.Prognoz);
                        ITestReport prognozreport = new PTestReport(_human, prognoztestresult, _ge, _fe, true);
                        _reference = new PTestReference(prognozreport);
                    }
                    else
                    { MessageBox.Show("Для выбранной характеристики необходим тест Прогноз 2 \nОтметьте его галочной в списке тестов"); }
                    break;
                case EnumPReferences.Addictive:
                    if (testresults.Count(test => test.testid == (int)EnumPTests.Addictive) != 0)
                    {
                        testresult addictivetestresult = testresults.LastOrDefault(test => test.testid == (int)EnumPTests.Addictive);
                        ITestReport addictivereport = new ATestReport(_human, addictivetestresult, _ge, _fe, true);
                        _reference = new ATestReference(addictivereport);
                    }
                    else
                    { MessageBox.Show("Для выбранной характеристики необходим тест Аддиктивная склонность \nОтметьте его галочной в списке тестов"); }
                    break;
                case EnumPReferences.NPNA:
                    if (testresults.Count(test => test.testid == (int)EnumPTests.NPNA) != 0)
                    {
                        testresult addictivetestresult = testresults.LastOrDefault(test => test.testid == (int)EnumPTests.NPNA);
                        ITestReport addictivereport = new NPNTestReport(_human, addictivetestresult, _ge, _fe, true);
                        _reference = new NPNTestReference(addictivereport);
                    }
                    else
                    { MessageBox.Show("Для выбранной характеристики необходим тест НПН-А \nОтметьте его галочной в списке тестов"); }
                    break;
                case EnumPReferences.Leongard:
                    if (testresults.Count(test => test.testid == (int)EnumPTests.Leongard) != 0)
                    {
                        testresult addictivetestresult = testresults.LastOrDefault(test => test.testid == (int)EnumPTests.Leongard);
                        ITestReport addictivereport = new LTestReport(_human, addictivetestresult, _ge, _fe, true);
                        _reference = new LTestReference(addictivereport);
                    }
                    else
                    { MessageBox.Show("Для выбранной характеристики необходим тест Леонгарда \nОтметьте его галочной в списке тестов"); }
                    break;
            }
            return _reference;

        }

        /// <summary>
        /// Определяет доступные характеристики для тестов конкретного человека
        /// </summary>
        private void GetEvalRefs()
        {
            

            if (_human.testresults.Count(test => test.testid == (int)EnumPTests.KettellC) != 0)
            {
                string[] row = { Convert.ToString((int)EnumPReferences.KettellC), "МНОГОФАКТОРНАЯ ХАРАКТЕРИСТИКА НА ОСНОВЕ ОПРОСНИКА КЕТТЕЛЛА C" };
                _evalrefs.Add(row);
            }

            if (_human.testresults.Count(test => test.testid == (int)EnumPTests.Adaptability) != 0)
            {
                string[] row = { Convert.ToString((int)EnumPReferences.Adaptability), "ХАРАКТЕРИСТИКА НА ОСНОВЕ МЕТОДИКИ АДАПТИВНОСТЬ" };
                _evalrefs.Add(row);
            }
            if (_human.testresults.Count(test => test.testid == (int)EnumPTests.FPI) != 0)
            {
                string[] row = { Convert.ToString((int)EnumPReferences.FPI), "ПРОФИЛЬ ЛИЧНОСТИ FPI" };
                _evalrefs.Add(row);
            }

            if (_human.testresults.Count(test => test.testid == (int)EnumPTests.KettellA) != 0)
            {
                string[] row = { Convert.ToString((int)EnumPReferences.KettellA), "МНОГОФАКТОРНАЯ ХАРАКТЕРИСТИКА НА ОСНОВЕ ОПРОСНИКА КЕТТЕЛЛА А" };
                _evalrefs.Add(row);
            }

            if (_human.testresults.Count(test => test.testid == (int)EnumPTests.Modul2) != 0)
            {
                string[] row = { Convert.ToString((int)EnumPReferences.Modul), "ПСИХОДИАГНОСТИЧЕСКИЙ ОПРОСНИК МОДУЛЬ 2" };
                _evalrefs.Add(row);
            }

            if (_human.testresults.Count(test => test.testid == (int)EnumPTests.KettellC) != 0)
            {
                string[] row = { Convert.ToString((int)EnumPReferences.Integrative), "ИНТЕГРАЛЬНАЯ ХАРАКТЕРИСТИКА НА ОСНОВЕ ОПРОСНИКА КЕТТЕЛЛА С" };
                _evalrefs.Add(row);
            }
            if (_human.testresults.Count(test => test.testid == (int)EnumPTests.Prognoz) != 0)
            {
                string[] row = { Convert.ToString((int)EnumPReferences.Prognoz), "ХАРАКТЕРИСТИКА НА ОСНОВЕ ОПРОСНИКА ПРОГНОЗ 2" };
                _evalrefs.Add(row);
            }
            if (_human.testresults.Count(test => test.testid == (int)EnumPTests.Addictive) != 0)
            {
                string[] row = { Convert.ToString((int)EnumPReferences.Addictive), "ХАРАКТЕРИСТИКА НА ОСНОВЕ ОПРОСНИКА АДДИКТИВНАЯ СКЛОННОСТЬ" };
                _evalrefs.Add(row);
            }
            if (_human.testresults.Count(test => test.testid == (int)EnumPTests.NPNA) != 0)
            {
                string[] row = { Convert.ToString((int)EnumPReferences.NPNA), "ХАРАКТЕРИСТИКА НА ОСНОВЕ ОПРОСНИКА НПН-А" };
                _evalrefs.Add(row);
            }
            if (_human.testresults.Count(test => test.testid == (int)EnumPTests.Leongard) != 0)
            {
                string[] row = { Convert.ToString((int)EnumPReferences.Leongard), "ХАРАКТЕРИСТИКА НА ОСНОВЕ ОПРОСНИКА ЛЕОНГАРДА" };
                _evalrefs.Add(row);
            }
        }
        public static Dictionary<EnumPReferences,string> ReferenceDict
        {
            get {
                _referencesdict = new Dictionary<EnumPReferences, string>();
                _referencesdict.Add(EnumPReferences.Adaptability, "ХАРАКТЕРИСТИКА НА ОСНОВЕ МЕТОДИКИ АДАПТИВНОСТЬ");
                _referencesdict.Add(EnumPReferences.FPI, "ПРОФИЛЬ ЛИЧНОСТИ FPI");
                _referencesdict.Add(EnumPReferences.Integrative, "ИНТЕГРАЛЬНАЯ ХАРАКТЕРИСТИКА НА ОСНОВЕ ОПРОСНИКА КЕТТЕЛЛА С");
                _referencesdict.Add(EnumPReferences.KettellA, "МНОГОФАКТОРНАЯ ХАРАКТЕРИСТИКА НА ОСНОВЕ ОПРОСНИКА КЕТТЕЛЛА А");
                _referencesdict.Add(EnumPReferences.KettellC, "МНОГОФАКТОРНАЯ ХАРАКТЕРИСТИКА НА ОСНОВЕ ОПРОСНИКА КЕТТЕЛЛА C");
                _referencesdict.Add(EnumPReferences.Modul, "ПСИХОДИАГНОСТИЧЕСКИЙ ОПРОСНИК МОДУЛЬ");
                _referencesdict.Add(EnumPReferences.Prognoz, "ПСИХОДИАГНОСТИЧЕСКИЙ ОПРОСНИК ПРОГНОЗ 2");
                _referencesdict.Add(EnumPReferences.Addictive, "ПСИХОДИАГНОСТИЧЕСКИЙ ОПРОСНИК АДДИКТИВНАЯ СКЛОННОСТЬ");
                _referencesdict.Add(EnumPReferences.NPNA, "ПСИХОДИАГНОСТИЧЕСКИЙ ОПРОСНИК НПН-А");
                _referencesdict.Add(EnumPReferences.Leongard, "ПСИХОДИАГНОСТИЧЕСКИЙ ОПРОСНИК ЛЕОНГАРДА");
                return _referencesdict;
                }
        }

       
    }
}
