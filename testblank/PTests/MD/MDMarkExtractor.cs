using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
using Recog.PTests;
namespace Recog.PTests.MD
{
    public static class MDMarkExtractor
    {
        public static int GetMark(pBaseEntities GlobalEntities, MDAnswers mdAnswers, List<int> answers)
        {
            int m = 0;

            testsparam t = GlobalEntities.testsparams.First(tp => tp.idt == (int)EnumPTests.Modul2);
            t.answersparams.Load();

            for (int i = 0; i < answers.Count; i++)
            {
                answersparam a = t.answersparams.First(ap => ap.num == answers[i]);
                a.cellsparams.Load();
                if (mdAnswers[(int)a.num - 1].SelectedCellDescription.Trim() != "")
                {
                    cellsparam c = a.cellsparams.First(cp => cp.description.Trim() == mdAnswers[(int)a.num - 1].SelectedCellDescription.Trim());
                     m+=(int)c.mark;
                }
            }
            
            return m;
        }
    }
}
