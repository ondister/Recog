using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests
{
  public abstract class IScalesCollection
    {
      private List<IScale> _listscales;
      public  IScalesCollection(pBaseEntities ge, testresult testresult, human human)
      { _listscales = new List<IScale>(); }

      public IScale this[int index] { get { return _listscales[index]; } }

      public abstract void Add(IScale scale);
    }
}
