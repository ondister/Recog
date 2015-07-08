using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.PTests.References;
namespace Recog.PTests
{
   public interface IReference
    {
      
      string Name { get; }
      EnumPReferences ID { get; }
      List<EnumPTests> UsedTests { get; }
      void Print(bool WaitForExit=false);
    }
}
