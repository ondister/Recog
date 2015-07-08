using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
using System.Collections;

namespace Recog.PTests.Addictive
{
   public class AAnswers:ICollection,IAnswers
    {
       private List<AAnswer> _aanswers;
        private pBaseEntities _ge;
        public AAnswers(pBaseEntities ge)
        {
            _ge = ge;
            _aanswers = new List<AAnswer>();
        }

        public AAnswers() { _aanswers = new List<AAnswer>(); }
        public AAnswer this[int index]
        {
            get { return _aanswers[index]; }
            set { _aanswers[index] = value; }
        }
        public void Add(AAnswer Answer)
        {
            _aanswers.Add(Answer);
        }
        public void Add(int selectedcellindex, string selectedcelldescription, string selectedcellbuttondescription, int answerindex, string answerdescription)
        {
            AAnswer ka = new AAnswer();
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
            get { return _aanswers.Count(); }
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
            return _aanswers.GetEnumerator();
        }

      

    }
}
