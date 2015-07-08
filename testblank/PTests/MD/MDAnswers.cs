using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
using System.Collections;

namespace Recog.PTests.MD
{
    public class MDAnswers : ICollection, IAnswers
    {
       private List<MDAnswer> _MDanswers;
        private pBaseEntities _ge;
        public MDAnswers(pBaseEntities ge)
        {
            _ge = ge;
            _MDanswers = new List<MDAnswer>();
        }

        public MDAnswers() { _MDanswers = new List<MDAnswer>(); }
        public MDAnswer this[int index]
        {
            get { return _MDanswers[index]; }
            set { _MDanswers[index] = value; }
        }
        public void Add(MDAnswer Answer)
        {
            _MDanswers.Add(Answer);
        }
        public void Add(int selectedcellindex, string selectedcelldescription, string selectedcellbuttondescription, int answerindex, string answerdescription)
        {
            MDAnswer ka = new MDAnswer();
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
            get { return _MDanswers.Count(); }
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
            return _MDanswers.GetEnumerator();
        }

      

    }
}
