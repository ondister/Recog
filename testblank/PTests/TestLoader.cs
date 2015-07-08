using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Humans;
using Recog.Data;
namespace Recog.PTests
{
   public  class TestLoader
    {
       private fBaseEntities _fe;
       private ITest _currenttest;
       private TestsPool _pool;
       private int _humanid;
       private HumansForm hf;
       public event EventHandler TestsPoolDone;
       private TestDoneEventArgs arg;
       private void OnTestsPoolDone() { if (TestsPoolDone != null) { TestsPoolDone(this, arg); } }
       public ITest CurrentTest
       {
           get { return _currenttest; }
       }

       public TestLoader(fBaseEntities fe)
       {
           _fe = fe;
           arg = new TestDoneEventArgs();
          _pool = new TestsPool();
       }
       
        public int HumanID
        {
            get { return _humanid; }
        }

        public TestsPool Pool
        {
            get { return _pool; }
            set {
               
                _pool = value; 
            }
        }

        void currenttest_TestDone(object sender, EventArgs e)
        {
           this.NextText();
        }

        public void StartTesting()
        {
            if (_humanid != 0)
            {
                if (_pool.Count != 0)
                {
                    try
                    {
                        _currenttest = _pool[0];
                        _currenttest.TestDone += new EventHandler(currenttest_TestDone);
                        _currenttest.HumanID = _humanid;
                        _currenttest.Start();
                    }
                    catch (Exception ex)
                    { throw new Exception(ex.Message); }
                }
            }
            
        }
       private void NextText()
       {
           if (_currenttest.ID+1!=_pool.Count)
           {
           _currenttest = _pool[_currenttest.ID + 1];
           _currenttest.TestDone += new EventHandler(currenttest_TestDone);
           _currenttest.HumanID = _humanid;
           _currenttest.Start();
          }
           else {
               arg.Reason = "Закончены тесты";
               this.OnTestsPoolDone(); 
           }

       }

       public void SetHumanID()
       {
           hf = new HumansForm(_fe);
           hf.btn_begin.Click += new EventHandler(btn_begin_Click);
           hf.ShowDialog();
       }

       void btn_begin_Click(object sender, EventArgs e)
       {
           _humanid = hf.CurrentHumanID;
           //if (_humanid == 0) { throw new Exception("никто не выбран"); }
       }
       

    }
}
