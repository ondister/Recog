using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
using System.Collections;

namespace Recog.PTests.Prognoz
{
    public class PAnswers : ICollection, IAnswers
    {
       private List<PAnswer> _panswers;
        private pBaseEntities _ge;
        public PAnswers(pBaseEntities ge)
        {
            _ge = ge;
            _panswers = new List<PAnswer>();
        }

        public PAnswers() { _panswers = new List<PAnswer>(); }
        public PAnswer this[int index]
        {
            get { return _panswers[index]; }
            set { _panswers[index] = value; }
        }
        public void Add(PAnswer Answer)
        {
            _panswers.Add(Answer);
        }
        public void Add(int selectedcellindex, string selectedcelldescription, string selectedcellbuttondescription, int answerindex, string answerdescription)
        {
            PAnswer ka = new PAnswer();
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
            get { return _panswers.Count(); }
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
            return _panswers.GetEnumerator();
        }

      

    }
}
