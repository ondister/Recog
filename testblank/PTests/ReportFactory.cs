using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
using Recog.PTests.Kettell;
using Recog.PTests.D;
using Recog.PTests.FPI;
using Recog.PTests.PNN;
using Recog.PTests.MD;
using Recog.PTests.Contrasts;
using Recog.PTests.Prognoz;
using Recog.PTests.Addictive;
using Recog.PTests.NPNA;
using Recog.PTests.Leongard;
namespace Recog.PTests
{
   public static class ReportFactory
    {
       public static ITestReport CreateReport(EnumPTests test, human human, testresult testresult, pBaseEntities ge, fBaseEntities fe, bool withresult)
       {
           ITestReport _genreport = null;
           switch (test)
           {
               case EnumPTests.KettellC:
                   _genreport = new KettellCTestReport(human, testresult, ge,fe, withresult);
                   break;
               case EnumPTests.PNN:
                   _genreport = new PNNTestReport(human, testresult, ge,fe);
                   break;
               case EnumPTests.Adaptability:
                   _genreport = new DTestReport(human, testresult, ge,fe, withresult);
                   break;
               case EnumPTests.FPI:
                   _genreport = new FPITestReport(human, testresult, ge,fe, withresult);
                   break;
               case EnumPTests.KettellA:
                   _genreport = new KettellATestReport(human, testresult, ge,fe, withresult);
                   break;
               case EnumPTests.Modul2:
                   _genreport = new MDTestReport(human, testresult, ge, fe, withresult);
                   break;
               case EnumPTests.Contrasts:
                   _genreport = new ContrastsTestReport(human, testresult, ge, fe);
                   break;
               case EnumPTests.Prognoz:
                   _genreport = new PTestReport(human, testresult, ge, fe, withresult);
                   break;
               case EnumPTests.Addictive:
                   _genreport = new ATestReport(human, testresult, ge, fe, withresult);
                   break;
               case EnumPTests.NPNA:
                   _genreport = new NPNTestReport(human, testresult, ge, fe, withresult);
                   break;
               case EnumPTests.Leongard:
                   _genreport = new LTestReport(human, testresult, ge, fe, withresult);
                   break;
           }
           return _genreport;
       }
    }
}
