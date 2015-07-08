using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recog.PTests
{
   public static class ScaleChecker
    {

       public static bool MarkInRange(IScale Scale, int minmark, int maxmark)
       {
           if (Scale.Mark >= minmark & Scale.Mark <= maxmark) { return true; }
           else { return false; }
       }

       public static bool StenInRange(IScale Scale, int minsten, int maxsten)
       {
           if (Scale.Stens >= minsten & Scale.Stens <= maxsten) { return true; }
           else { return false; }
       }

       public static bool HasLowLevel(IScale Scale)
       {
           if (Scale.Level == "Низкий") { return true; }
           else { return false; }
           }
       public static bool HasMiddleLevel(IScale Scale)
       {
           if (Scale.Level == "Средний") { return true; }
           else { return false; }
       }
       public static bool HasHeightLevel(IScale Scale)
       {
           if (Scale.Level == "Высокий") { return true; }
           else { return false; }
       }

    }
}
