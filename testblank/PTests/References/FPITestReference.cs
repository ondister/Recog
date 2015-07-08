using Recog.PTests.FPI;

namespace Recog.PTests.References
{
    public class FPITestReference : IReference
    {
        private FPITestReport _fpitestreport;

        public FPITestReference(ITestReport FPIReport)
        {
            _fpitestreport = (FPITestReport)FPIReport;
        }

        public string Name
        {
            get { return "ХАРАКТЕРИСТИКА НА ОСНОВЕ МЕТОДИКИ FPI"; }
        }

        public EnumPReferences ID
        {
            get { return EnumPReferences.FPI; }
        }

        public void Print(bool WaitForExit = false)
        {
            _fpitestreport.Print(WaitForExit);
        }
        public System.Collections.Generic.List<EnumPTests> UsedTests
        {
            get {return new System.Collections.Generic.List<EnumPTests> { EnumPTests.FPI}; }
        }
     }
}
