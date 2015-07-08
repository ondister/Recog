using Recog.PTests.NPNA;

namespace Recog.PTests.References
{
    public class NPNTestReference : IReference
    {
        private NPNTestReport _dtestreport;

        public NPNTestReference(ITestReport NPNReport)
        {
            _dtestreport = (NPNTestReport)NPNReport;
        }

        public string Name
        {
            get { return "ХАРАКТЕРИСТИКА НА ОСНОВЕ МЕТОДИКИ НПН-А"; }
        }

        public EnumPReferences ID
        {
            get { return EnumPReferences.NPNA; }
        }

        public void Print(bool WaitForExit = false)
        {
            _dtestreport.Print(WaitForExit);
        }
        public System.Collections.Generic.List<EnumPTests> UsedTests
        {
            get { return new System.Collections.Generic.List<EnumPTests> { EnumPTests.NPNA }; }
        }
     }
}
