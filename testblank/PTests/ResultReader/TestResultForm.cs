using System;
using System.Linq;
using System.Windows.Forms;
using Recog.Controls;
using Recog.Data;
using Recog.PTests.Addictive;
using Recog.PTests.D;
using Recog.PTests.FPI;
using Recog.PTests.Kettell;
using Recog.PTests.Leongard;
using Recog.PTests.MD;
using Recog.PTests.NPNA;
using Recog.PTests.Prognoz;
using Recog.RecogCore.AnswerGrid;
using AForge;

namespace Recog.PTests.ResultReader
{
    public partial class TestResultForm : Form
    {
        private pBaseEntities _ge;
        private fBaseEntities _fe;
        private testresult _testresult;
        private Answers _answers;
        private testsparam _testparam;
        private int _humanid;
        private ToolTip RemarkToolTip;
        public TestResultForm(testresult tstresult, int humanid, pBaseEntities ge, fBaseEntities fe)
        {
            InitializeComponent();
            _ge = ge;
            _fe = fe;
            _testresult = tstresult;
            _humanid = humanid;

            RemarkToolTip = new ToolTip();
            RemarkToolTip.ToolTipIcon = ToolTipIcon.Info;
            RemarkToolTip.ToolTipTitle = "Вопрос:";
            RemarkToolTip.IsBalloon = true;

            HelpProvider help = new HelpProvider();
            help.HelpNamespace = "Recog_help.chm";
            help.SetHelpNavigator(this, HelpNavigator.Topic);
            help.SetHelpKeyword(this, "result_character.htm#test_view");
        }

        private void TestResultForm_Load(object sender, EventArgs e)
        {
            answers_grid.btn_recog.Text = "Сохранить в базу";
            answers_grid.btn_recog.Click += new EventHandler(btn_recog_Click);
            _testparam = _ge.testsparams.First(tp => tp.idt == _testresult.testid);
            this.Text = "Просмотр: " + _testparam.description;
            this.FillAnswerGrid();
        }

        void btn_recog_Click(object sender, EventArgs e)
        {

            switch ((EnumPTests)_testparam.idt)
            {
                case EnumPTests.Adaptability:
                    DAnswers da = new DAnswers();
                    AnswersFactory.UpdateTestFromAnswers<DAnswers>(da, answers_grid, _testresult, _ge);
                    break;
                case EnumPTests.Addictive:
                    AAnswers aa = new AAnswers();
                    AnswersFactory.UpdateTestFromAnswers<AAnswers>(aa, answers_grid, _testresult, _ge);
                    break;
                case EnumPTests.FPI:
                    FPIAnswers fa = new FPIAnswers();
                    AnswersFactory.UpdateTestFromAnswers<FPIAnswers>(fa, answers_grid, _testresult, _ge);
                    break;
                case EnumPTests.KettellA:
                    KettellAnswers kaa = new KettellAnswers();
                    AnswersFactory.UpdateTestFromAnswers<KettellAnswers>(kaa, answers_grid, _testresult, _ge);
                    break;
                case EnumPTests.KettellC:
                    KettellAnswers kca = new KettellAnswers();
                    AnswersFactory.UpdateTestFromAnswers<KettellAnswers>(kca, answers_grid, _testresult, _ge);
                    break;
                case EnumPTests.Leongard:
                    LAnswers la = new LAnswers();
                    AnswersFactory.UpdateTestFromAnswers<LAnswers>(la, answers_grid, _testresult, _ge);
                    break;
                case EnumPTests.Modul2:
                    MDAnswers ma = new MDAnswers();
                    AnswersFactory.UpdateTestFromAnswers<MDAnswers>(ma, answers_grid, _testresult, _ge);
                    break;
                case EnumPTests.NPNA:
                    NPNAnswers na = new NPNAnswers();
                    AnswersFactory.UpdateTestFromAnswers<NPNAnswers>(na, answers_grid, _testresult, _ge);
                    break;
                case EnumPTests.Prognoz:
                    PAnswers pa = new PAnswers();
                    AnswersFactory.UpdateTestFromAnswers<PAnswers>(pa, answers_grid, _testresult, _ge);
                    break;
            }

            this.Close();
        }


        private void FillAnswerGrid()
        {
            _answers = new Answers();

            _testparam.answersparams.Load();
            foreach (answersparam ap in _testparam.answersparams)
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
                _answers.Add(aga);
            }

        }

        private void TestResultForm_Shown(object sender, EventArgs e)
        {
            using (new AutoWaitCursor(this))
            {
           
                answers_grid.AddAnswers(_answers);
                answers_grid.AnswerSelect += new WorkAnswer(answers_grid_AnswerSelect);
               
                this.FillAnswers();
                this.lb_errors.Text = "Вопросов без ответа: " + answers_grid.Answers.CountWithEmpty.ToString();
                this.SetTollTips();
            }
        }

        private void FillAnswers()
        {
          
            switch ((EnumPTests)_testparam.idt)
            {
                case EnumPTests.Adaptability:
                    DAnswers da = AnswersFactory.GetAnswersFromTestResult<DAnswers>(_testresult);
                    Parallel.For(0, da.Count, answerindex =>
                    {
                        if (da[answerindex].SelectedCellDescription != "")
                        {
                            answers_grid.CheckAnswerCell(answerindex, da[answerindex].SelectedCellDescription);
                        }
                    });
                    break;
                case EnumPTests.Addictive:
                    AAnswers aa = AnswersFactory.GetAnswersFromTestResult<AAnswers>(_testresult);
                    Parallel.For(0, aa.Count, answerindex =>
                    {
                        if (aa[answerindex].SelectedCellDescription != "")
                        {
                            answers_grid.CheckAnswerCell(answerindex, aa[answerindex].SelectedCellDescription);
                        }
                    });
                    break;
                case EnumPTests.FPI:
                    FPIAnswers fa = AnswersFactory.GetAnswersFromTestResult<FPIAnswers>(_testresult);
                    Parallel.For(0, fa.Count, answerindex =>
                    {
                        if (fa[answerindex].SelectedCellDescription != "")
                        {
                            answers_grid.CheckAnswerCell(answerindex, fa[answerindex].SelectedCellDescription);
                        }
                    });
                    break;
                case EnumPTests.KettellA:
                    KettellAnswers kaa = AnswersFactory.GetAnswersFromTestResult<KettellAnswers>(_testresult);
                    Parallel.For(0, kaa.Count, answerindex =>
                    {
                        if (kaa[answerindex].SelectedCellDescription != "")
                        {
                            answers_grid.CheckAnswerCell(answerindex, kaa[answerindex].SelectedCellDescription);
                        }
                    });
                    break;
                case EnumPTests.KettellC:
                    KettellAnswers kca = AnswersFactory.GetAnswersFromTestResult<KettellAnswers>(_testresult);
                    Parallel.For(0, kca.Count, answerindex =>
                    {
                        if (kca[answerindex].SelectedCellDescription != "")
                        {
                            answers_grid.CheckAnswerCell(answerindex, kca[answerindex].SelectedCellDescription);
                        }
                    });
                    break;
                case EnumPTests.Leongard:
                    LAnswers la = AnswersFactory.GetAnswersFromTestResult<LAnswers>(_testresult);
                    Parallel.For(0, la.Count, answerindex =>
                    {
                        if (la[answerindex].SelectedCellDescription != "")
                        {
                            answers_grid.CheckAnswerCell(answerindex, la[answerindex].SelectedCellDescription);
                        }
                    });
                    break;
                case EnumPTests.Modul2:
                    MDAnswers ma = AnswersFactory.GetAnswersFromTestResult<MDAnswers>(_testresult);

                    Parallel.For(0, ma.Count, answerindex =>
            {
                if (ma[answerindex].SelectedCellDescription != "")
                {
                    answers_grid.CheckAnswerCell(answerindex, ma[answerindex].SelectedCellDescription);
                }
            });

                    break;
                case EnumPTests.NPNA:
                    NPNAnswers na = AnswersFactory.GetAnswersFromTestResult<NPNAnswers>(_testresult);
                    Parallel.For(0, na.Count, answerindex =>
                    {
                        if (na[answerindex].SelectedCellDescription != "")
                        {
                            answers_grid.CheckAnswerCell(answerindex, na[answerindex].SelectedCellDescription);
                        }
                    });
                    break;
                case EnumPTests.Prognoz:
                    PAnswers pa = AnswersFactory.GetAnswersFromTestResult<PAnswers>(_testresult);
                    Parallel.For(0, pa.Count, answerindex =>
                    {
                        if (pa[answerindex].SelectedCellDescription != "")
                        {
                            answers_grid.CheckAnswerCell(answerindex, pa[answerindex].SelectedCellDescription);
                        }
                    });
                    break;
            }
        }

        public void SetTollTips()
        {
            for (int controlindex = 0; controlindex < answers_grid.AnswersCount; controlindex++)
            {

                answersparam aparam = _testparam.answersparams.First(a => a.num == answers_grid[controlindex].Answer.Id);
                string label = aparam.buttondescription.Trim();
                if (answers_grid[controlindex].Answer.ContentDescription.Trim() != "")
                {
                    string celldescription = answers_grid[controlindex].Answer.ContentDescription.Trim();
                    cellsparam c = _ge.cellsparams.First(cp => cp.ida == aparam.ida & cp.description == celldescription);
                    label += ": \n" + c.buttonsescription;
                }
                else
                {
                    label += ": \n нет ответа";
                }
                RemarkToolTip.SetToolTip(answers_grid[controlindex].btn_ans, label);
            }
        }

        public void SetTollTips(AnswerControl control)
        {

            answersparam aparam = _testparam.answersparams.First(a => a.num == control.Answer.Id);
            string label = aparam.buttondescription.Trim();
            if (control.Answer.ContentDescription.Trim() != "")
            {
                cellsparam c = _ge.cellsparams.First(cp => cp.ida == aparam.ida & cp.description == control.Answer.ContentDescription.Trim());
                label += ": \n" + c.buttonsescription;
            }
            else
            {
                label += ": \n нет ответа";
            }
            RemarkToolTip.SetToolTip(control.btn_ans, label);

        }

        void answers_grid_AnswerSelect(object sender, AnswerEventArgs arg)
        {

            this.lb_errors.Text = "Вопросов без ответа: " + answers_grid.Answers.CountWithEmpty.ToString();
            SetTollTips(arg.CurrentAnsverControl);

        }



    }
}
