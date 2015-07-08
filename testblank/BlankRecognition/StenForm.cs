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
using Recog.Controls;
using System.Xml.Serialization;
using System.IO;
using DW.RtfWriter;
using System.Diagnostics;
using Recog.PTests.PNN;
using Recog.PTests.D;
using Recog.PTests.FPI;
using Recog.PTests.MD;
using Recog.PTests.Prognoz;
using Recog.PTests;
using Recog.PTests.Addictive;
using Recog.PTests.Contrasts;
using Recog.PTests.NPNA;
using Recog.PTests.Leongard;

namespace Recog.BlankRecognition
{
    public partial class StenForm : Form
    {
        private pBaseEntities _ge;
        private fBaseEntities _fe;
        private int _humanid;
        private int _testid;
        private testsparam _tp;
        private RtfDocument doc;
        private human _human;
        public StenForm(int testid, int humanid, pBaseEntities ge, fBaseEntities fe)
        {
            InitializeComponent();
            _ge = ge;
            _fe = fe;
            _humanid = humanid;
            _testid = testid;

            HelpProvider help = new HelpProvider();
            help.HelpNamespace = "Recog_help.chm";
            help.SetHelpNavigator(this, HelpNavigator.Topic);
            help.SetHelpKeyword(this, "test_sten.htm");
        }

        private void Loading()
        {
            _tp = _ge.testsparams.First(t => t.idt == _testid);
              switch (_testid)
            {
                case (int)EnumPTests.KettellC://TODO:это все поместить в фабрику отчетов с функцие добавления пустых ответов
                    //create fool kettellanswers
                    KettellAnswers ka = new KettellAnswers();
                    for (int a = 0; a < 104; a++)
                    {
                        ka.Add(0, "", "", a, "");
                    }
                    XmlSerializer mySerializer = new XmlSerializer(typeof(KettellAnswers));
                    StringWriter myWriter = new StringWriter();
                    mySerializer.Serialize(myWriter, ka);
                    _human=_fe.humans.First(h => h.idh == _humanid);
                    KettellCTestReport kcr = new KettellCTestReport(_human, testresult.Createtestresult(0, _humanid, DateTime.Now, (int)EnumPTests.KettellC, myWriter.ToString(), "manual"), _ge, _fe, true);
                    for (int i = 0; i < kcr.ListScales.Count(); i++)
                    {
                        ScaleControl sc = new ScaleControl();
                        this.flp_parent.Controls.Add(sc);
                        sc.ControlScale = kcr.ListScales[i];
                    }
                    break;
                case (int)EnumPTests.PNN:
                    PNNAnswers pa = new PNNAnswers();
                    for (int a = 0; a < 104; a++)
                    {
                       pa.Add(PnnSignalType.Green,PnnKeyType.AnyKey,DateTime.Now,0);
                    }
                    XmlSerializer mySerializerp = new XmlSerializer(typeof(PNNAnswers));
                    StringWriter myWriterp = new StringWriter();
                    mySerializerp.Serialize(myWriterp, pa);
                    _human=_fe.humans.First(h => h.idh == _humanid);
                    PNNTestReport pnr = new PNNTestReport(_human, testresult.Createtestresult(0, _humanid, DateTime.Now, (int)EnumPTests.PNN, myWriterp.ToString(), "manual"), _ge, _fe);
                    for (int i = 0; i < pnr.ListScales.Count(); i++)
                    {
                        ScaleControl sc = new ScaleControl();
                        this.flp_parent.Controls.Add(sc);
                        sc.ControlScale = pnr.ListScales[i];
                    }
                    break;
                case (int)EnumPTests.Adaptability:
                     DAnswers kd = new DAnswers();
                    for (int a = 0; a < 165; a++)
                    {
                        kd.Add(0, "", "", a, "");
                    }
                    XmlSerializer mySerializerd = new XmlSerializer(typeof(DAnswers));
                    StringWriter myWriterd = new StringWriter();
                    mySerializerd.Serialize(myWriterd, kd);
                    _human=_fe.humans.First(h => h.idh == _humanid);
                    DTestReport kdr = new DTestReport(_human, testresult.Createtestresult(0, _humanid, DateTime.Now, (int)EnumPTests.Adaptability, myWriterd.ToString(), "manual"), _ge, _fe, true);
                    for (int i = 0; i < kdr.ListScales.Count(); i++)
                    {
                        ScaleControl sc = new ScaleControl();
                        this.flp_parent.Controls.Add(sc);
                        sc.ControlScale = kdr.ListScales[i];
                    }
                    break;
                case (int)EnumPTests.FPI:
                     FPIAnswers kfpi= new FPIAnswers();
                    for (int a = 0; a < 114; a++)
                    {
                        kfpi.Add(0, "", "", a, "");
                    }
                    XmlSerializer mySerializerfpi = new XmlSerializer(typeof(FPIAnswers));
                    StringWriter myWriterfpi = new StringWriter();
                    mySerializerfpi.Serialize(myWriterfpi, kfpi);
                    _human=_fe.humans.First(h => h.idh == _humanid);
                    FPITestReport kfr = new FPITestReport(_human, testresult.Createtestresult(0, _humanid, DateTime.Now, (int)EnumPTests.FPI, myWriterfpi.ToString(), "manual"), _ge, _fe, true);
                    for (int i = 0; i < kfr.ListScales.Count(); i++)
                    {
                        ScaleControl sc = new ScaleControl();
                        this.flp_parent.Controls.Add(sc);
                        sc.ControlScale = kfr.ListScales[i];
                    }
                    break;
                case (int)EnumPTests.KettellA:
                     KettellAnswers kaa = new KettellAnswers();
                    for (int a = 0; a < 185; a++)
                    {
                        kaa.Add(0, "", "", a, "");
                    }
                    XmlSerializer mySerializera = new XmlSerializer(typeof(KettellAnswers));
                    StringWriter myWritera = new StringWriter();
                    mySerializera.Serialize(myWritera, kaa);
                    _human=_fe.humans.First(h => h.idh == _humanid);
                    KettellATestReport kar = new KettellATestReport(_human, testresult.Createtestresult(0, _humanid, DateTime.Now, (int)EnumPTests.KettellA, myWritera.ToString(), "manual"), _ge, _fe, true);
                    for (int i = 0; i < kar.ListScales.Count(); i++)
                    {
                        ScaleControl sc = new ScaleControl();
                        this.flp_parent.Controls.Add(sc);
                        sc.ControlScale = kar.ListScales[i];
                    }
                    break;
                  case (int)EnumPTests.Contrasts:
                    ContrastsAnswers mkd = new ContrastsAnswers();
                    for (int a = 0; a < 6; a++)
                    {
                        mkd.Add(DateTime.Now, 0);
                    }
                    XmlSerializer mySerializermd = new XmlSerializer(typeof(ContrastsAnswers));
                    StringWriter myWritermd = new StringWriter();
                    mySerializermd.Serialize(myWritermd, mkd);
                    _human = _fe.humans.First(h => h.idh == _humanid);
                    ContrastsTestReport mkdr = new ContrastsTestReport(_human, testresult.Createtestresult(0, _humanid, DateTime.Now, (int)EnumPTests.Contrasts, myWritermd.ToString(), "manual"), _ge, _fe);
                    for (int i = 0; i < mkdr.ListScales.Count(); i++)
                    {
                        ScaleControl sc = new ScaleControl();
                        this.flp_parent.Controls.Add(sc);
                        sc.ControlScale = mkdr.ListScales[i];
                    }
                    break;
                  case (int)EnumPTests.Prognoz:
                    PAnswers paa = new PAnswers();
                    for (int a = 0; a < 86; a++)
                    {
                        paa.Add(0, "", "", a, "");
                    }
                    XmlSerializer mySerializerpr = new XmlSerializer(typeof(PAnswers));
                    StringWriter myWriterpr = new StringWriter();
                    mySerializerpr.Serialize(myWriterpr, paa);
                    _human = _fe.humans.First(h => h.idh == _humanid);
                   PTestReport par = new PTestReport(_human, testresult.Createtestresult(0, _humanid, DateTime.Now, (int)EnumPTests.Prognoz, myWriterpr.ToString(), "manual"), _ge, _fe, true);
                    for (int i = 0; i < par.ListScales.Count(); i++)
                    {
                        ScaleControl sc = new ScaleControl();
                        this.flp_parent.Controls.Add(sc);
                        sc.ControlScale = par.ListScales[i];
                    }
                    break;
                       case (int)EnumPTests.Addictive:
                    AAnswers aaa = new AAnswers();
                    for (int a = 0; a < 30; a++)
                    {
                        aaa.Add(0, "", "", a, "");
                    }
                    XmlSerializer mySerializeraa = new XmlSerializer(typeof(AAnswers));
                    StringWriter myWriteraa = new StringWriter();
                    mySerializeraa.Serialize(myWriteraa, aaa);
                    _human = _fe.humans.First(h => h.idh == _humanid);
                   ATestReport aar = new ATestReport(_human, testresult.Createtestresult(0, _humanid, DateTime.Now, (int)EnumPTests.Addictive, myWriteraa.ToString(), "manual"), _ge, _fe, true);
                    for (int i = 0; i < aar.ListScales.Count(); i++)
                    {
                        ScaleControl sc = new ScaleControl();
                        this.flp_parent.Controls.Add(sc);
                        sc.ControlScale = aar.ListScales[i];
                    }
                    break;
                       case (int)EnumPTests.NPNA:
                    NPNAnswers npn = new NPNAnswers();
                    for (int a = 0; a < 276; a++)
                    {
                        npn.Add(0, "", "", a, "");
                    }
                    XmlSerializer mySerializernpn = new XmlSerializer(typeof(NPNAnswers));
                    StringWriter myWriternpn = new StringWriter();
                    mySerializernpn.Serialize(myWriternpn, npn);
                    _human = _fe.humans.First(h => h.idh == _humanid);
                    NPNTestReport npnr = new NPNTestReport(_human, testresult.Createtestresult(0, _humanid, DateTime.Now, (int)EnumPTests.NPNA, myWriternpn.ToString(), "manual"), _ge, _fe, true);
                    for (int i = 0; i < npnr.ListScales.Count(); i++)
                    {
                        ScaleControl sc = new ScaleControl();
                        this.flp_parent.Controls.Add(sc);
                        sc.ControlScale = npnr.ListScales[i];
                    }
                    break;
                       case (int)EnumPTests.Leongard:
                    LAnswers lpn = new LAnswers();
                    for (int a = 0; a < 88; a++)
                    {
                        lpn.Add(0, "", "", a, "");
                    }
                    XmlSerializer mySerializerlpn = new XmlSerializer(typeof(LAnswers));
                    StringWriter myWriterlpn = new StringWriter();
                    mySerializerlpn.Serialize(myWriterlpn, lpn);
                    _human = _fe.humans.First(h => h.idh == _humanid);
                    LTestReport lpnr = new LTestReport(_human, testresult.Createtestresult(0, _humanid, DateTime.Now, (int)EnumPTests.Leongard, myWriterlpn.ToString(), "manual"), _ge, _fe, true);
                    for (int i = 0; i < lpnr.ListScales.Count(); i++)
                    {
                        ScaleControl sc = new ScaleControl();
                        this.flp_parent.Controls.Add(sc);
                        sc.ControlScale =lpnr.ListScales[i];
                    }
                    break;
            }
            
        }

      
        private void StenForm_Shown(object sender, EventArgs e)
        {
            this.Loading();
        }

        private void Print()
        {
            doc = new RtfDocument(PaperSize.A4, PaperOrientation.Portrait, Lcid.English);
            doc.Margins[Direction.Top] = 30;
            doc.Margins[Direction.Bottom] = 30;
            doc.Margins[Direction.Left] = 50;
            doc.Margins[Direction.Right] = 30;
            this.TypeParagraph(14, Align.Center, "Характеристика на основе стенов или баллов");
            this.TypeParagraph(14, Align.Center, _tp.description);
            this.TypeParagraph(12, Align.Left, "");
            this.TypeParagraph(12, Align.Left, "");
            this.TypeParagraph(12, Align.Left, "Дата составления: " + DateTime.Now.ToString());
            this.TypeParagraph(12, Align.Left, "ФИО: " + _human.secondname.ToString() + " " + _human.firstname.ToString() + " " + _human.lastname.ToString());
            this.TypeParagraph(12, Align.Left, "Дата рождения: " + _human.birthday.Value.Date.ToLongDateString() + " (" + ((DateTime.Now.Date - _human.birthday.Value.Date).Days / 365) + ")");
            this.TypeParagraph(12, Align.Left, "Пол: " + _fe.gensers.First(g => g.idg == _human.genderid).description);
            this.TypeParagraph(12, Align.Left, "Образование: " + _fe.educations.First(e => e.ide == _human.educationid).description);
            this.TypeParagraph(12, Align.Left, "Подразделение: " + _fe.departments.First(d => d.idd == _human.departmentid).description);
            this.TypeParagraph(12, Align.Left, "");


            foreach( Control c in flp_parent.Controls )
            {
               
           Recog.Controls.ScaleControl sc=(Recog.Controls.ScaleControl)c;
           if (sc.IsActive == true)
           {
               this.TypeParagraph(10, Align.Center, sc.ControlScale.Name);
               this.TypeParagraph(10, Align.Center, "(" +  sc.ControlScale.Description + "):");
               this.TypeParagraph(10, Align.Left, "Баллы: " + sc.ControlScale.Mark + " [Стены: " + sc.ControlScale.Stens + "]" + " {Уровень: " + sc.ControlScale.Level + "}");
               this.TypeParagraph(10, Align.FullyJustify, "Оценка: " + sc.ControlScale.ResultDescription); 
           }
            }

            string filename = _human.secondname.ToString() + "_" + _human.firstname.ToString() + "_" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_КеттеллС.rtf";
            doc.save(filename);
            var p = new Process { StartInfo = { FileName = filename } };
            p.Start();
        }

        private void TypeParagraph(int fontsize, Align align, string text)
        {
            FontDescriptor times = doc.createFont("Times New Roman");
            RtfCharFormat fmt;
            RtfParagraph par;

            par = doc.addParagraph();
            par.Alignment = align;
            fmt = par.addCharFormat();
            fmt.Font = times;
            fmt.FontSize = fontsize;
            par.setText(text);
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            this.Print();
        }

        private void flp_parent_MouseEnter(object sender, EventArgs e)
        {
            flp_parent.Focus();
        }

    }
}
