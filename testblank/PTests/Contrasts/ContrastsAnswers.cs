using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Collections;

namespace Recog.PTests.Contrasts
{

    public class ContrastsAnswers : ICollection
    {
       
        private List<ContrastsAnswer> _answers;

        public int Count
        {
            get { return _answers.Count; }
        }

        public ContrastsAnswers()
        {
            _answers = new List<ContrastsAnswer>();
        }

        public ContrastsAnswer this[int index]
        {
            set { _answers[index] = value; }
            get { return _answers[index]; }
        }

        public void Add(ContrastsAnswer answer)
        {
            _answers.Add(answer);
        }

        public void Add(DateTime time, int pictureid)
        {
            ContrastsAnswer a = new ContrastsAnswer(time, pictureid);
            this.Add(a);
        }

       



        public void CopyTo(Array a, int index)
        {
            //_answers.CopyTo(a, index);

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
            return _answers.GetEnumerator();
        }
    }
}
