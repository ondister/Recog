using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
using System.Collections;

namespace Recog.PTests
{
   public interface IAnswers
    {
      int Count {get; }
      void Add(int selectedcellindex, string selectedcelldescription, string selectedcellbuttondescription, int answerindex, string answerdescription);
        
    }
}
