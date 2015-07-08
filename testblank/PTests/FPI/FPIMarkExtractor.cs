using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
using Recog.PTests;
namespace Recog.PTests.FPI
{
    public static class FPIMarkExtractor
    {
        public static int GetMark(pBaseEntities GlobalEntities, FPIAnswers FPIAnswers, List<int> AnswersYes, List<int> AnswersNo)
        {
            int m = 0;

            testsparam t = GlobalEntities.testsparams.First(tp => tp.idt == (int)EnumPTests.FPI);
            t.answersparams.Load();
            for (int i = 0; i < AnswersYes.Count; i++)
            {
                answersparam a = t.answersparams.First(ap => ap.num == AnswersYes[i]);
                a.cellsparams.Load();
                if (FPIAnswers[(int)a.num - 1].SelectedCellDescription.Trim() != "")
                {
                    cellsparam c = a.cellsparams.First(cp => cp.description.Trim() == FPIAnswers[(int)a.num - 1].SelectedCellDescription.Trim());
                    if (c.mark == 1) { m++; }
                }
            }

            for (int i = 0; i < AnswersNo.Count; i++)
            {
                answersparam a = t.answersparams.First(ap => ap.num == AnswersNo[i]);
                a.cellsparams.Load();
                if (FPIAnswers[(int)a.num - 1].SelectedCellDescription.Trim() != "")
                {
                    cellsparam c = a.cellsparams.First(cp => cp.description.Trim() == FPIAnswers[(int)a.num - 1].SelectedCellDescription.Trim());
                    if (c.mark == 0) { m++; }
                }
            }



            return m;
        }
    }
}
