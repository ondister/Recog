using Recog.PTests.Addictive;

namespace Recog.PTests.References
{
    public class ATestReference : IReference
    {
        private ATestReport _dtestreport;

        public ATestReference(ITestReport PReport)
        {
            _dtestreport = (ATestReport)PReport;
        }

        public string Name
        {
            get { return "ХАРАКТЕРИСТИКА НА ОСНОВЕ МЕТОДИКИ АДДИКТИВНАЯ СКЛОННОСТЬ"; }
        }

        public EnumPReferences ID
        {
            get { return EnumPReferences.Addictive; }
        }

        public void Print(bool WaitForExit = false)
        {
            _dtestreport.Print(WaitForExit);
        }
        public System.Collections.Generic.List<EnumPTests> UsedTests
        {
            get { return new System.Collections.Generic.List<EnumPTests> { EnumPTests.Addictive }; }
        }
     }
}
