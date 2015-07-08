using Recog.PTests.MD;

namespace Recog.PTests.References
{
    public class MDTestReference : IReference
    {
        private MDTestReport _mdtestreport;

        public MDTestReference(ITestReport MDReport)
        {
            _mdtestreport = (MDTestReport)MDReport;
        }

        public string Name
        {
            get { return "ХАРАКТЕРИСТИКА НА ОСНОВЕ МЕТОДИКИ МОДУЛЬ 2"; }
        }

        public EnumPReferences ID
        {
            get { return EnumPReferences.Modul; }
        }

        public void Print(bool WaitForExit = false)
        {
            _mdtestreport.Print(WaitForExit);
        }
        public System.Collections.Generic.List<EnumPTests> UsedTests
        {
            get { return new System.Collections.Generic.List<EnumPTests> { EnumPTests.Modul2 }; }
        }
     }
}
