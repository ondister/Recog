using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Recog.Controls;
using Recog.Data;
using Recog.PTests;
using Recog.PTests.D;
using Recog.PTests.FPI;
using Recog.PTests.Kettell;
using Recog.RecogCore;
using Recog.RecogCore.AnswerGrid;
using Recog.Scaning;
using TwainDotNet.WinFroms;

namespace Recog.BlankRecognition
{
    public partial class RForm : Form
    {
        private int _testid;
        private int _humanid;
        private pBaseEntities _ge;
        private fBaseEntities _fe;
        private RecogCore.AnswerGrid.Answers answs;
        private Canvas _canvas;
        private ScanerManager _sm;
        private ToolTip RemarkToolTip;
        private int _toolaindex = -1;
        private int _toolcindex = -1;
        private testresult _testresult = null;

        public testresult TestResult
        {
            get { return _testresult; }
        }
        public RForm(int TestID, int HumanID, pBaseEntities ge,fBaseEntities fe)
        {
            InitializeComponent();

            _ge = ge;
            _fe = fe;
            _testid = TestID;
            _humanid = HumanID;
            _sm = new ScanerManager(_ge, new WinFormsWindowMessageHook(this));
            RemarkToolTip = new ToolTip();
            RemarkToolTip.ToolTipIcon = ToolTipIcon.Info;
            RemarkToolTip.ToolTipTitle = "Вопрос:";
            RemarkToolTip.IsBalloon = true;

            HelpProvider help = new HelpProvider();
            help.HelpNamespace = "Recog_help.chm";
            help.SetHelpNavigator(this, HelpNavigator.Topic);
            help.SetHelpKeyword(this, "test_blank.htm");
        }

        private void RecogForm_Load(object sender, EventArgs e)
        {

            answs = new Answers();
            testsparam t = _ge.testsparams.First(tp => tp.idt == _testid);
            t.answersparams.Load();
            foreach (answersparam ap in t.answersparams)
            {
                Answer aga = new Answer();
                aga.Id = ap.num.Value;
                ap.cellsparams.Load();
                foreach (cellsparam cp in ap.cellsparams)
                {
                    Cell c = new Cell();
                    c.ContentDescription = cp.description.Trim();
                    aga.Cells.Add(c);
                }
                answs.Add(aga);

            }
            human h = _fe.humans.First(hh => hh.idh == _humanid);

            this.Text = "Распознавание бланка: " + t.description + " для " + h.secondname + " " + h.firstname;

        }

        void btn_recog_Click(object sender, EventArgs e)
        {

            if (this.pb_formimage.Image != null)
            {

                try
                {

                    this.ag_answers.pb_progress.Value = 0;
                    this.ag_answers.pb_progress.Minimum = 0;
                    this.ag_answers.pb_progress.Step = 1;
                    this.ag_answers.pb_progress.Maximum = this.ag_answers.AnswersCount;
                    this.ag_answers.btn_recog.Text = "Идет распознавание...";
                    Recognizer r = new Recognizer(_ge, (Bitmap)this.pb_formimage.Image, _testid);
                    r.RecItem += new EventHandler(r_RecItem);
                    r.Prerecognize();

                    RecogResult rr = r.FindBestRecognize();

                    r.Recognize(rr.RangeWidth, rr.MinDisp);
                    _canvas = r.Canvas;
                    this.ag_answers.Answers = r.Canvas.Answers;
                    answs = r.Canvas.Answers;
                    r.Canvas.Answers.SelectTrueCell();
                    this.pb_formimage.Image = r.Canvas.CorrectedImage;

                    this.ag_answers.btn_recog.Text = "Распознавание завершено";
                    this.ag_answers.pb_progress.Value = this.ag_answers.pb_progress.Maximum;
                    this.ag_answers.btn_recog.Enabled = false;
                    this.btn_scan.Enabled = false;
                    if (r.Canvas.Answers.CountWithEmpty + r.Canvas.Answers.CountWithMiss > 15)
                    {
                        DialogResult dr = MessageBox.Show("Слишком много ошибок при распознавании.\nПричинами может являтся несоответствие бланка и выбранного теста или некорректные настройки яркости-контрастности сканера.\nБолее подробно читайте в справочной информации к программе.\nЖелаете пересканировать этот бланк?", "Проблемы распознавания", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            RForm rf = new RForm(this._testid, this._humanid, _ge,_fe);
                            rf.WindowState = FormWindowState.Maximized;
                            this.Close();
                            rf.ShowDialog();

                        }

                    }

                    this.lb_status.Text = "Итоги распознавания: вопросов без ответа: " + r.Canvas.Answers.CountWithEmpty.ToString() + ", ошибочных ответов: " + r.Canvas.Answers.CountWithMiss.ToString() + ", несколько ответов в вопросе: " + r.Canvas.Answers.CountWithDoubleCross.ToString();
                    this.lb_status.Visible = true;
                    this.chb_onofdesc.Visible = true;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); this.Close(); }
            }
            else { MessageBox.Show("Нет изображения"); }

        }

        void r_RecItem(object sender, EventArgs e)
        {
            this.ag_answers.pb_progress.PerformStep();
        }

        private void btn_scan_Click(object sender, EventArgs e)
        {


            _sm.GetDevicefromBase();


            if (_sm.CurrentScaner != null)
            {
                this.Text = this.Text + " // Сканер: " + _sm.CurrentScaner.Name;
                _sm.CurrentScaner.ScanDone += new EventHandler(CurrentScaner_ScanDone);
                Enabled = false;
                _sm.CurrentScaner.Scan();

                Enabled = true;

            }
            else { MessageBox.Show("Сканер не указан. Выберите сканер в меню Справка->Выбор сканера"); }
        }

        void CurrentScaner_ScanDone(object sender, EventArgs e)
        {
            this.pb_formimage.Image = _sm.CurrentScaner.Image;
        }

        private void PictAnswerOnCenter(AnswerControl selectedanswer)
        {
            p_parent.AutoScrollPosition = new Point(selectedanswer.Answer.Cells[0].CenterOfGravity.X - 100, selectedanswer.Answer.Cells[0].CenterOfGravity.Y - 100);
        }

      

        private void ag_answers_AnswerSelect(object sender, Controls.AnswerEventArgs arg)
        {
            if (_canvas != null)
            {
                if (_canvas.Answers.Count != 0)
                {
                    switch (arg.ControlType)
                    {
                        case ControlType.Button:
                            _canvas.Answers.Clear();
                            _canvas.Answers.SelectTrueCell();
                            arg.CurrentAnsverControl.Answer.Select();
                            this.PictAnswerOnCenter(arg.CurrentAnsverControl);
                            break;
                        case ControlType.Cell:
                            arg.CurrentAnsverControl.Answer.Clear();
                            arg.CurrentAnsverControl.Answer.SelectTrueCell();
                            break;

                        case ControlType.NullCell:
                            arg.CurrentAnsverControl.Answer.Clear();
                            arg.CurrentAnsverControl.Answer.SelectTrueCell();
                            break;
                    }
                    this.pb_formimage.Image = _canvas.CorrectedImage;
                    this.lb_status.Text = "Итоги коррекции: вопросов без ответа: " + ag_answers.Answers.CountWithEmpty.ToString() + ", ошибочных ответов: " + ag_answers.Answers.CountWithMiss.ToString() + ", несколько ответов в вопросе: " + ag_answers.Answers.CountWithDoubleCross.ToString();
                }
            }
        }

        private void RecogForm_Shown(object sender, EventArgs e)
        {
            this.ag_answers.btn_recog.Click += new EventHandler(btn_recog_Click);
            this.ag_answers.AddAnswers(answs);
        }

        private void btn_addtobase_Click(object sender, EventArgs e)
        {
            ITest tst = TestFactory.CreateTest((EnumPTests)_testid, _ge, _fe, true);
            tst.HumanID = _humanid;
           _testresult = tst.ResultsToBase(this.ag_answers.Answers);
            this.Close();

        }

        private void pb_formimage_MouseMove(object sender, MouseEventArgs e)
        {
            //TODO:центрирование подсказки по центру
            if (chb_onofdesc.Checked == true)
            {

                try
                {

                    int i = ag_answers.Answers.GetAnswerIndex(new Point(e.X, e.Y));
                    int ci = ag_answers.Answers.GetCellIndex(new Point(e.X, e.Y));
                    string f = ag_answers.Answers.GetCellDescription(new Point(e.X, e.Y));
                    if (i != -1)
                    {
                        if (i != _toolaindex || ci != _toolcindex)
                        {
                            _toolaindex = i;
                            _toolcindex = ci;
                            answersparam a = _ge.answersparams.First(ap => ap.idt == _testid & ap.num == i + 1);
                            cellsparam c = _ge.cellsparams.First(cp => cp.ida == a.ida & cp.description == f.Trim());
                            RemarkToolTip.SetToolTip(this.pb_formimage, a.buttondescription + "\nОтвет:" + c.buttonsescription);
                        }
                    }
                    else
                    { RemarkToolTip.Hide(this.pb_formimage); }
                }
                catch
                {
                    RemarkToolTip.SetToolTip(this.pb_formimage, "Не удалось получить описание вопроса");
                }
            }
            else { RemarkToolTip.Hide(this.pb_formimage); }
        }

        private void chb_onofdesc_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_onofdesc.Checked == false)
            { chb_onofdesc.Text = "Вкл. описание ответов"; }
            else
            { chb_onofdesc.Text = "Выкл. описание ответов"; }
        }

        private void pb_formimage_MouseEnter(object sender, EventArgs e)
        {
            p_parent.Focus();
        }

        private void pb_formimage_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {

                int i = ag_answers.Answers.GetAnswerIndex(new Point(e.X, e.Y));
                int ci = ag_answers.Answers.GetCellIndex(new Point(e.X, e.Y));
                if (i != -1)
                {
                    ag_answers.CheckAnswerCell(i, ci);
                    ag_answers.AnswerOnCenter(i);
                }
            }
            catch
            {
                RemarkToolTip.SetToolTip(this.pb_formimage, "Не удалось получить описание вопроса");
            }
        }

       

              

        
    }
}
