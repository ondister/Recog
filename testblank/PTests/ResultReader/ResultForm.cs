using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Windows.Forms;
using Recog.Data;
using Recog.PTests.References;
using Recog.Humans;
namespace Recog.PTests.ResultReader
{
    public partial class ResultForm : Form
    {
        private pBaseEntities _ge;
        private fBaseEntities _fe;
        private int _currenthumanid;
        private int _currenttestresult;
        private int _currentref;
        private ReferenceFactory _referfactory;
        public ResultForm(pBaseEntities ge, fBaseEntities fe)
        {
            InitializeComponent();
            _ge = ge;
            _fe = fe;

            HelpProvider help = new HelpProvider();
            help.HelpNamespace = "Recog_help.chm";
            help.SetHelpNavigator(this, HelpNavigator.Topic);
            help.SetHelpKeyword(this, "result_common.htm");
        }

        private void LoadHumansInList(string txtsearch)
        {
            var humanQuery = _fe.humans.Where("it.secondname  LIKE @sname+'%'", new ObjectParameter("sname", txtsearch.ToUpper()));
            this.dg_humans.DataSource = humanQuery.Execute(MergeOption.AppendOnly);

            //меняем интерфейс слегка
            this.dg_humans.Columns[2].DisplayIndex = 1;
            this.dg_humans.Columns[2].HeaderText = "ФАМИЛИЯ";
            this.dg_humans.Columns[1].DisplayIndex = 2;
            this.dg_humans.Columns[1].HeaderText = "ИМЯ";
            this.dg_humans.Columns[3].DisplayIndex = 3;
            this.dg_humans.Columns[3].HeaderText = "ОТЧЕСТВО";
            this.dg_humans.Columns[8].DisplayIndex = 4;
            this.dg_humans.Columns[8].HeaderText = "ДАТА РОЖДЕНИЯ";

            this.dg_humans.Columns[0].Visible = false;
            this.dg_humans.Columns[4].Visible = false;
            this.dg_humans.Columns[5].Visible = false;
            this.dg_humans.Columns[6].Visible = false;
            this.dg_humans.Columns[7].Visible = false;
            this.dg_humans.Columns[9].Visible = false;
            this.dg_humans.Columns[10].Visible = false;
            this.dg_humans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_humans.MultiSelect = false;
            if (dg_humans.Rows.Count == 0) { dg_testresults.Rows.Clear(); dg_references.Rows.Clear(); }
        }

       private void LoadTestresults()
        {
            dg_testresults.Rows.Clear();

            if (_currenthumanid != 0)
            {
                human h = _fe.humans.First(hh => hh.idh == _currenthumanid);
                 h.testresults.Load();
                 
                
                 IEnumerable<testresult> query = h.testresults.OrderBy(tst => tst.testdate);
                 foreach (testresult tr in query)
                {
                    string[] row = {
                                      tr.idtr.ToString(),
                                      tr.testid.ToString(),
                                      false.ToString(),
                                      tr.testdate.ToString(),
                                      _ge.testsparams.First(tp=>tp.idt==tr.testid).description.ToString(),
                                      tr.mode
                                  };

                    dg_testresults.Rows.Add(row);
                }
            }

        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            
                this.LoadHumansInList(this.tb_search.Text);
           

        }

        private void dg_humans_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _currenttestresult = 0;
            _currentref = 0;
            _currenthumanid = (int)dg_humans.Rows[e.RowIndex].Cells[0].Value;
            this.LoadTestresults();
            this.FillReferences();
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            LoadHumansInList(this.tb_search.Text);
            
        }

        private void dg_testresults_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _currenttestresult = Convert.ToInt16(dg_testresults.Rows[e.RowIndex].Cells[0].Value);
            
        }

        private void btn_printresult_Click(object sender, EventArgs e)
        {
            List<int> _listidtr = new List<int>();

            foreach (DataGridViewRow r in dg_testresults.Rows)
            {
                if (Convert.ToBoolean(r.Cells[2].Value) == true) { _listidtr.Add(Convert.ToInt16(r.Cells[0].Value)); }
            }

            if (_listidtr.Count() != 0)
            {
                foreach (int i in _listidtr)
                {
                    human h = _fe.humans.First(hh => hh.idh == _currenthumanid);
                    testresult t = _fe.testresults.First(tr => tr.idtr == i);
                    ITestReport rep = ReportFactory.CreateReport((EnumPTests)t.testid, h, t, _ge, _fe, false);
                    rep.Print();
                }
            }
            else { MessageBox.Show("Нужно выбрать хоть один тест"); }
        }

        private void FillReferences()
        {
            dg_references.Rows.Clear();
            if (_currenthumanid != 0)
            {
                dg_references.Rows.Clear();
                human h = _fe.humans.First(hh => hh.idh == _currenthumanid);
                _referfactory = new ReferenceFactory(h,_ge,_fe);
                for (int rowindex = 0; rowindex < _referfactory.EvalRefs.Count; rowindex++)
                {
                    dg_references.Rows.Add(_referfactory.EvalRefs[rowindex]);
                }
            }
        }

        private void dg_references_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = dg_testresults.Rows.Count - 1; i >= 0; i--)
            {
                dg_testresults.Rows[i].Cells[2].Value = false;
            }

            List<int> _usedtests = _referfactory.GetUsedTestIds((EnumPReferences)Convert.ToInt16(dg_references.Rows[e.RowIndex].Cells[0].Value));

            for (int testid = 0; testid < _usedtests.Count; testid++)
            {
                for (int rowindex = dg_testresults.Rows.Count - 1; rowindex >= 0; rowindex--)
                {
                    DataGridViewRow row = dg_testresults.Rows[rowindex];
                if (Convert.ToInt16(row.Cells[0].Value) == _usedtests[testid])
                    {
                        row.Cells[2].Value = true; break;
                    }
                }
                //foreach (DataGridViewRow row in dg_testresults.Rows)
                //{
                //    if (Convert.ToInt16(row.Cells[0].Value) == _usedtests[testid])
                //    {
                //        row.Cells[2].Value = true; break;
                //    }
                //}
            }

            _currentref = Convert.ToInt16(dg_references.Rows[e.RowIndex].Cells[0].Value);
        }

        private void btn_printchar_Click(object sender, EventArgs e)
        {
           
            if (_currenthumanid != 0)
            {
                List<int> checkedtestids=new List<int>();
                foreach (DataGridViewRow row in dg_testresults.Rows)
                {
                    if ((bool)row.Cells[2].Value ==true)
                    {
                       checkedtestids.Add(Convert.ToInt16(row.Cells[0].Value));
                    }
                }

                IReference reference = _referfactory.GetReference(checkedtestids, (EnumPReferences)_currentref);
                if (reference != null) { reference.Print(); }
               
            }
        }

        private int IsTestChecked(int TestID)
        {
            foreach (DataGridViewRow r in dg_testresults.Rows)
            {
                if (Convert.ToBoolean(r.Cells[2].Value) == true & Convert.ToInt16(r.Cells[1].Value) == TestID) { return Convert.ToInt16(r.Cells[0].Value); }
            }
            return -1;
        }



        private void btn_delhuman_Click(object sender, EventArgs e)
        {
            if (_currenthumanid != 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить все данные о человеке включая результаты тестов?", "Удаление данных о человеке", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                { this.DelHuman(_currenthumanid); }
            }

        }


        private void DelHuman(int idh)
        {
            if (_fe.humans.Count(h => h.idh == idh) != 0)
            {
                human dh = _fe.humans.First(h => h.idh == idh);
                _fe.humans.DeleteObject(dh);
                _fe.SaveChanges();
                if (_fe.humans.Count() == 0) { _currenthumanid = 0; }
                this.LoadTestresults();
                this.FillReferences();
            }
        }

        private void btn_showchart_Click(object sender, EventArgs e)
        {
            List<int> _listidtr = new List<int>();

            foreach (DataGridViewRow r in dg_testresults.Rows)
            {
                if (Convert.ToBoolean(r.Cells[2].Value) == true) { _listidtr.Add(Convert.ToInt16(r.Cells[0].Value)); }
            }

            if (_listidtr.Count() != 0)
            {
                foreach (int i in _listidtr)
                {
                    testresult t = _fe.testresults.First(tr => tr.idtr == i);
                    testsparam tp = _ge.testsparams.First(tt => tt.idt == t.testid);
                    if (t.mode == "auto")
                    {
                        TimeLineForm tlf = new TimeLineForm(t);
                        tlf.Text = "График скорости: " + tp.description + " от " + t.testdate;
                        tlf.Show();
                    }
                }
            }
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            if (_currenthumanid != 0)
            {
                ReadHumanForm humanfrm = new ReadHumanForm(_fe, _currenthumanid);
                humanfrm.ShowDialog();
            }
        }

        private void btn_show_answers_Click(object sender, EventArgs e)
        {
            List<int> _listidtr = new List<int>();

            foreach (DataGridViewRow r in dg_testresults.Rows)
            {
                if (Convert.ToBoolean(r.Cells[2].Value) == true) { _listidtr.Add(Convert.ToInt16(r.Cells[0].Value)); }
            }

            if (_listidtr.Count() != 0)
            {
                foreach (int i in _listidtr)
                {
                    human h = _fe.humans.First(hh => hh.idh == _currenthumanid);
                    testresult t = _fe.testresults.First(tr => tr.idtr == i);
                    if (_ge.testsparams.First(tp => tp.idt == t.testid).answerscount != 0)
                    {
                        TestResultForm testform = new TestResultForm(t,h.idh,_ge, _fe);
                        testform.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
                        testform.ShowDialog();
                       
                    }
                }
            }
            else { MessageBox.Show("Нужно выбрать хоть один тест"); }
        }

        private void dg_testresults_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != 2)
            {
                dg_testresults.Rows[e.RowIndex].Cells[2].Value = !Convert.ToBoolean(dg_testresults.Rows[e.RowIndex].Cells[2].Value);
            }
            }

        













    }
}
