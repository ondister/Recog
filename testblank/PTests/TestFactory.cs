using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
using Recog.PTests.Kettell;
using Recog.PTests.D;
using Recog.PTests.MD;
using Recog.PTests.FPI;
using Recog.PTests.PNN;
using Recog.PTests.Contrasts;
using Recog.PTests.Prognoz;
using Recog.PTests.Addictive;
using Recog.PTests.NPNA;
using Recog.PTests.Leongard;

namespace Recog.PTests
{
  public static class TestFactory
    {
      public static ITest CreateTest(EnumPTests test, pBaseEntities ge, fBaseEntities fe, bool isAlone)
      {
          ITest _gentest=null;
          switch (test)
          {
              case EnumPTests.KettellC:
                  _gentest = new TestKettellC(ge, fe, isAlone);
                  break;
              case EnumPTests.PNN:
                  _gentest = new TestPnn(ge, fe, isAlone);
                  break;
              case EnumPTests.Adaptability:
                  _gentest = new TestD(ge,fe, isAlone);
                  break;
              case EnumPTests.FPI:
                  _gentest = new TestFPI(ge, fe, isAlone);
                  break;
              case EnumPTests.KettellA:
                  _gentest = new TestKettellA(ge, fe, isAlone);
                  break;
              case EnumPTests.Modul2:
                  _gentest = new TestMD(ge, fe, isAlone);
                  break;
              case EnumPTests.Contrasts:
                  _gentest = new TestContrasts(fe);
                  break;
              case EnumPTests.Prognoz:
                  _gentest = new TestP(ge,fe,isAlone);
                  break;
              case EnumPTests.Addictive:
                  _gentest = new TestA(ge, fe, isAlone);
                  break;
              case EnumPTests.NPNA:
                  _gentest = new TestNPN(ge, fe, isAlone);
                  break;
              case EnumPTests.Leongard:
                  _gentest = new TestL(ge, fe, isAlone);
                  break;

          }
          return _gentest;
      }
    }
}
