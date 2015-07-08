using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Recog.Data;
using Recog.PTests.Kettell;
using System.Xml.Serialization;
using System.IO;
using Recog.PTests.PNN;
using Recog.PTests.FPI;
using Recog.PTests.D;
using Recog.PTests.MD;
using System.Windows.Forms.DataVisualization.Charting;
using Recog.PTests.Contrasts;
using Recog.PTests.Prognoz;
using Recog.PTests.NPNA;
using Recog.PTests.Leongard;
using Recog.PTests.Addictive;
namespace Recog.PTests.ResultReader
{
    public partial class TimeLineForm : Form
    {


        private testresult _testresult;
        public TimeLineForm(testresult TestResult)
        {
            InitializeComponent();
            _testresult = TestResult;

            HelpProvider help = new HelpProvider();
            help.HelpNamespace = "Recog_help.chm";
            help.SetHelpNavigator(this, HelpNavigator.Topic);
            help.SetHelpKeyword(this, "result_character.htm#speed_view");
        }

        private void TimeLineForm_Load(object sender, EventArgs e)
        {
            List<double> tm = new List<double>();
            List<string> aq = new List<string>();
            string _axisXLabel = "X";
            string _axisYLabel = "Y";
            //TODO:похоронить в фабрике
            switch (_testresult.testid)
            {
                case (int)EnumPTests.KettellC://kettell c
                    KettellAnswers kc= GetKettellFromBase();
                    tm.Add(0);
                    aq.Add("");
                    _axisXLabel = "Номер вопроса";
                    _axisYLabel = "Секунды";
                    for (int i = 1; i < kc.Count; i++)
                    {
                        tm.Add(Convert.ToDouble(kc[i].Time.Ticks - kc[i - 1].Time.Ticks) / 100000000);
                        aq.Add(kc[i].AnswerDescription+" // "+kc[i].SelectedCellButtonDescription);
                    }
                        break;
                case (int)EnumPTests.PNN://pnn
                    PNNAnswers pa= GetPNNFromBase();
                     _axisXLabel = "Нажатия";
                    _axisYLabel = "Милисекунды";
                    for (int i = 0; i < pa.Count; i++)
                    {
                        tm.Add(pa[i].Exposition);
                        aq.Add(pa[i].Signal.ToString() + " // " + pa[i].Answer.ToString());
                    }
                    break;
                case (int)EnumPTests.Adaptability://adaptability
                   DAnswers da= GetDFromBase();
                    tm.Add(0);
                    aq.Add("");
                     _axisXLabel = "Номер вопроса";
                    _axisYLabel = "Секунды";
                    for (int i = 1; i < da.Count; i++)
                    {
                        tm.Add(Convert.ToDouble(da[i].Time.Ticks - da[i - 1].Time.Ticks) / 100000000);
                        aq.Add(da[i].AnswerDescription + " // " + da[i].SelectedCellButtonDescription);
                    }
                    break;
                case (int)EnumPTests.FPI://fpi
                   FPIAnswers fa= GetFPIFromBase();
                    tm.Add(0);
                    aq.Add("");
                     _axisXLabel = "Номер вопроса";
                    _axisYLabel = "Секунды";
                    for (int i = 1; i < fa.Count; i++)
                    {
                        tm.Add(Convert.ToDouble(fa[i].Time.Ticks - fa[i - 1].Time.Ticks) / 100000000);
                        aq.Add(fa[i].AnswerDescription + " // " + fa[i].SelectedCellButtonDescription);
                    }
                    break;
                case (int)EnumPTests.KettellA://kettell a
                   KettellAnswers ka= GetKettellFromBase();
                    tm.Add(0);
                    aq.Add("");
                     _axisXLabel = "Номер вопроса";
                    _axisYLabel = "Секунды";
                    for (int i = 1; i < ka.Count; i++)
                    {
                        tm.Add(Convert.ToDouble(ka[i].Time.Ticks - ka[i - 1].Time.Ticks) / 100000000);
                        aq.Add(ka[i].AnswerDescription + " // " + ka[i].SelectedCellButtonDescription);
                    }
                    break;
                case (int)EnumPTests.Modul2://modul
                    MDAnswers mda = GetMDFromBase();
                    tm.Add(0);
                    aq.Add("");
                     _axisXLabel = "Номер вопроса";
                    _axisYLabel = "Секунды";
                    for (int i = 1; i < mda.Count; i++)
                    {
                        tm.Add(Convert.ToDouble(mda[i].Time.Ticks - mda[i - 1].Time.Ticks) / 100000000);
                        aq.Add(mda[i].AnswerDescription + " // " + mda[i].SelectedCellButtonDescription);
                    }
                    break;
                case (int)EnumPTests.Contrasts://контрасты
                    ContrastsAnswers ca = GetContrastsFromBase();
                    _axisXLabel = "Номер изображения";
                    _axisYLabel = "Секунды";
                    tm.Add(Convert.ToDouble(0));
                    aq.Add("1");
                    for (int i = 1; i < ca.Count; i++)
                    {
                        tm.Add(Convert.ToDouble(ca[i].Time.Ticks - ca[i - 1].Time.Ticks) / 100000000);
                        aq.Add(ca[i].PictureId.ToString() );
                    }
                    break;
                case (int)EnumPTests.Prognoz:
                    PAnswers pda = GetPFromBase();
                    tm.Add(0);
                    aq.Add("");
                    _axisXLabel = "Номер вопроса";
                    _axisYLabel = "Секунды";
                    for (int i = 1; i < pda.Count; i++)
                    {
                        tm.Add(Convert.ToDouble(pda[i].Time.Ticks - pda[i - 1].Time.Ticks) / 100000000);
                        aq.Add(pda[i].AnswerDescription + " // " + pda[i].SelectedCellButtonDescription);
                    }
                    break;
                case (int)EnumPTests.NPNA:
                    NPNAnswers nda = GetNPNFromBase();
                    tm.Add(0);
                    aq.Add("");
                    _axisXLabel = "Номер вопроса";
                    _axisYLabel = "Секунды";
                    for (int i = 1; i <nda.Count; i++)
                    {
                        tm.Add(Convert.ToDouble(nda[i].Time.Ticks - nda[i - 1].Time.Ticks) / 100000000);
                        aq.Add(nda[i].AnswerDescription + " // " + nda[i].SelectedCellButtonDescription);
                    }
                    break;
                case (int)EnumPTests.Leongard:
                    LAnswers lda = GetLFromBase();
                    tm.Add(0);
                    aq.Add("");
                    _axisXLabel = "Номер вопроса";
                    _axisYLabel = "Секунды";
                    for (int i = 1; i < lda.Count; i++)
                    {
                        tm.Add(Convert.ToDouble(lda[i].Time.Ticks - lda[i - 1].Time.Ticks) / 100000000);
                        aq.Add(lda[i].AnswerDescription + " // " + lda[i].SelectedCellButtonDescription);
                    }
                    break;
                case (int)EnumPTests.Addictive:
                    AAnswers ada = GetAFromBase();
                    tm.Add(0);
                    aq.Add("");
                    _axisXLabel = "Номер вопроса";
                    _axisYLabel = "Секунды";
                    for (int i = 1; i < ada.Count; i++)
                    {
                        tm.Add(Convert.ToDouble(ada[i].Time.Ticks - ada[i - 1].Time.Ticks) / 100000000);
                        aq.Add(ada[i].AnswerDescription + " // " + ada[i].SelectedCellButtonDescription);
                    }
                    break;
            }
            Series s=new Series("timeline",tm.Count-1);
            s.MarkerStyle = MarkerStyle.Cross;
            s.MarkerSize = 12;
            s.ChartType=SeriesChartType.Line;
            s.YValueType = ChartValueType.Double;
            chart_timeline.Legends.Remove(chart_timeline.Legends[0]);
            chart_timeline.ChartAreas[0].AxisX.Minimum = 1;
            
            for (int i = 0; i < tm.Count; i++)
            {
                s.Points.AddXY(i+1,tm[i]);

                s.Points[i].ToolTip = aq[i] ;
                
            }
            chart_timeline.ChartAreas[0].AxisY.Title = _axisYLabel;
            chart_timeline.ChartAreas[0].AxisX.Title = _axisXLabel;
            chart_timeline.Series.Add(s);
         

        }



        private KettellAnswers GetKettellFromBase()
        {
            KettellAnswers _answersfrombase;
            XmlSerializer mySerializer = new XmlSerializer(typeof(KettellAnswers));
            StringReader sr = new StringReader(_testresult.teststream);
            _answersfrombase = (KettellAnswers)mySerializer.Deserialize(sr);
            return _answersfrombase;
        }
        private PNNAnswers GetPNNFromBase()
        {
            PNNAnswers _answersfrombase;
            XmlSerializer mySerializer = new XmlSerializer(typeof(PNNAnswers));
            StringReader sr = new StringReader(_testresult.teststream);
            _answersfrombase = (PNNAnswers)mySerializer.Deserialize(sr);
            return _answersfrombase;
        }
        private FPIAnswers GetFPIFromBase()
        {
            FPIAnswers _answersfrombase;
            XmlSerializer mySerializer = new XmlSerializer(typeof(FPIAnswers));
            StringReader sr = new StringReader(_testresult.teststream);
            _answersfrombase = (FPIAnswers)mySerializer.Deserialize(sr);
            return _answersfrombase;

        }

        private DAnswers GetDFromBase()
        {
            DAnswers _answersfrombase;
            XmlSerializer mySerializer = new XmlSerializer(typeof(DAnswers));
            StringReader sr = new StringReader(_testresult.teststream);
            _answersfrombase = (DAnswers)mySerializer.Deserialize(sr);
            return _answersfrombase;

        }

        private MDAnswers GetMDFromBase()
        {
            MDAnswers _answersfrombase;
            XmlSerializer mySerializer = new XmlSerializer(typeof(MDAnswers));
            StringReader sr = new StringReader(_testresult.teststream);
            _answersfrombase = (MDAnswers)mySerializer.Deserialize(sr);
            return _answersfrombase;

        }

        private PAnswers GetPFromBase()
        {
            PAnswers _answersfrombase;
            XmlSerializer mySerializer = new XmlSerializer(typeof(PAnswers));
            StringReader sr = new StringReader(_testresult.teststream);
            _answersfrombase = (PAnswers)mySerializer.Deserialize(sr);
            return _answersfrombase;

        }
        private NPNAnswers GetNPNFromBase()
        {
            NPNAnswers _answersfrombase;
            XmlSerializer mySerializer = new XmlSerializer(typeof(NPNAnswers));
            StringReader sr = new StringReader(_testresult.teststream);
            _answersfrombase = (NPNAnswers)mySerializer.Deserialize(sr);
            return _answersfrombase;

        }
        private LAnswers GetLFromBase()
        {
            LAnswers _answersfrombase;
            XmlSerializer mySerializer = new XmlSerializer(typeof(LAnswers));
            StringReader sr = new StringReader(_testresult.teststream);
            _answersfrombase = (LAnswers)mySerializer.Deserialize(sr);
            return _answersfrombase;

        }
        private ContrastsAnswers GetContrastsFromBase()
        {
            ContrastsAnswers _answersfrombase;
            XmlSerializer mySerializer = new XmlSerializer(typeof(ContrastsAnswers));
            StringReader sr = new StringReader(_testresult.teststream);
            _answersfrombase = (ContrastsAnswers)mySerializer.Deserialize(sr);
            return _answersfrombase;

        }
        private AAnswers GetAFromBase()
        {
            AAnswers _answersfrombase;
            XmlSerializer mySerializer = new XmlSerializer(typeof(AAnswers));
            StringReader sr = new StringReader(_testresult.teststream);
            _answersfrombase = (AAnswers)mySerializer.Deserialize(sr);
            return _answersfrombase;

        }
      
    }
}
