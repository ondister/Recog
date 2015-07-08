using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
using System.Collections;

namespace Recog.PTests.FPI
{
    public class FPIAnswers : ICollection, IAnswers
    {
       private List<FPIAnswer> _FPIanswers;
        private pBaseEntities _ge;
        public FPIAnswers(pBaseEntities ge)
        {
            _ge = ge;
            _FPIanswers = new List<FPIAnswer>();
        }

        public FPIAnswers() { _FPIanswers = new List<FPIAnswer>(); }
        public FPIAnswer this[int index]
        {
            get { return _FPIanswers[index]; }
            set { _FPIanswers[index] = value; }
        }
        public void Add(FPIAnswer Answer)
        {
            _FPIanswers.Add(Answer);
        }
        public void Add(int selectedcellindex, string selectedcelldescription, string selectedcellbuttondescription, int answerindex, string answerdescription)
        {
            FPIAnswer ka = new FPIAnswer();
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
            get { return _FPIanswers.Count(); }
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
            return _FPIanswers.GetEnumerator();
        }

      
    }
}
