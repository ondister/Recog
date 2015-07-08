using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recog.PTests
{
    
    public  class TestDoneEventArgs : EventArgs
    {
        public string Reason;
        public bool IsLastTest;

    }
}
