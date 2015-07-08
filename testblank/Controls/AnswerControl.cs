using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Recog.RecogCore.AnswerGrid;
namespace Recog.Controls
{
    public partial class AnswerControl : UserControl
    {
        private Answer _answer;
        private List<RadioButton> _controlcells;
        private RadioButton _null;
        private TextBox newtb;
        private RadioButton rb;
        public Button btn_ans;
        private bool _reentry = false;//костыль для предотвращения перекрестного вызова нажатия на кнопку и изменения текства
        public TextBox CellIndexTextBox
        {
            get { return newtb; }
        }

        public int SelectedCellIndex
        {
            get
            {
                int i;
                bool result = Int32.TryParse(newtb.Text, out i);
                if (result) { return i; }
                else
                { return 0; }
            }
            set { newtb.Text = value.ToString(); }
        }


        private void OnCellSelect() { if (CellSelect != null) { CellSelect(this, new EventArgs()); } }

        private void OnNullSelect() { if (NullSelect != null) { NullSelect(this, new EventArgs()); } }

        public event EventHandler CellSelect;
        public event EventHandler NullSelect;

        public Answer Answer
        {
            get { return _answer; }
            set
            {
                _answer = value;
                this.ShowContent();
            }
        }


        public AnswerControl()
        {
            InitializeComponent();

            _controlcells = new List<RadioButton>();
           

        }

        public void ClearContent()
        {
            this.SelectedCellIndex = 0;
            rb.Checked = true;
        }
        public void ShowContent()
        {
            bool hastrue = false;
            for (int i = 0; i < _answer.Cells.Count; i++)
            {
                _controlcells[i].Checked = _answer.Cells[i].Content;
                if (_answer.Cells[i].Content == true) { hastrue = true; break; }
            }
            if (hastrue == false) { _null.Checked = true; }
            if (_answer.IsDoubleCross == true ) { this.YellowLight(); }
            if (_answer.IsWithMiss == true) { this.GrayLight(); }
            ToolTip RemarkToolTip = new ToolTip();
            RemarkToolTip.SetToolTip(this.btn_ans, _answer.RecognitionRemarks);

        }

        public void CreateCells(Answer Answer)
        {
            this.SuspendLayout();
            _answer = Answer;

             //add button whith number of button
            btn_ans = new Button();
            this.btn_ans.Location = new Point(0, 2);
            this.btn_ans.Size = new Size(95, 30);
            this.btn_ans.FlatStyle = FlatStyle.Popup;
            this.btn_ans.TextAlign = ContentAlignment.MiddleCenter;
            this.btn_ans.Text = _answer.Id.ToString();
            this.Controls.Add(btn_ans);

            int _rbcount = _answer.Cells.Count;
            //addbutton_noanswer

            rb = new RadioButton();

            rb.Location = new Point(100, 2);
            rb.Size = new Size(40, 30);
            rb.Appearance = Appearance.Button;
            rb.FlatStyle = FlatStyle.Flat;
            rb.TextAlign = ContentAlignment.MiddleCenter;
            rb.Text = "Б/О";
            rb.CheckedChanged += new EventHandler(rb_CheckedChanged);
            this.RedLight();
            _null = rb;
            this.Controls.Add(rb);

            //add all buttons
            int x = 145;
            for (int i = 0; i < _rbcount; i++)
            {

                RadioButton newrb = new RadioButton();
                newrb.Location = new Point(x, 2);
                newrb.Size = new Size(40, 30);
                newrb.Appearance = Appearance.Button;
                newrb.FlatStyle = FlatStyle.Flat;
                newrb.TextAlign = ContentAlignment.MiddleCenter;
                newrb.Text = _answer.Cells[i].ContentDescription;
                newrb.CheckedChanged += new EventHandler(newrb_CheckedChanged);
                _controlcells.Add(newrb);
                this.Controls.Add(newrb);

                x += 40 + 5;
            }
            //add textedit with flatstile
            newtb = new TextBox();
            newtb.Location = new Point(x, 6);
            newtb.Size = new Size(20, 30);
            newtb.BorderStyle = BorderStyle.FixedSingle;
            newtb.MaxLength = 1;
            newtb.TextChanged += new EventHandler(newtb_TextChanged);
            newtb.GotFocus += new EventHandler(newtb_GotFocus);
            this.Controls.Add(newtb);
            x += 20;
            this.ShowContent();
            this.Width = x + 5;
            this.ResumeLayout(true);
        }

        void newtb_GotFocus(object sender, EventArgs e)
        {
            this.newtb.SelectAll();
        }

        void newtb_TextChanged(object sender, EventArgs e)
        {
            if (_reentry == false)
            {
                if (this.SelectedCellIndex != 0 & this.SelectedCellIndex <= _controlcells.Count)
                {
                    _controlcells[this.SelectedCellIndex - 1].Checked = true;
                }
                else { rb.Checked = true; }
            }
            this.newtb.SelectAll();
        }

        void newrb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = (RadioButton)sender;
            for (int i = 0; i < _controlcells.Count(); i++)
            {
             
                if (r.Text.Trim() == _controlcells[i].Text.Trim())
                {
                    _answer.Cells[i].Content = r.Checked;
                    _answer.ContentDescription = _answer.Cells[i].ContentDescription;
                    _answer.Cells[i].NeuroContent = CellContent.Cross;
                    _reentry = true;
                    this.SelectedCellIndex = i + 1;
                    _reentry = false;
                }
            }
            this.OnCellSelect();
            this.GreenLight();

        }

        public void CheckButton(int btnindex)
        {
            _controlcells[btnindex].Checked = true;
            _answer.Cells[btnindex].Content = true;
            _answer.ContentDescription = _answer.Cells[btnindex].ContentDescription;
            _answer.Cells[btnindex].NeuroContent = CellContent.Cross;
            _reentry = true;
            this.SelectedCellIndex = btnindex + 1;
            _reentry = false;
            this.OnCellSelect();
            this.GreenLight();
        }

        private delegate void ButtonWork(string buttondescription);

        private void selectbutton(string buttondescription)
        {
             int btnindex=-1;


             for (int buttonindex = 0; buttonindex < _controlcells.Count; buttonindex++)
             {
                 if (_controlcells[buttonindex].Text == buttondescription)
                 {
                     btnindex = buttonindex;
                     break;
                 }
             }

            if (btnindex != -1)
            {
                _controlcells[btnindex].Checked = true;
                _answer.Cells[btnindex].Content = true;
                _answer.ContentDescription = _answer.Cells[btnindex].ContentDescription;
                _answer.Cells[btnindex].NeuroContent = CellContent.Cross;
                _reentry = true;
                this.SelectedCellIndex = btnindex + 1;
                _reentry = false;
                this.OnCellSelect();
                this.GreenLight();
            }
        }

        public void CheckButton(string buttondescription)
        {
           
                BeginInvoke(new ButtonWork(selectbutton),new object[]{buttondescription});
               
         
        }

        void rb_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < _controlcells.Count(); i++)
            {
                _answer.Cells[i].Content = false;
                _answer.ContentDescription = "";
                _answer.Cells[i].NeuroContent = CellContent.Free;
            }
            _reentry = true;
            this.SelectedCellIndex = 0;
            _reentry = false;
            this.OnNullSelect();
            this.RedLight();
        }

        public void GreenLight()
        { this.BackColor = Color.ForestGreen; }
        public void RedLight()
        { this.BackColor = Color.RosyBrown; }
        public void YellowLight()
        { this.BackColor = Color.DarkGoldenrod; }
        public void GrayLight()
        { this.BackColor = Color.LightGray; }

        private void btn_ans_Click(object sender, EventArgs e)
        {
            newtb.Focus();
           // newtb.SelectAll();
        }

       


    }
}
