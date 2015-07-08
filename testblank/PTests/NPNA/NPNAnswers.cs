using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
using System.Collections;

namespace Recog.PTests.NPNA
{
    public class NPNAnswers : ICollection, IAnswers
    {
       private List<NPNAnswer> _Danswers;
        private pBaseEntities _ge;
        public NPNAnswers(pBaseEntities ge)
        {
            _ge = ge;
            _Danswers = new List<NPNAnswer>();
        }

        public NPNAnswers() { _Danswers = new List<NPNAnswer>(); }
        public NPNAnswer this[int index]
        {
            get { return _Danswers[index]; }
            set { _Danswers[index] = value; }
        }
        public void Add(NPNAnswer Answer)
        {
            _Danswers.Add(Answer);
        }
        public void Add(int selectedcellindex, string selectedcelldescription, string selectedcellbuttondescription, int answerindex, string answerdescription)
        {
            NPNAnswer ka = new NPNAnswer();
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
            get { return _Danswers.Count(); }
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
            return _Danswers.GetEnumerator();
        }

      

    }
}
