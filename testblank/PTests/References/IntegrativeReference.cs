using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.PTests.Kettell;
using Recog.DocPrinter;
using DW.RtfWriter;
using System.Diagnostics;
using Recog.Data;
namespace Recog.PTests.References
{

    public class IntegrativeReference : RtfPrinter, IReference
    {

        private KettellCTestReport _kettellreport;
        private fBaseEntities _fe;

        private IScale _ScaleMD;
        private IScale _ScaleA;
        private IScale _ScaleB;
        private IScale _ScaleC;
        private IScale _ScaleE;
        private IScale _ScaleF;
        private IScale _ScaleG;
        private IScale _ScaleH;
        private IScale _ScaleI;
        private IScale _ScaleL;
        private IScale _ScaleM;
        private IScale _ScaleN;
        private IScale _ScaleO;
        private IScale _ScaleQ1;
        private IScale _ScaleQ2;
        private IScale _ScaleQ3;
        private IScale _ScaleQ4;

        public EnumPReferences ID
        {
            get { return EnumPReferences.Integrative; }
        }
        public IntegrativeReference(ITestReport KettellC, fBaseEntities fe)
        {
            _fe = fe;
            _kettellreport = (KettellCTestReport)KettellC;

            _ScaleMD = _kettellreport.ListScales[0];
            _ScaleA = _kettellreport.ListScales[1];
            _ScaleB = _kettellreport.ListScales[2];
            _ScaleC = _kettellreport.ListScales[3];
            _ScaleE = _kettellreport.ListScales[4];
            _ScaleF = _kettellreport.ListScales[5];
            _ScaleG = _kettellreport.ListScales[6];
            _ScaleH = _kettellreport.ListScales[7];
            _ScaleI = _kettellreport.ListScales[8];
            _ScaleL = _kettellreport.ListScales[9];
            _ScaleM = _kettellreport.ListScales[10];
            _ScaleN = _kettellreport.ListScales[11];
            _ScaleO = _kettellreport.ListScales[12];
            _ScaleQ1 = _kettellreport.ListScales[13];
            _ScaleQ2 = _kettellreport.ListScales[14];
            _ScaleQ3 = _kettellreport.ListScales[15];
            _ScaleQ4 = _kettellreport.ListScales[16];
        }

        public string Name
        {
            get { return "ИНТЕГРАЛЬНАЯ ХАРАКТЕРИСТИКА НА ОСНОВЕ МЕТОДИКИ КЕТТЕЛЛ С"; }
        }

        public void Save(string Filename)
        {
            throw new NotImplementedException();
        }

        public void Print(bool WaitForExit = false)
        {
            base.SplashShow();
            human _human = _kettellreport.Human;
            string filename = _kettellreport.Human.secondname.ToString() + "_" + 
                _kettellreport.Human.firstname.ToString() + "_" + _kettellreport.TestResult.testdate.Date.ToShortDateString() + 
                "_" + _kettellreport.TestResult.testdate.Hour.ToString() + "_" +
                _kettellreport.TestResult.testdate.Minute.ToString() +GetHashCode().ToString()+ "_ИнтКеттеллС.rtf";
            base.CreateDoc(filename);
            //header
            base.TypeParagraph(14, Align.Center, this.Name);
            base.TypeParagraph(12, Align.Left, "");
            base.TypeParagraph(12, Align.Left, "Дата проведения теста: " + _kettellreport.TestResult.testdate.ToString());
            base.TypeParagraph(12, Align.Left, "ФИО: " + _human.secondname.ToString() + " " + _human.firstname.ToString() + " " + _human.lastname.ToString());
            base.TypeParagraph(12, Align.Left, "Дата рождения: " + _human.birthday.Value.Date.ToLongDateString() + " (" + ((_kettellreport.TestResult.testdate.Date - _human.birthday.Value.Date).Days / 365) + ")");
            base.TypeParagraph(12, Align.Left, "Пол: " + _fe.gensers.First(g => g.idg == _human.genderid).description);
            base.TypeParagraph(12, Align.Left, "Образование: " + _fe.educations.First(e => e.ide == _human.educationid).description);
            base.TypeParagraph(12, Align.Left, "Подразделение: " + _fe.departments.First(d => d.idd == _human.departmentid).description);
            if (_human.additinfo.Length != 0)
            {
                base.TypeParagraph(12, Align.Left, "Дополнительная информация: " + _human.additinfo);
            }
            base.TypeParagraph(12, Align.Left, "");
            //body

            for (int scaleindex = 0; scaleindex < _kettellreport.ListScales.Count;scaleindex++ )
            {
                _kettellreport.ListScales[scaleindex].GetMark();
                base.TypeParagraph(10, Align.FullyJustify,  _kettellreport.ListScales[scaleindex].Name +" (" + _kettellreport.ListScales[scaleindex].Description + "): Баллы: " + _kettellreport.ListScales[scaleindex].Mark + " [Стены: " + _kettellreport.ListScales[scaleindex].Stens + "]" + " {Уровень: " + _kettellreport.ListScales[scaleindex].Level + "}");
            }

            base.TypeParagraph(10, Align.Center, "");
            base.TypeParagraph(10, Align.Center, "");
                base.TypeParagraph(10, Align.Center, "1.1 Социально-психологические особенности: экстраверсия - интраверсия");
            if (ScaleChecker.MarkInRange(_ScaleA, 0, 6) & ScaleChecker.MarkInRange(_ScaleF, 0, 5) & ScaleChecker.MarkInRange(_ScaleH, 0, 6))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Сдержанность в межличностных контактах, трудности в непосредственном и социальном общении, склонность к индивидуальной работе, замкнутость, направленность на свой внутренний мир. Интроверсия.");
            }
            if (ScaleChecker.MarkInRange(_ScaleA, 0, 6) & ScaleChecker.MarkInRange(_ScaleF, 6, 12) & ScaleChecker.MarkInRange(_ScaleH, 0, 6))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Сдержанность в установлении как межличностных, так и социальных контактов. В поведении - экспрессивность, импульсивность; в характере проявляются застенчивость и внешняя активность, склонность к индивидуальной деятельности. Склонность к интроверсии.");
            }
            if (ScaleChecker.MarkInRange(_ScaleA, 7, 12) & ScaleChecker.MarkInRange(_ScaleF, 0, 5) & ScaleChecker.MarkInRange(_ScaleH, 0, 6))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Открытость в межличностных контактах, способность к непосредственному общению, сдержанность и рассудительность в установлении социальных контактов, осторожность и застенчивость.");
            }
            if (ScaleChecker.MarkInRange(_ScaleA, 7, 12) & ScaleChecker.MarkInRange(_ScaleF, 0, 5) & ScaleChecker.MarkInRange(_ScaleH, 7, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Открытость в межличностных контактах, активность, общительность, готовность к вступлению в новые группы, сдержанность и рассудительность в выборе партнеров по общению. Склонность к экстраверсии.");
            }
            if (ScaleChecker.MarkInRange(_ScaleA, 0, 6) & ScaleChecker.MarkInRange(_ScaleF, 6, 12) & ScaleChecker.MarkInRange(_ScaleH, 7, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Сдержанность в непосредственных межличностных контактах, активность, экспрессивность в социальном общении, готовность к вступлению в новые группы, склонность к лидерству. Склонность к экстраверсии.");
            }
            if (ScaleChecker.MarkInRange(_ScaleA, 0, 6) & ScaleChecker.MarkInRange(_ScaleF, 0, 5) & ScaleChecker.MarkInRange(_ScaleH, 7, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Сдержанность и рассудительность в установлении межличностных контактов, активность в социальной сфере; может проявляться деловое лидерство.");
            }
            if (ScaleChecker.MarkInRange(_ScaleA, 7, 12) & ScaleChecker.MarkInRange(_ScaleF, 6, 12) & ScaleChecker.MarkInRange(_ScaleH, 0, 6))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Открытость, экспрессивность, импульсивность в межличностном общении. Трудность в установлении социальных контактов, проявление застенчивости в новых, незнакомых обстоятельствах, затруднения при принятии социальных решений.");
            }
            if (ScaleChecker.MarkInRange(_ScaleA, 7, 12) & ScaleChecker.MarkInRange(_ScaleF, 6, 12) & ScaleChecker.MarkInRange(_ScaleH, 7, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Открытость, общительность, активность в установлении как межличностных, так и социальных контактов. В поведении проявляются экспрессивность, импульсивность, социальная смелость, склонность к риску, готовность к вступлению в новые группы, быть лидером. Направленность вовне, на людей. Экстраверсия.");
            }

            //-----------
            base.TypeParagraph(10, Align.Center, "1.2 Социально-психологические особенности: коммуникативные свойства");
            if (ScaleChecker.MarkInRange(_ScaleE, 6, 12) &
                ScaleChecker.MarkInRange(_ScaleQ2, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleG, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleL, 6, 12) &
                ScaleChecker.MarkInRange(_ScaleN, 6, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Независимость характера, склонность к доминантности, авторитарности, настороженность по отношению к людям, противопоставление себя группе, склонность к лидерству, развитое чувство ответственности и долга, принятие правил и норм, самостоятельность в принятии решений, инициативность, активность в социальных сферах, гибкость и дипломатичность в межличностном общении, умение находить нетривиальные решения в практических, житейских ситуациях.");
            }
            if (ScaleChecker.MarkInRange(_ScaleE, 0, 5) &
                ScaleChecker.MarkInRange(_ScaleQ2, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleG, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleL, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleN, 6, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "В характере проявляется мягкость, податливость. Эти особенности компенсируются в социальном поведении противопоставлением себя группе, настороженностью по отношению к людям, гибкостью и дипломатичностью в общении, развитым чувством долга и ответственностью, принятием общепринятых моральных правил и норм.");
            }
            if (ScaleChecker.MarkInRange(_ScaleE, 6, 12) &
               ScaleChecker.MarkInRange(_ScaleQ2, 0, 6) &
               ScaleChecker.MarkInRange(_ScaleG, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleL, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleN, 6, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Независимость характера, настороженность по отношению к людям, гибкость и дипломатичность в общении, проявление конформных реакций: подчинение требованиям и мнению группы, принятие общепринятых моральных правил и норм, стремление к лидерству, доминированию (авторитарности) как проявление конформности.");
            }
            if (ScaleChecker.MarkInRange(_ScaleE, 6, 12) &
                ScaleChecker.MarkInRange(_ScaleQ2, 0, 6) &
                ScaleChecker.MarkInRange(_ScaleG, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleL, 0, 6) &
                ScaleChecker.MarkInRange(_ScaleN, 6, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Независимость характера, открытость, дипломатичность по отношению к людям, принятие общепринятых правил и норм, развитое чувство долга и ответственности. Подчинение требованиям и мнению группы, способность к принятию самостоятельных и оригинальных решений как в интеллектуальных, так и в житейских ситуациях.");
            }
            if (ScaleChecker.MarkInRange(_ScaleE, 6, 12) &
               ScaleChecker.MarkInRange(_ScaleQ2, 0, 6) &
               ScaleChecker.MarkInRange(_ScaleG, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleL, 0, 6) &
               ScaleChecker.MarkInRange(_ScaleN, 6, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Независимость в принятии интеллектуальных решений, открытость и прямолинейность по отношению к людям.");
            }
            if (ScaleChecker.MarkInRange(_ScaleE, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleQ2, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleG, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleL, 0, 6) &
               ScaleChecker.MarkInRange(_ScaleN, 6, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Проявление конформности: принятие общепринятых моральных правил и норм, развитое чувство долга и ответственности, подчинение требованиям и мнению группы. Независимость характера, открытость и дипломатичность по отношению к людям, развитое чувство долга и ответственности, принятие общепринятых моральных правил и норм, склонность к лидерству, доминированию (авторитарности), уверенность в социальных ситуациях.");
            }
            if (ScaleChecker.MarkInRange(_ScaleE, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleQ2, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleG, 0, 6) &
                ScaleChecker.MarkInRange(_ScaleL, 0, 6) &
                ScaleChecker.MarkInRange(_ScaleN, 6, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Независимость характера, проявление нонконформных реакций: свободное отношение к общепринятым правилам и нормам, склонность к противопоставлению себя группе, автономность в социальном поведении, некоторая безответственность, склонность к нарушениям традиций, принятию неординарных решений. По отношению к людям - открытость, доверчивость, дипломатичность (при высоком уровне интеллекта можно предполагать высокий творческий потенциал личности).");
            }
            if (ScaleChecker.MarkInRange(_ScaleE, 7, 12) &
                 ScaleChecker.MarkInRange(_ScaleQ2, 0, 6) &
                 ScaleChecker.MarkInRange(_ScaleG, 7, 12) &
                 ScaleChecker.MarkInRange(_ScaleL, 7, 12) &
                 ScaleChecker.MarkInRange(_ScaleN, 6, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Независимость характера, настороженность и проницательность по отношению к людям, зависимость от группы и общественного мнения, конформность и некоторая социальная незрелость. Могут быть невротические реакции (при низких оценках по фактору MD и высоких - по фактору О)");
            }
            if (ScaleChecker.MarkInRange(_ScaleE, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleQ2, 0, 6) &
               ScaleChecker.MarkInRange(_ScaleG, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleL, 0, 6) &
               ScaleChecker.MarkInRange(_ScaleN, 0, 5))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Независимость характера, по отношению к людям – открытость, доверчивость и прямолинейность. Развитое чувство долга, ответственности, приверженность общепринятым правилам и нормам, зависимость от мнения и требования группы. В экстремальных ситуациях может проявляться доминантность.");
            }
            if (ScaleChecker.MarkInRange(_ScaleE, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleQ2, 0, 6) &
                ScaleChecker.MarkInRange(_ScaleG, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleL, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleN, 0, 5))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Независимость характера, настороженность по отношению к людям, прямолинейность. В социальной сфере проявляются конформные реакции: зависимость от мнения и требования группы, приверженность общепринятым моральным правилам и нормам, некоторая социальная несамостоятельность; независимость проявляется в мотивации и чувстве долга и ответственности.");
            }
            if (ScaleChecker.MarkInRange(_ScaleE, 0, 6) &
                ScaleChecker.MarkInRange(_ScaleQ2, 0, 6) &
                ScaleChecker.MarkInRange(_ScaleG, 0, 6) &
                ScaleChecker.MarkInRange(_ScaleL, 0, 5) &
                ScaleChecker.MarkInRange(_ScaleN, 0, 5))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Мягкость, уступчивость и открытость, приверженность мнению и требованию группы, прямолинейность и доверчивость по отношению к людям, свободное отношение к общепринятым моральным правилам и нормам. Отмечается конформность поведения, социальная несамостоятельность и незрелость.");
            }
            if (ScaleChecker.MarkInRange(_ScaleE, 0, 6) &
               ScaleChecker.MarkInRange(_ScaleQ2, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleG, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleL, 6, 12) &
               ScaleChecker.MarkInRange(_ScaleN, 6, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Природная мягкость и уступчивость характера компенсируется настороженным отношением к людям, стремлением к независимости и противопоставлению себя группе. Полное принятие общепринятых моральных правил и норм, дипломатичность и проницательность в отношениях с людьми. Возможно проявление делового лидерства.");
            }
            if (ScaleChecker.MarkInRange(_ScaleE, 0, 6) &
               ScaleChecker.MarkInRange(_ScaleQ2, 0, 6) &
               ScaleChecker.MarkInRange(_ScaleG, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleL, 6, 12) &
               ScaleChecker.MarkInRange(_ScaleN, 6, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Мягкость, уступчивость, по отношению к людям отмечается настороженность, дипломатичность, житейская проницательность. Социальное поведение характеризуется конформными реакциями: приверженностью общепринятым моральным правилам и нормам, зависимостью от мнения и требований группы, несамостоятельностью в принятии решений.");
            }
            if (ScaleChecker.MarkInRange(_ScaleE, 0, 6) &
                ScaleChecker.MarkInRange(_ScaleQ2, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleG, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleL, 0, 5) &
                ScaleChecker.MarkInRange(_ScaleN, 6, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Мягкость, уступчивость по отношению к людям, открытый и проницательный. В малой группе – стремление к независимости, некоторому противопоставлению себя группе. Развитое чувство долга и ответственности, принятие общепринятых моральных правил и норм. Возможно проявление волевых качеств и некоторое стремление к лидерству.");
            }
            if (ScaleChecker.MarkInRange(_ScaleE, 0, 6) &
               ScaleChecker.MarkInRange(_ScaleQ2, 0, 6) &
               ScaleChecker.MarkInRange(_ScaleG, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleL, 0, 5) &
               ScaleChecker.MarkInRange(_ScaleN, 6, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Мягкость, податливость, уступчивость. По отношению к людям – открытость и проницательность. В социальном поведении отличается конформизмом, зависимостью от мнения и требований группы, принятием общепринятых моральных правил и норм, несамостоятельностью и нерешительностью в принятии решений.");
            }
            if (ScaleChecker.MarkInRange(_ScaleE, 0, 6) &
               ScaleChecker.MarkInRange(_ScaleQ2, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleG, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleL, 0, 5) &
               ScaleChecker.MarkInRange(_ScaleN, 0, 5))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Мягкость, уступчивость, открытость и прямолинейность. В малых группах отмечается стремление к независимости и самостоятельности. Развитое чувство долга и ответственности, принятие общепринятых моральных правил и норм.");
            }
            if (ScaleChecker.MarkInRange(_ScaleE, 0, 6) &
                ScaleChecker.MarkInRange(_ScaleQ2, 0, 5) &
                ScaleChecker.MarkInRange(_ScaleG, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleL, 6, 12) &
                ScaleChecker.MarkInRange(_ScaleN, 0, 5))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Мягкость, уступчивость, бесхитростность, но есть настороженность по отношению к людям. В социальном поведении – конформность, зависимость от мнения группы, принятие общепринятых моральных правил и норм, несамостоятельность в принятии решений.");
            }
            if (ScaleChecker.MarkInRange(_ScaleE, 0, 6) &
                ScaleChecker.MarkInRange(_ScaleQ2, 0, 5) &
                ScaleChecker.MarkInRange(_ScaleG, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleL, 6, 12) &
                ScaleChecker.MarkInRange(_ScaleN, 6, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Мягкость, уступчивость, по отношению к людям – настороженность и проницательность. В социальном поведении – конформность, развитое чувство долга и ответственности, принятие общепринятых моральных правил и норм, умение находить правильный выход из трудных житейских ситуаций.");
            }
            if (ScaleChecker.MarkInRange(_ScaleE, 0, 6) &
               ScaleChecker.MarkInRange(_ScaleQ2, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleG, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleL, 6, 12) &
               ScaleChecker.MarkInRange(_ScaleN, 0, 5))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Мягкость, уступчивость, прямолинейность; в малой группе стремление к независимости, к противопоставлению себя по отношению к ней. Настороженность по отношению к людям, развитое чувство долга и ответственности.");
            }
            if (ScaleChecker.MarkInRange(_ScaleE, 0, 6) &
               ScaleChecker.MarkInRange(_ScaleQ2, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleG, 0, 6) &
               ScaleChecker.MarkInRange(_ScaleL, 0, 5) &
               ScaleChecker.MarkInRange(_ScaleN, 0, 5))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Мягкость, доверчивость, уступчивость, прямолинейность. В социальном поведении отношение к общепринятым моральным правилам и нормам. Можно предполагать личностную и социальную незрелость.");
            }
            if (ScaleChecker.MarkInRange(_ScaleE, 0, 6) &
               ScaleChecker.MarkInRange(_ScaleQ2, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleG, 0, 6) &
               ScaleChecker.MarkInRange(_ScaleL, 0, 5) &
               ScaleChecker.MarkInRange(_ScaleN, 6, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Мягкость, открытость, по отношению к людям – проницательность, дипломатичность. В социальном поведении нонконформность: независимость от мнения группы, свобода от давления общепринятых моральных правил и норм, склонность к самостоятельности.");
            }
            if (ScaleChecker.MarkInRange(_ScaleE, 0, 6) &
               ScaleChecker.MarkInRange(_ScaleQ2, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleG, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleL, 6, 12) &
               ScaleChecker.MarkInRange(_ScaleN, 0, 5))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Мягкость, по отношению к людям – настороженность, прямолинейность, стремление к противопоставлению себя группе. Развитое чувство долга и ответственности, принятие общепринятых моральных правил и норм, стремление к лидерству.");
            }


            //-----------
            base.TypeParagraph(10, Align.Center, "2. Эмоциональные характеристики личности");
            if (ScaleChecker.MarkInRange(_ScaleC, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleO, 0, 6) &
                ScaleChecker.MarkInRange(_ScaleQ3, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleQ4, 0, 8))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Эмоциональная устойчивость, уверенность в себе и в своих силах, спокойное адекватное восприятие действительности, умение контролировать свои эмоции и поведение, стрессоустойчивость. В поведении – уравновешенность, направленность на реальную действительность.");
                if (ScaleChecker.MarkInRange(_ScaleL, 0, 6) & ScaleChecker.MarkInRange(_ScaleG, 7, 12))
                { base.TypeParagraph(10, Align.FullyJustify, "Спокойная адекватность. Развитые волевые чувства."); }
            }
            if (ScaleChecker.MarkInRange(_ScaleC, 0, 6) &
                           ScaleChecker.MarkInRange(_ScaleO, 7, 12) &
                           ScaleChecker.MarkInRange(_ScaleQ3, 0, 6) &
                           ScaleChecker.MarkInRange(_ScaleQ4, 9, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Эмоциональная неустойчивость, повышенная тревожность: неуверенность в себе, мнительность, низкая стрессоустойчивость, излишняя эмоциональная напряженность, фрустрированность, низкий контроль эмоций и поведения, импульсивность, аффективность, зависимость от настроений.");
                if (ScaleChecker.MarkInRange(_ScaleL, 7, 12))
                { base.TypeParagraph(10, Align.FullyJustify, "Отмечается невротический синдром тревожности, направленность на разрешение внутренних конфликтов."); }
            }
            if (ScaleChecker.MarkInRange(_ScaleC, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleO, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleQ3, 0, 6) &
               ScaleChecker.MarkInRange(_ScaleQ4, 9, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Сильная нервная система, природная эмоциональная устойчивость. Сниженная волевая активность, повышенная тревожность, мнительность, низкий контроль эмоций и поведения, зависимость от настроений, фрустрированность, низкая стрессоустойчивость. Во внешнем поведении может производить впечатление достаточно уравновешенного человека (импульсивность проявляется в стрессовых ситуациях).");
                if (ScaleChecker.MarkInRange(_ScaleL, 7, 12))
                { base.TypeParagraph(10, Align.FullyJustify, "Отмечается невротический синдром тревожности, направленность на разрешение внутренних конфликтов."); }
            }
            if (ScaleChecker.MarkInRange(_ScaleC, 0, 6) &
                ScaleChecker.MarkInRange(_ScaleO, 0, 6) &
                ScaleChecker.MarkInRange(_ScaleQ3, 0, 6) &
                ScaleChecker.MarkInRange(_ScaleQ4, 0, 8))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Эмоциональная пластичность, генетическая неустойчивость эмоций (биологическая зависимость), низкая волевая регуляция: неумение контролировать свои эмоции и поведение, зависимость от настроений, импульсивность, аффективность. При этом может быть стрессоустойчивым.");
                if (ScaleChecker.MarkInRange(_ScaleN, 0, 5))
                { base.TypeParagraph(10, Align.FullyJustify, "Диагностируется низкая мотивационность, довольство собой, внутренняя расслабленность. Низкая эффективность в профессиональной деятельности."); }
            }
            if (ScaleChecker.MarkInRange(_ScaleC, 7, 12) &
                 ScaleChecker.MarkInRange(_ScaleO, 0, 6) &
                 ScaleChecker.MarkInRange(_ScaleQ3, 0, 6) &
                 ScaleChecker.MarkInRange(_ScaleQ4, 0, 8))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Генетическая эмоциональная устойчивость (биологическая зависимость), уверенность в себе, спокойное адекватное восприятие действительности; такой человек не нуждается в волевой регуляции своих эмоций и поведения, стрессоустойчив, ригиден. В поведении может быть уравновешен, спокоен.");
                if (ScaleChecker.MarkInRange(_ScaleN, 0, 5))
                { base.TypeParagraph(10, Align.FullyJustify, "Диагностируется низкая мотивационность, довольство собой, внутренняя расслабленность. Низкая эффективность в профессиональной деятельности."); }
            }
            if (ScaleChecker.MarkInRange(_ScaleC, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleO, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleQ3, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleQ4, 0, 8))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Генетическая эмоциональная стабильность, высокий контроль эмоций и поведения, стрессоустойчивость, определенное недовольство собой, некоторая неудовлетворенность, что обеспечивает стремление к самоактуализации. В поведении – уравновешенный, стабильный, устремленный на реальную действительность и социальный успех.");
                if (ScaleChecker.MarkInRange(_ScaleN, 7, 12))
                { base.TypeParagraph(10, Align.FullyJustify, "Можно предположить завышенный уровень притязаний."); }
            }
            if (ScaleChecker.MarkInRange(_ScaleC, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleO, 7, 12) &
                ScaleChecker.MarkInRange(_ScaleQ3, 0, 6) &
                ScaleChecker.MarkInRange(_ScaleQ4, 0, 8))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Генетическая эмоциональная стабильность, низкий контроль эмоций и поведения, низкая саморегуляция порождает недовольство собой. Однако в экстремальных ситуациях проявляются природные качества, обеспечивающие стрессоустойчивость и достаточную уравновешенность поведения. Отмечается эмоционально-волевая незрелость личности.");
            }
            if (ScaleChecker.MarkInRange(_ScaleC, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleO, 0, 6) &
               ScaleChecker.MarkInRange(_ScaleQ3, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleQ4, 8, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Генетическая стабильность, высокая саморегуляция, контроль эмоций и поведения обеспечивают уравновешенность, внутреннюю уверенность в себе и в своих силах, спокойное восприятие действительности, но может наблюдаться низкая ситуативная стрессоустойчивость, излишняя эмоциональная напряженность, однако это касается только сложных значимых ситуаций и может поддаваться контролю. Личность эмоционально зрелая.");
            }
            if (ScaleChecker.MarkInRange(_ScaleC, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleO, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleQ3, 7, 12) &
               ScaleChecker.MarkInRange(_ScaleQ4, 8, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Генетическая эмоциональная стабильность, высокоразвитый контроль эмоций и поведения, выраженный волевой компонент и саморегуляция обеспечивают уравновешенность поведения. Однако внутренняя неудовлетворенность собой, мнительность и некоторая тревожность порождают фрустрированность и низкую стрессоустойчивость.");
                if (ScaleChecker.MarkInRange(_ScaleN, 7, 12) & ScaleChecker.MarkInRange(_ScaleL, 7, 12))
                { base.TypeParagraph(10, Align.FullyJustify, "Можно говорить об определенном невротическом синдроме и завышенном уровне притязаний."); }
            }
            if (ScaleChecker.MarkInRange(_ScaleI, 7, 12) &
              ScaleChecker.MarkInRange(_ScaleM, 6, 12) &
              ScaleChecker.MarkInRange(_ScaleO, 7, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Запрограммированная эмоциональная чувствительность, утонченность, богатство эмоциональных переживаний, широкая эмоциональная палитра, развитое воображение, склонность к мечтательности, рефлексии, неудовлетворенность собой, повышенные тревожность и интуитивность. Диагностируется направленность на свой внутренний мир, художественный тип личности и тревожность как свойство личности.");
            }
            if (ScaleChecker.MarkInRange(_ScaleI, 0, 6) &
              ScaleChecker.MarkInRange(_ScaleM, 0, 5) &
              ScaleChecker.MarkInRange(_ScaleO, 0, 6))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Низкая чувствительность, некоторая эмоциональная уплощенность, рациональность, практичность, уверенность в себе, спокойная адекватность в восприятии действительности, уравновешенность и стабильность в поведении, направленность на конкретную практическую деятельность (прагматизм) и на реальную действительность.");
            }
            if (ScaleChecker.MarkInRange(_ScaleI, 7, 12) &
              ScaleChecker.MarkInRange(_ScaleM, 6, 12) &
              ScaleChecker.MarkInRange(_ScaleO, 0, 6))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Высокая чувствительность, эмоциональная утонченность, широкая эмоциональная палитра. Отмечается уверенность в себе, спокойное восприятие действительности, направленность на решение конкретных практических задач (прагматизм). У мужчин высокие оценки по фактору I указывают на художественный тип личности. Высокая чувствительность, эмоциональная утонченность, богатство эмоциональной палитры, склонность к рефлексии, неудовлетворенность собой, повышенная тревожность. Конкретное воображение, ориентация на реальную действительность. При низких оценках по факторам L и Q4 высокая тревожность (фактор О) интерпретируется как свойство личности и поэтому при сочетании с I+ может характеризовать художественный тип личности.");
            }
            if (ScaleChecker.MarkInRange(_ScaleI, 0, 6) &
              ScaleChecker.MarkInRange(_ScaleM, 7, 12) &
              ScaleChecker.MarkInRange(_ScaleO, 7, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Низкая чувствительность, некоторая эмоциональная уплощенность. Развитое воображение, склонность к мечтательности, рефлексии, недовольство собой, подверженность сомнениям, стремление к самосовершенствованию, поискам стимулов для воображения. Направленность на свой внутренний мир, низкая прагматичность в поведении, затруднения при решении практических задач.");
            }
            if (ScaleChecker.MarkInRange(_ScaleI, 0, 6) &
              ScaleChecker.MarkInRange(_ScaleM, 0, 6) &
              ScaleChecker.MarkInRange(_ScaleO, 7, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Низкая чувствительность, некоторая эмоциональная уплощенность, прагматичность, ориентированность на объективную реальность, следование земным принципам. При этом личности присущи неудовлетворенность собой, неуверенность в своих силах.");
                if (ScaleChecker.MarkInRange(_ScaleN, 6, 12) & ScaleChecker.MarkInRange(_ScaleQ4, 8, 12))
                { base.TypeParagraph(10, Align.FullyJustify, "Можно диагностировать невротический синдром."); }
            }
            if (ScaleChecker.MarkInRange(_ScaleI, 0, 6) &
              ScaleChecker.MarkInRange(_ScaleM, 7, 12) &
              ScaleChecker.MarkInRange(_ScaleO, 0, 6))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Низкая чувствительность, некоторая эмоциональная уплощенность, спокойное восприятие действительности, уверенность в себе и в своих силах, определенное самодовольство. Такой человек обладает развитым воображением, может претворять в реальность свои мечты, ориентирован на действительность и достаточно предприимчив.");
                if (ScaleChecker.MarkInRange(_ScaleN, 7, 12))
                { base.TypeParagraph(10, Align.FullyJustify, "Отмечается практическая предприимчивость личности"); }
            }
            if (ScaleChecker.MarkInRange(_ScaleI, 7, 12) &
              ScaleChecker.MarkInRange(_ScaleM, 0, 6) &
              ScaleChecker.MarkInRange(_ScaleO, 7, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Неуверенность в себе, направленность на свой внутренний мир. Такой человек обладает конкретным воображением, ориентацией на земные принципы, однако высокая тревожность не дает ему возможности быть предприимчивым и решительным.");
                if (ScaleChecker.MarkInRange(_ScaleL, 6, 12) & ScaleChecker.MarkInRange(_ScaleQ4, 8, 12))
                { base.TypeParagraph(10, Align.FullyJustify, "Диагностируется невротический синдром тревожности."); }
            }

            //-----------
            base.TypeParagraph(10, Align.Center, "3. Интеллектуальные характеристики личности");
            if (ScaleChecker.MarkInRange(_ScaleB, 4, 8) &
             ScaleChecker.MarkInRange(_ScaleM, 7, 12) &
             ScaleChecker.MarkInRange(_ScaleQ1, 7, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Оперативность, подвижность мышления, высокий уровень общей культуры, умение оперировать абстракциями, развитая аналитичность, развитые интеллектуальные интересы, стремление к новым знаниям, склонность к свободомыслию, радикализму, высокая эрудированность, широта взглядов.");
                if (ScaleChecker.MarkInRange(_ScaleE, 7, 12))
                { base.TypeParagraph(10, Align.FullyJustify, "Отмечается самостоятельность и оригинальность в решении интеллектуальных задач."); }
            }
            if (ScaleChecker.MarkInRange(_ScaleB, 4, 8) &
             ScaleChecker.MarkInRange(_ScaleM, 0, 6) &
             ScaleChecker.MarkInRange(_ScaleQ1, 7, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Оперативность, подвижность мышления, высокий уровень общей культуры, развитая аналитичность, интерес к интеллектуальным новым знаниям, стремление к свободомыслию, радикализму, высокая эрудированность, широта взглядов. Конкретное воображение, направленность на решение конкретных интеллектуальных задач. Гармоничность развития интеллекта.");
                if (ScaleChecker.MarkInRange(_ScaleE, 7, 12))
                { base.TypeParagraph(10, Align.FullyJustify, "Отмечается самостоятельность и оригинальность в решении интеллектуальных задач."); }
            }
            if (ScaleChecker.MarkInRange(_ScaleB, 4, 8) &
             ScaleChecker.MarkInRange(_ScaleM, 7, 12) &
             ScaleChecker.MarkInRange(_ScaleQ1, 7, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Оперативность, подвижность мышления, высокий уровень общей культуры, развитая аналитичность, интерес к интеллектуальным знаниям, стремление к свободомыслию, радикализму. Умение оперировать абстракциями, развитое воображение.");
                if (ScaleChecker.MarkInRange(_ScaleE, 7, 12))
                { base.TypeParagraph(10, Align.FullyJustify, "Склонность к самостоятельным оригинальным решениям. Гармоничность развития интеллекта."); }
                if (ScaleChecker.MarkInRange(_ScaleN, 7, 12))
                { base.TypeParagraph(10, Align.FullyJustify, "Умение переводить абстрактные понятия в практическое воплощение (качество, необходимое руководителю)."); }
            }
            if (ScaleChecker.MarkInRange(_ScaleB, 4, 8) &
             ScaleChecker.MarkInRange(_ScaleM, 7, 12) &
             ScaleChecker.MarkInRange(_ScaleQ1, 0, 6))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Оперативность, подвижность мышления, высокий уровень общей культуры, эрудированность. Умение оперировать абстракциями, развитое воображение. Критичность и консерватизм в принятии нового, сниженные интеллектуальные интересы, низкая аналитичность мышления.");
                if (ScaleChecker.MarkInRange(_ScaleE, 7, 12))
                { base.TypeParagraph(10, Align.FullyJustify, "Склонность к принятию самостоятельных, неординарных интеллектуальных решений."); }
            }
            if (ScaleChecker.MarkInRange(_ScaleB, 4, 8) &
             ScaleChecker.MarkInRange(_ScaleM, 0, 6) &
             ScaleChecker.MarkInRange(_ScaleQ1, 0, 6))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Оперативность, подвижность мышления, высокий уровень общей культуры, эрудированность. Такой человек обладает конкретным воображением, критичностью и консервативностью в принятии нового, направлен на конкретное практическое мышление. ");
                if (ScaleChecker.MarkInRange(_ScaleN, 7, 12))
                { base.TypeParagraph(10, Align.FullyJustify, "Отмечается направленность на практическую деятельность."); }
            }
            if (ScaleChecker.MarkInRange(_ScaleB, 0, 3) &
             ScaleChecker.MarkInRange(_ScaleM, 7, 12) &
             ScaleChecker.MarkInRange(_ScaleQ1, 7, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Невысокая оперативность мышления, недостаточно развитая общая культура. Такой человек обладает развитой аналитичностью мышления, интеллектуальными интересами, умением оперировать абстрактными понятиями, развитым воображением.");
                if (ScaleChecker.MarkInRange(_ScaleE, 7, 12))
                { base.TypeParagraph(10, Align.FullyJustify, "Отмечается склонность к принятию самостоятельных оригинальных интеллектуальных решений. Низкие оценки по фактору В, при таком сочетании факторов могут объясняться рядом причин: недостаточным уровнем образования; низкой cтрессоустойчивостью, фрустрированностью, ситуативной тревожностью (сниженной оперативностью в реализации знаний); плохим физическим самочувствием на момент выполнения теста."); }
            }
            if (ScaleChecker.MarkInRange(_ScaleB, 0, 3) &
             ScaleChecker.MarkInRange(_ScaleM, 0, 6) &
             ScaleChecker.MarkInRange(_ScaleQ1, 7, 12))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Невысокая оперативность мышления, недостаточно развитый общий уровень культуры, эрудированности (возможно по причинам фрустрированности или невысокого уровня образования). Такой человек обладает развитой аналитичностью мышления, интеллектуальными интересами, склонностью к свободомыслию, радикализму. Отмечается конкретное воображение.");
                if (ScaleChecker.MarkInRange(_ScaleE, 7, 12))
                { base.TypeParagraph(10, Align.FullyJustify, "Склонность к принятию самостоятельных оригинальных интеллектуальных решений."); }
                if (ScaleChecker.MarkInRange(_ScaleN, 7, 12))
                { base.TypeParagraph(10, Align.FullyJustify, "Отмечается развитый практический интеллект."); }
            }
            if (ScaleChecker.MarkInRange(_ScaleB, 0, 3) &
             ScaleChecker.MarkInRange(_ScaleM, 7, 12) &
             ScaleChecker.MarkInRange(_ScaleQ1, 0, 6))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Невысокая оперативность мышления, невысокий уровень общей культуры и эрудиции, критичность и консерватизм в принятии нового, сниженный интерес к новым интеллектуальным знаниям. Такой человек обладает развитым воображением, умением оперировать абстракциями – данное свойство влияет на такую черту личности, как мечтательность. Решение интеллектуальных задач затруднено.");
                if (ScaleChecker.MarkInRange(_ScaleE, 7, 12) & ScaleChecker.MarkInRange(_ScaleN, 7, 12))
                { base.TypeParagraph(10, Align.FullyJustify, "Трудности в принятии интеллектуальных житейских решений компенсированы."); }
                if (ScaleChecker.MarkInRange(_ScaleE, 7, 12) & ScaleChecker.MarkInRange(_ScaleN, 0, 6))
                { base.TypeParagraph(10, Align.FullyJustify, "Отмечается склонность к доминантности и консервативному упрямству."); }
            }
            if (ScaleChecker.MarkInRange(_ScaleB, 0, 3) &
             ScaleChecker.MarkInRange(_ScaleM, 0, 6) &
             ScaleChecker.MarkInRange(_ScaleQ1, 0, 6))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Невысокая оперативность мышления, неумение актуализировать свои знания, низкая общая культура и эрудированность, консерватизм и критичность в принятии новых интеллектуальных знаний, сниженные интеллектуальные интересы, конкретность воображения, направленность на практическую, конкретную деятельность.");
                if (ScaleChecker.MarkInRange(_ScaleE, 7, 12) & ScaleChecker.MarkInRange(_ScaleN, 7, 12))
                { base.TypeParagraph(10, Align.FullyJustify, "Обострены негативные свойства личности: доминированность, житейская изворотливость, упрямство."); }

            }


            //-----------
            base.TypeParagraph(10, Align.Center, "4. Адекватность самооценки");
            if (ScaleChecker.MarkInRange(_ScaleMD, 0, 3))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Заниженная самооценка, излишне критическое отношение к себе, неудовлетворенность собой, непринятие себя.");
            }
            if (ScaleChecker.MarkInRange(_ScaleMD, 4, 8))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Адекватная самооценка, знание себя и своих качеств, принятие себя (индикатор личностной зрелости).");
            }
            if (ScaleChecker.MarkInRange(_ScaleMD, 9, 14))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Завышенная самооценка, некритическое отношение к себе, принятие себя и своих качеств (индикатор личностной незрелости.)");
            }
            if (ScaleChecker.MarkInRange(_ScaleMD, 4, 8) &
             ScaleChecker.MarkInRange(_ScaleG, 7, 12) &
             ScaleChecker.MarkInRange(_ScaleQ3, 7, 12) &
                 ScaleChecker.MarkInRange(_ScaleC, 7, 12) &
                 ScaleChecker.MarkInRange(_ScaleM, 0, 6))
            {
                base.TypeParagraph(10, Align.FullyJustify, "Адекватная самооценка, социальная нормативность, эмоционально значимая ответственность поведения, самодисциплина, самоконтроль эмоций и поведения, эмоциональная стабильность и конкретность воображения образуют симптомокомплекс, характеризующий саморегуляцию и зрелость личности.");
            }



            //footer
            this.TypeParagraph(14, Align.Left, "");
            this.TypeParagraph(14, Align.Left, "");
            this.TypeParagraph(14, Align.Left, "Характеристика составлена:");

            base.SplashHide();
            base.SaveDoc();
            base.OpenDoc(WaitForExit);


        }
        public System.Collections.Generic.List<EnumPTests> UsedTests
        {
            get {return new System.Collections.Generic.List<EnumPTests> { EnumPTests.KettellC }; }
        }
    }
}
