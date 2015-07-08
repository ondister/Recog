using Recog.PTests.D;

namespace Recog.PTests.References
{
    public class DTestReference : IReference
    {
        private DTestReport _dtestreport;

        public DTestReference(ITestReport DReport)
        {
            _dtestreport = (DTestReport)DReport;
        }

        public string Name
        {
            get { return "ХАРАКТЕРИСТИКА НА ОСНОВЕ МЕТОДИКИ АДАПТИВНОСТЬ"; }
        }

        public EnumPReferences ID
        {
            get { return EnumPReferences.Adaptability; }
        }

        public void Print(bool WaitForExit = false)
        {
            _dtestreport.Print(WaitForExit);
        }
        public System.Collections.Generic.List<EnumPTests> UsedTests
        {
            get { return new System.Collections.Generic.List<EnumPTests> { EnumPTests.Adaptability }; }
        }
     }
}
