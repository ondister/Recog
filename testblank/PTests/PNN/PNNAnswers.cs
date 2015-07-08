using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Collections;

namespace Recog.PTests.PNN
{
       
    public class PNNAnswers:ICollection
    {
       
        private List<PNNAnswer> _answers;

        public int Count
        {
            get { return _answers.Count; }
        }
          
        public PNNAnswers()
        {
            _answers = new List<PNNAnswer>();
        }
       
        public PNNAnswer this[int index]
        {
            set { _answers[index] = value; }
            get { return _answers[index]; }
        }

        public void Add(PNNAnswer answer)
        {
            _answers.Add(answer);
        }

        public void Add(PnnSignalType signal, PnnKeyType key, DateTime time,int exposition)
        {
            PNNAnswer a = new PNNAnswer(signal, key, time, exposition);
            this.Add(a);
        }

        public int GetWrongPercent()
        {
            int wp = 0;
            if (_answers.Count != 0)
            {

                double falseansws = _answers.Count(a => a.Answer == false);
                double allansws = _answers.Count();
                wp = Convert.ToInt16((falseansws / allansws) * 100);
            }

            return wp;
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
