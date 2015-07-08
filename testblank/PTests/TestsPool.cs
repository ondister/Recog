using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Recog.PTests.Kettell;

namespace Recog.PTests
{
    
   public  class TestsPool:ICollection
    {
       private List<ITest> _tests;

       public TestsPool()
       { _tests = new List<ITest>(); }

       public ITest this[int index]
       {
           get { return _tests[index]; }
           set { _tests[index] = value; }
       }

       public void CopyTo(Array array, int index)
       {
           throw new NotImplementedException();
       }

       public int Count
       {
           get { return _tests.Count(); }
       }

       public bool IsSynchronized
       {
           get { return false; }
       }

       public object SyncRoot
       {
           get { return this; }
       }

       public IEnumerator GetEnumerator()
       {
           return _tests.GetEnumerator();
       }
       public void Add(ITest Test)
       {
           Test.ID = _tests.Count();
           _tests.Add(Test);

       }
             
    }
}
