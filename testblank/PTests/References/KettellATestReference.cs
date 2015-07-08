using Recog.PTests.Kettell;

namespace Recog.PTests.References
{
    public class KettellATestReference : IReference
    {
        private KettellATestReport _kettellatestreport;

        public KettellATestReference(ITestReport KettellAReport)
        {
            _kettellatestreport = (KettellATestReport)KettellAReport;
        }

        public string Name
        {
            get { return "ХАРАКТЕРИСТИКА НА ОСНОВЕ МЕТОДИКИ КЕТТЕЛЛ А"; }
        }

        public EnumPReferences ID
        {
            get { return EnumPReferences.KettellA; }
        }

        public void Print(bool WaitForExit = false)
        {
            _kettellatestreport.Print(WaitForExit);
        }
        public System.Collections.Generic.List<EnumPTests> UsedTests
        {
            get { return new System.Collections.Generic.List<EnumPTests> { EnumPTests.KettellA }; }
        }
     }
}
