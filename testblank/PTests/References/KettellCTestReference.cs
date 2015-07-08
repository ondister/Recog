using Recog.PTests.Kettell;

namespace Recog.PTests.References
{
    public class KettellCTestReference : IReference
    {
        private KettellCTestReport _kettellctestreport;

        public KettellCTestReference(ITestReport KettellCReport)
        {
            _kettellctestreport = (KettellCTestReport)KettellCReport;
        }

        public string Name
        {
            get { return "ХАРАКТЕРИСТИКА НА ОСНОВЕ МЕТОДИКИ КЕТТЕЛЛ  C"; }
        }

        public EnumPReferences ID
        {
            get { return EnumPReferences.KettellC; }
        }

        public void Print(bool WaitForExit=false)
        {
            _kettellctestreport.Print(WaitForExit);
        }
        public System.Collections.Generic.List<EnumPTests> UsedTests
        {
            get { return new System.Collections.Generic.List<EnumPTests> { EnumPTests.KettellC}; }
        }
     }
}
