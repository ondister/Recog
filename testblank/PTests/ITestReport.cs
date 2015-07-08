using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;

namespace Recog.PTests
{
   public interface ITestReport
    {
       List<IScale> ListScales { get; }
       human Human { get; }
       testresult TestResult { get; }
       void GetMarks();
       void Print(bool WaitForExit=false);
       void Save(string filename);
    }
}
