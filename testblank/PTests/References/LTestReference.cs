using Recog.PTests.Leongard;

namespace Recog.PTests.References
{
    public class LTestReference : IReference
    {
        private LTestReport _dtestreport;

        public LTestReference(ITestReport LReport)
        {
            _dtestreport = (LTestReport)LReport;
        }

        public string Name
        {
            get { return "ХАРАКТЕРИСТИКА НА ОСНОВЕ МЕТОДИКИ ЛЕОНГАРДА"; }
        }

        public EnumPReferences ID
        {
            get { return EnumPReferences.Leongard; }
        }

        public void Print(bool WaitForExit = false)
        {
            _dtestreport.Print(WaitForExit);
        }
        public System.Collections.Generic.List<EnumPTests> UsedTests
        {
            get { return new System.Collections.Generic.List<EnumPTests> { EnumPTests.Leongard }; }
        }
     }
}
