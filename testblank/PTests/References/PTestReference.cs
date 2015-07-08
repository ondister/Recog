using Recog.PTests.Prognoz;

namespace Recog.PTests.References
{
    public class PTestReference : IReference
    {
        private PTestReport _dtestreport;

        public PTestReference(ITestReport PReport)
        {
            _dtestreport = (PTestReport)PReport;
        }

        public string Name
        {
            get { return "ХАРАКТЕРИСТИКА НА ОСНОВЕ МЕТОДИКИ ПРОГНОЗ 2"; }
        }

        public EnumPReferences ID
        {
            get { return EnumPReferences.Prognoz; }
        }

        public void Print(bool WaitForExit = false)
        {
            _dtestreport.Print(WaitForExit);
        }
        public System.Collections.Generic.List<EnumPTests> UsedTests
        {
            get { return new System.Collections.Generic.List<EnumPTests> { EnumPTests.Prognoz }; }
        }
     }
}
