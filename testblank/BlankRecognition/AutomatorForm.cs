using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Recog.PTests.References;
using Recog.PTests;
using Recog.Data;
namespace Recog.BlankRecognition
{
    public partial class AutomatorForm : Form
    {
        private pBaseEntities _ge;
        private fBaseEntities _fe;
        public AutomatorForm(pBaseEntities ge, fBaseEntities fe)
        {
            InitializeComponent();
            _ge = ge;
            _fe = fe;
            this.FillListRefs();
            HelpProvider help = new HelpProvider();
            help.HelpNamespace = "Recog_help.chm";
            help.SetHelpNavigator(this, HelpNavigator.Topic);
            help.SetHelpKeyword(this, "scan_wizard.htm");
        }

        private void FillListRefs()
        {
            this.lst_references.Columns[1].Width = this.lst_references.Width;
            this.lst_params.Columns[1].Width = this.lst_params.Width;
            var tp = _ge.testsparams.Where(t => t.blankexists == 1);

            foreach (testsparam t in tp)
            {
                ListViewItem item = new ListViewItem(t.idt.ToString());
                item.SubItems.Add(t.description);
                this.lst_references.Items.Add(item);

            }

        }
        private void FillParams(EnumPTests selectedtest)
        {

            switch (selectedtest)
            {
                case EnumPTests.KettellC:
                    ListViewItem item0 = new ListViewItem(Convert.ToString((int)EnumPReferences.KettellC));
                    item0.SubItems.Add(ReferenceFactory.ReferenceDict.First(refer => refer.Key == EnumPReferences.KettellC).Value);
                    this.lst_params.Items.Add(item0);
                    ListViewItem item01 = new ListViewItem(Convert.ToString((int)EnumPReferences.Integrative));
                    item01.SubItems.Add(ReferenceFactory.ReferenceDict.First(refer => refer.Key == EnumPReferences.Integrative).Value);
                    this.lst_params.Items.Add(item01);
                    break;
                case EnumPTests.Adaptability:
                    ListViewItem item02 = new ListViewItem(Convert.ToString((int)EnumPReferences.Adaptability));
                    item02.SubItems.Add(ReferenceFactory.ReferenceDict.First(refer => refer.Key == EnumPReferences.Adaptability).Value);
                    this.lst_params.Items.Add(item02);
                    break;
                case EnumPTests.FPI:
                    ListViewItem item03 = new ListViewItem(Convert.ToString((int)EnumPReferences.FPI));
                    item03.SubItems.Add(ReferenceFactory.ReferenceDict.First(refer => refer.Key == EnumPReferences.FPI).Value);
                    this.lst_params.Items.Add(item03);
                    break;
                case EnumPTests.KettellA:
                    ListViewItem item04 = new ListViewItem(Convert.ToString((int)EnumPReferences.KettellA));
                    item04.SubItems.Add(ReferenceFactory.ReferenceDict.First(refer => refer.Key == EnumPReferences.KettellA).Value);
                    this.lst_params.Items.Add(item04);
                    break;
                case EnumPTests.Modul2:
                    ListViewItem item05 = new ListViewItem(Convert.ToString((int)EnumPReferences.Modul));
                    item05.SubItems.Add(ReferenceFactory.ReferenceDict.First(refer => refer.Key == EnumPReferences.Modul).Value);
                    this.lst_params.Items.Add(item05);
                    break;
                case EnumPTests.NPNA:
                    ListViewItem item06 = new ListViewItem(Convert.ToString((int)EnumPReferences.NPNA));
                    item06.SubItems.Add(ReferenceFactory.ReferenceDict.First(refer => refer.Key == EnumPReferences.NPNA).Value);
                    this.lst_params.Items.Add(item06);
                    break;
                case EnumPTests.Prognoz:
                    ListViewItem item07 = new ListViewItem(Convert.ToString((int)EnumPReferences.Prognoz));
                    item07.SubItems.Add(ReferenceFactory.ReferenceDict.First(refer => refer.Key == EnumPReferences.Prognoz).Value);
                    this.lst_params.Items.Add(item07);
                    break;
                case EnumPTests.Addictive:
                    ListViewItem item08 = new ListViewItem(Convert.ToString((int)EnumPReferences.Addictive));
                    item08.SubItems.Add(ReferenceFactory.ReferenceDict.First(refer => refer.Key == EnumPReferences.Addictive).Value);
                    this.lst_params.Items.Add(item08);
                    break;
                case EnumPTests.Leongard:
                    ListViewItem item09 = new ListViewItem(Convert.ToString((int)EnumPReferences.Leongard));
                    item09.SubItems.Add(ReferenceFactory.ReferenceDict.First(refer => refer.Key == EnumPReferences.Leongard).Value);
                    this.lst_params.Items.Add(item09);
                    break;

            }
            ListViewItem item = new ListViewItem("-2");
            item.SubItems.Add("ПЕЧАТАТЬ ТОЛЬКО РЕЗУЛЬТАТЫ ТЕСТА БЕЗ ХАРАКТЕРИСТИКИ");
            this.lst_params.Items.Add(item);
            ListViewItem item1 = new ListViewItem("-1");
            item1.SubItems.Add("НИЧЕГО НЕ ПЕЧАТАТЬ, ТОЛЬКО СОХРАНЯТЬ В БАЗУ");
            this.lst_params.Items.Add(item1);

        }



        private void lst_references_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.lst_params.Items.Clear();
            this.FillParams((EnumPTests)int.Parse(e.Item.SubItems[0].Text));
        }

        private void StartWork()
        {
            if (lst_params.SelectedItems.Count != 0)
            {
                int param = int.Parse(this.lst_params.SelectedItems[0].SubItems[0].Text);
                bool haveprinting = true;
                EnumPTests test = (EnumPTests)int.Parse(this.lst_references.SelectedItems[0].SubItems[0].Text);
                EnumPReferences reference = EnumPReferences.NoReference;
                switch (param)
                {
                    case -2:
                        reference = EnumPReferences.NoReference;
                        break;
                    case -1:
                        haveprinting=false;
                        break;
                    default:
                        reference = (EnumPReferences)param;
                        break;
                }
                RecogAutomator automator = new RecogAutomator(test, _ge, _fe, reference, haveprinting);
                automator.Start();
            }
            else { MessageBox.Show("Необходимо выбрать параметр печати и тест"); }
            
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            this.Close();
            this.StartWork();
           
        }
    }
}
