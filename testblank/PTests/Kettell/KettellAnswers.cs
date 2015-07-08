using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Recog.Data;
namespace Recog.PTests.Kettell
{
    public class KettellAnswers : ICollection, IAnswers
    {
        private List<KettellAnswer> _kettellanswers;
        private pBaseEntities _ge;
        public KettellAnswers(pBaseEntities ge)
        {
            _ge = ge;
            _kettellanswers = new List<KettellAnswer>();
        }

        public KettellAnswers() { _kettellanswers = new List<KettellAnswer>(); }
        public KettellAnswer this[int index]
        {
            get { return _kettellanswers[index]; }
            set { _kettellanswers[index] = value; }
        }
        public void Add(KettellAnswer KettellAnswer)
        {
            _kettellanswers.Add(KettellAnswer);
        }
        public void Add(int selectedcellindex, string selectedcelldescription, string selectedcellbuttondescription, int answerindex, string answerdescription)
        {
            KettellAnswer ka = new KettellAnswer();
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
            get { return _kettellanswers.Count(); }
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
            return _kettellanswers.GetEnumerator();
        }

   }
}
