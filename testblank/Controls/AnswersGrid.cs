using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Recog.RecogCore.AnswerGrid;

namespace Recog.Controls
{
    public delegate void WorkAnswer(object sender, AnswerEventArgs arg);
   
    public partial class AnswersGrid : UserControl
    {
       
        private Answers _answers;
        private List<AnswerControl> _aclist;
        private AnswerEventArgs arg;
        private void OnAnswerSelect() { if (AnswerSelect != null) { AnswerSelect(this, arg); } }

        public event WorkAnswer AnswerSelect;

        public AnswerControl this[int index]
        {
            get { return _aclist[index]; }
        }
        public void AnswerOnCenter(int answerindex)
        {
            Point p = new Point(0, _aclist[answerindex].Location.Y);
            PanelParent.AutoScrollPosition = p;
        }

        public Answers Answers
        {
            get { return _answers; }
            set
            {

                _answers = value;
                for (int i = 0; i < _aclist.Count(); i++)
                {
                    _aclist[i].Answer = _answers[i];
                }
            }
        }

        public void CheckAnswerCell(int answerindex, int cellindex)
        {
            _aclist[answerindex].CheckButton(cellindex);
          
        }
        public void CheckAnswerCell(int answerindex, string buttondescription)
        {
            _aclist[answerindex].CheckButton(buttondescription);

        }

        public int AnswersCount
        {
            get { return _answers.Count; }
        }

        public AnswersGrid()
        {
            arg = new AnswerEventArgs();
            _aclist = new List<AnswerControl>();
            InitializeComponent();
        
        }



        public void AddAnswers(Answers Answers)
        {
            this.SuspendLayout();

            _answers = Answers;
            int y = 0;
            pb_progress.Value = 0;
            pb_progress.Minimum = 0;
            pb_progress.Step = 1;
            pb_progress.Maximum = _answers.Count;
            btn_recog.Enabled = false;
            for (int i = 0; i < _answers.Count; i++)
            {
                AnswerControl newAC = new AnswerControl();
                newAC.CreateCells(_answers[i]);
                newAC.Location = new Point(5, y);
                _aclist.Add(newAC);
                newAC.btn_ans.Click += new EventHandler(btn_ans_Click);
                newAC.CellSelect += new EventHandler(newAC_CellSelect);
                newAC.NullSelect += new EventHandler(newAC_NullSelect);
                newAC.CellIndexTextBox.GotFocus += new EventHandler(CellIndexTextBox_GotFocus);
                newAC.CellIndexTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c_KeyDown);
                newAC.MouseEnter += new EventHandler(newAC_MouseEnter);
                PanelChild.Controls.Add(newAC);
                pb_progress.PerformStep();
                y += newAC.Size.Height + 2;
                Application.DoEvents();
            }
            btn_recog.Enabled = true;
            this.ResumeLayout(true);

        }

        void newAC_MouseEnter(object sender, EventArgs e)
        {
            PanelParent.Focus();
        }

        void CellIndexTextBox_GotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            AnswerControl ac = (AnswerControl)tb.Parent;
            arg.CurrentAnsverControl = ac;
            arg.ControlType = ControlType.Button;
            this.OnAnswerSelect();
        }

        void newAC_NullSelect(object sender, EventArgs e)
        {
            AnswerControl ac = (AnswerControl)sender;
            arg.CurrentAnsverControl = ac;
            arg.ControlType = ControlType.NullCell;
            this.OnAnswerSelect();
        }
        public void ShowContent()
        {
            for (int i = 0; i < _aclist.Count(); i++)
            {
                _aclist[i].ShowContent();
            }
        }
        void newAC_CellSelect(object sender, EventArgs e)
        {
            AnswerControl ac = (AnswerControl)sender;
            arg.CurrentAnsverControl = ac;
            arg.ControlType = ControlType.Cell;
            this.OnAnswerSelect();
        }

        private void c_KeyDown(object sender, KeyEventArgs e)//переход по ентеру
        {
           
            Control c = (Control)sender;
            if (e.KeyCode == Keys.Down)
            {
                for (int i = 0; i < _aclist.Count; i++)
                {
                    Control cc = _aclist[i].CellIndexTextBox;
                    if (c == cc & i != _aclist.Count - 1) {
                     
                        _aclist[i + 1].CellIndexTextBox.Focus();
                        _aclist[i + 1].CellIndexTextBox.SelectAll();
                        break;
                    }
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                for (int i = 0; i < _aclist.Count; i++)
                {
                    Control cc = _aclist[i].CellIndexTextBox;
                    if (c == cc & i != 0)
                    {

                        _aclist[i - 1].CellIndexTextBox.Focus();
                        _aclist[i - 1].CellIndexTextBox.SelectAll();
                        break;
                    }
                }
            }
        }


        void btn_ans_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            AnswerControl ac = (AnswerControl)b.Parent;
            arg.CurrentAnsverControl = ac;
            arg.ControlType = ControlType.Button;
            this.OnAnswerSelect();
        }

      
        public void ClearContent()
        {
            for (int i = 0; i < _aclist.Count; i++)
            { _aclist[i].ClearContent(); }
        }

        private void PanelChild_MouseEnter(object sender, EventArgs e)
        {
            PanelParent.Focus();
        }

      

       

        

    }
}
