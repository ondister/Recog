using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
using System.Collections;

namespace Recog.PTests.Leongard
{
    public class LAnswers : ICollection, IAnswers
    {
       private List<LAnswer> _Lanswers;
        private pBaseEntities _ge;
        public LAnswers(pBaseEntities ge)
        {
            _ge = ge;
            _Lanswers = new List<LAnswer>();
        }

        public LAnswers() { _Lanswers = new List<LAnswer>(); }
        public LAnswer this[int index]
        {
            get { return _Lanswers[index]; }
            set { _Lanswers[index] = value; }
        }
        public void Add(LAnswer Answer)
        {
            _Lanswers.Add(Answer);
        }
        public void Add(int selectedcellindex, string selectedcelldescription, string selectedcellbuttondescription, int answerindex, string answerdescription)
        {
            LAnswer ka = new LAnswer();
            ka.Time = DateTime.Now;
            ka.SelectedCellIndex = selectedcellindex;
            ka.SelectedCellDescription = selectedcelldescription;
            ka.SelectedCellButtonDescription = selectedcellbuttondescription;
            ka.AnswerIndex = answerindex;
            ka.AnswerDescription = answerdescription;
            this.Add(ka);
        }
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return _Lanswers.Count(); }
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
            return _Lanswers.GetEnumerator();
        }

      

    }
}
