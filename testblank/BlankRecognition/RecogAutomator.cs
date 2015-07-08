using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.PTests;
using Recog.PTests.References;
using Recog.Data;
using System.Windows.Forms;

namespace Recog.BlankRecognition
{
    public class RecogAutomator
    {
        private RForm _recogform = null;
        private EnumPTests _test;
        private EnumPReferences _reference;
        private int _humanid=0;
        private  pBaseEntities _ge;
        private fBaseEntities _fe;
        private testresult _testresult = null;
        private bool _printing=false;
        public RecogAutomator(EnumPTests test, pBaseEntities ge,fBaseEntities fe, EnumPReferences reference=EnumPReferences.NoReference,bool printing=true )
        {
            _test = test;
            _reference = reference;
            _fe = fe;
            _ge = ge;
            _printing = printing;
        }

        public void Start()
        {
            this.OpenForm();
        }

        private void OpenForm()
        {
            TestLoader tlk = new TestLoader(_fe);
            tlk.SetHumanID();
            _humanid = tlk.HumanID;
            if (_humanid!= 0)
            {
                _recogform = new RForm((int)_test, _humanid, _ge, _fe);
                _recogform.WindowState = FormWindowState.Maximized;
                _recogform.btn_addtobase.Click += new EventHandler(btn_addtobase_Click);
                _recogform.Show();
                
            }
        }

        void btn_addtobase_Click(object sender, EventArgs e)
        {
            _testresult = _recogform.TestResult;
            if (_printing == true) { this.PrintReference(); }
            this.Start();

        }
        private void PrintReference()
        {
             human _human= _fe.humans.FirstOrDefault(id=>id.idh==_humanid);
            if (_reference != EnumPReferences.NoReference)
            {
                ReferenceFactory refsfactory= new ReferenceFactory(_human, _ge, _fe);
                try
                {
                    refsfactory.GetReference(new List<int> { _testresult.idtr }, _reference).Print(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try{
                ReportFactory.CreateReport(_test, _human, _testresult, _ge, _fe, false).Print(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
