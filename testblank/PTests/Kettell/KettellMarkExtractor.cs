using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
using Recog.PTests;
namespace Recog.PTests.Kettell
{
   public static class KettellMarkExtractor
    {
       
      public static int GetMark(pBaseEntities GlobalEntities, KettellAnswers KettellAnswers, List<int> AnswersNums,EnumKettellType KType)
        {
            int m = 0;
            testsparam t;
            if (KType == EnumKettellType.CForm)
            {
                t = GlobalEntities.testsparams.First(tp => tp.idt == (int)EnumPTests.KettellC);
            }
            else { t = GlobalEntities.testsparams.First(tp => tp.idt == (int)EnumPTests.KettellA); }
                t.answersparams.Load();
                for (int i = 0; i < AnswersNums.Count; i++)
                {
                    answersparam a = t.answersparams.First(ap => ap.num == AnswersNums[i]);
                    a.cellsparams.Load();
                    if (KettellAnswers[(int)a.num - 1].SelectedCellDescription.Trim() != "")
                    {
                        cellsparam c = a.cellsparams.First(cp => cp.description.Trim() == KettellAnswers[(int)a.num - 1].SelectedCellDescription.Trim());
                        m += c.mark.Value;
                    }
            }
            return m;
        }
    }
}
