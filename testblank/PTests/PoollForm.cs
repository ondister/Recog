using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Recog.Data;
using Recog.BlankRecognition;
using Recog.PTests.PNN;
using Recog.PTests.Kettell;
using Recog.PTests.FPI;
using Recog.PTests.D;
namespace Recog.PTests
{
    public partial class PoollForm : Form
    {
        private pBaseEntities _ge;
        private fBaseEntities _fe;
        public PoollForm(pBaseEntities ge, fBaseEntities fe)
        {
            InitializeComponent();
            _ge = ge;
            _fe = fe;

            HelpProvider help = new HelpProvider();
            help.HelpNamespace = "Recog_help.chm";
            help.SetHelpNavigator(this, HelpNavigator.Topic);
            help.SetHelpKeyword(this, "test_common.htm");
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PoollForm_Load(object sender, EventArgs e)
        {

            this.LoadTests(this.lst_manual, true);
            this.LoadTests(this.lst_all, false);
            this.LoadTests(this.lst_sten, false);
            this.LoadPacks();//загружаем кортежи

            this.lst_manual.Columns[1].Width = this.lst_manual.Width;
            this.lst_all.Columns[1].Width = this.lst_all.Width;
            this.lst_sten.Columns[1].Width = this.lst_sten.Width;
            this.lst_pooll.Columns[1].Width = this.lst_pooll.Width;
        }

        private void LoadPacks()
        {
            this.lst_packs.Items.Clear();
            var pks = _ge.packs;
            foreach (pack p in pks)
            {
                ListViewItem item = new ListViewItem(p.idp.ToString());
                item.SubItems.Add(p.description);
                this.lst_packs.Items.Add(item);
            }
        }

        private void LoadTests(ListView control, bool withblankonly)
        {
            foreach (group testgroup in _ge.groups)
            {
                ListViewGroup lgroup = new ListViewGroup(testgroup.description);
                control.Groups.Add(lgroup);

                testgroup.testsparams.Load();
                IEnumerable<testsparam> tp = testgroup.testsparams;

                if (withblankonly == true)
                {
                    tp = testgroup.testsparams.Where(t => t.blankexists == 1);
                }
                IOrderedEnumerable<testsparam> otp = tp.OrderBy(tst => tst.description);

                foreach (testsparam t in otp)
                {
                    ListViewItem item = new ListViewItem(t.idt.ToString());
                    item.SubItems.Add(t.description);
                    control.Items.Add(item);
                    lgroup.Items.Add(item);
                }

            }
        }



        private void btn_right_Click(object sender, EventArgs e)
        {
            if (lst_all.SelectedItems.Count == 1)//добавление одиночных тестов
            {
                int i = lst_all.SelectedItems[0].Index;
                lst_pooll.Items.Add((ListViewItem)lst_all.SelectedItems[0].Clone());
                lst_all.Items[lst_all.SelectedItems[0].Index].Selected = false;
                //   lst_all.SelectedItems[0].Remove();
                //if (lst_all.Items.Count != 0 & i != 0)
                //{
                //    lst_all.Items[i - 1].Selected = true;
                //}
            }

            //добавление тестов из кортежа
            if (lst_packs.SelectedItems.Count == 1)
            {
                int i = int.Parse(lst_packs.SelectedItems[0].SubItems[0].Text);
                pack pk = _ge.packs.First(p => p.idp == i);
                foreach (packtest pt in pk.packtests)
                {
                    ListViewItem item = new ListViewItem(pt.idtest.ToString());
                    item.SubItems.Add(_ge.testsparams.First(tp => tp.idt == pt.idtest).description);
                    this.lst_pooll.Items.Add(item);
                }
                lst_packs.Items[lst_packs.SelectedItems[0].Index].Selected = false;
            }


        }

        private void btn_left_Click(object sender, EventArgs e)
        {

            if (lst_pooll.SelectedItems.Count == 1)
            {
                int i = lst_pooll.SelectedItems[0].Index;
                //  lst_all.Items.Add((ListViewItem)lst_pooll.SelectedItems[0].Clone());
                lst_pooll.Items.Remove(lst_pooll.SelectedItems[0]);

                if (lst_pooll.Items.Count != 0 & i != 0)
                {
                    lst_pooll.Items[i - 1].Selected = true;
                }
            }

        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            if (lst_pooll.SelectedItems.Count == 1)
            {
                int i = lst_pooll.SelectedItems[0].Index;
                if (lst_pooll.Items.Count != 0 & i != 0)
                {
                    ListViewItem item = (ListViewItem)lst_pooll.SelectedItems[0].Clone();
                    lst_pooll.SelectedItems[0].Remove();
                    lst_pooll.Items.Insert(i - 1, item);
                    lst_pooll.Items[i - 1].Selected = true;
                }
            }
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            if (lst_pooll.SelectedItems.Count == 1)
            {
                int i = lst_pooll.SelectedItems[0].Index;
                if (i + 1 != lst_pooll.Items.Count)
                {
                    ListViewItem item = (ListViewItem)lst_pooll.SelectedItems[0].Clone();
                    lst_pooll.SelectedItems[0].Remove();
                    lst_pooll.Items.Insert(i + 1, item);
                    lst_pooll.Items[i + 1].Selected = true;
                }
            }
        }

        private void cmd_begin_manual_Click(object sender, EventArgs e)
        {
            if (lst_manual.SelectedItems.Count != 0)
            {
                this.Close();
                TestLoader tlk = new TestLoader(_fe);
                tlk.SetHumanID();
                if (tlk.HumanID != 0)
                {
                    RForm rf = new RForm(int.Parse(lst_manual.SelectedItems[0].SubItems[0].Text), tlk.HumanID, _ge, _fe);
                    rf.WindowState = FormWindowState.Maximized;
                    rf.ShowDialog();
                    this.Close();
                }
            }
            else { MessageBox.Show("Необходимо выбрать тест"); }
        }

        private void btn_begin_auto_Click(object sender, EventArgs e)
        {
            if (lst_pooll.Items.Count != 0)
            {
                TestLoader tlk = new TestLoader(_fe);
                tlk.TestsPoolDone += new EventHandler(tlk_TestsPoolDone);
                tlk.SetHumanID();
                foreach (ListViewItem item in lst_pooll.Items)
                {
                    ITest tst = TestFactory.CreateTest((EnumPTests)int.Parse(item.SubItems[0].Text), _ge, _fe, false);
                    tlk.Pool.Add(tst);
                }

                tlk.StartTesting();
                this.Close();
            }
        }

        void tlk_TestsPoolDone(object sender, EventArgs e)
        {
            TestLoader tl = (TestLoader)sender;
            PoolDoneForm pd = new PoolDoneForm(_fe, tl.HumanID);
            pd.ShowDialog();
        }







        private void btn_sten_Click(object sender, EventArgs e)
        {
            if (lst_sten.SelectedItems.Count != 0)
            {
                if (int.Parse(lst_sten.SelectedItems[0].SubItems[0].Text) != (int)EnumPTests.Modul2)
                {
                    this.Close();
                    TestLoader tlk = new TestLoader(_fe);
                    tlk.SetHumanID();
                    if (tlk.HumanID != 0)
                    {
                        StenForm rf = new StenForm(int.Parse(lst_sten.SelectedItems[0].SubItems[0].Text), tlk.HumanID, _ge, _fe);
                        rf.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
                        rf.ShowDialog();
                        this.Close();
                    }
                }
                else { MessageBox.Show("Для теста модуль 2 ввод стенов вручную невозможен. Воспользуйтесь сканированием бланка"); }
            }
            else { MessageBox.Show("Необходимо выбрать тест"); }
        }

        private void lst_all_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            if (lst_packs.SelectedItems.Count == 1) { lst_packs.Items[lst_packs.SelectedItems[0].Index].Selected = false; }
        }

        private void lst_packs_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            if (lst_all.SelectedItems.Count == 1) { lst_all.Items[lst_all.SelectedItems[0].Index].Selected = false; }
        }










    }
}
