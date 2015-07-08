using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.RecogCore;
using Recog.RecogCore.AnswerGrid;
using Recog.Data;
namespace Recog.PTests
{
    
   public interface ITest
    {
       event EventHandler TestDone;
       int ID { get; set; }
       int HumanID { get; set; }
       void Start();
       void End();
       void ResultsToBase();
       testresult ResultsToBase(Answers Answers);
    }
}
