using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
using System.Collections;

namespace Recog.PTests.D
{
   public class DAnswers:ICollection,IAnswers
    {
       private List<DAnswer> _Danswers;
        private pBaseEntities _ge;
        public DAnswers(pBaseEntities ge)
        {
            _ge = ge;
            _Danswers = new List<DAnswer>();
        }

        public DAnswers() { _Danswers = new List<DAnswer>(); }
        public DAnswer this[int index]
        {
            get { return _Danswers[index]; }
            set { _Danswers[index] = value; }
        }
        public void Add(DAnswer Answer)
        {
            _Danswers.Add(Answer);
        }
        public void Add(int selectedcellindex, string selectedcelldescription, string selectedcellbuttondescription, int answerindex, string answerdescription)
        {
            DAnswer ka = new DAnswer();
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
