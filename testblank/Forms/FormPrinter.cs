using System.Diagnostics;
using Recog.PTests;
namespace Recog.Forms
{

    public static class FormPrinter
    {

        public static void ShowForm(EnumPTests Test)
        {
            Process p = null;

            switch (Test)
            {
                case EnumPTests.KettellC:
                    p = new Process { StartInfo = { FileName = ApplicationInfo.GetDirectory() + @"\Forms\KettellC.pdf" } };
                    break;
                case EnumPTests.Adaptability:
                    p = new Process { StartInfo = { FileName = ApplicationInfo.GetDirectory() + @"\Forms\Adaptability.pdf" } };
                    break;
                case EnumPTests.FPI:
                    p = new Process { StartInfo = { FileName = ApplicationInfo.GetDirectory() + @"\Forms\FPI.pdf" } };
                    break;
                case EnumPTests.KettellA:
                    p = new Process { StartInfo = { FileName = ApplicationInfo.GetDirectory() + @"\Forms\KettellA.pdf" } };
                    break;
                case EnumPTests.Modul2:
                    p = new Process { StartInfo = { FileName = ApplicationInfo.GetDirectory() + @"\Forms\Modul2.pdf" } };
                    break;
                case EnumPTests.Prognoz:
                    p = new Process { StartInfo = { FileName = ApplicationInfo.GetDirectory() + @"\Forms\Prognoz.pdf" } };
                    break;
                case EnumPTests.Addictive:
                    p = new Process { StartInfo = { FileName = ApplicationInfo.GetDirectory() + @"\Forms\Addictive.pdf" } };
                    break;
                case EnumPTests.Leongard:
                    p = new Process { StartInfo = { FileName = ApplicationInfo.GetDirectory() + @"\Forms\Leongard.pdf" } };
                    break;
                case EnumPTests.NPNA:
                    p = new Process { StartInfo = { FileName = ApplicationInfo.GetDirectory() + @"\Forms\NPNA.pdf" } };
                    break;

            }

            if (p != null) { p.Start(); }


        }

        public static void ShowMethod(EnumPTests Test)
        {
            Process p = null;

            switch (Test)
            {
                case EnumPTests.KettellC:
                    p = new Process { StartInfo = { FileName = ApplicationInfo.GetDirectory() + @"\Forms\KettellCmethod.pdf" } };
                    break;
                case EnumPTests.Adaptability:
                    p = new Process { StartInfo = { FileName = ApplicationInfo.GetDirectory() + @"\Forms\Adaptabilitymethod.pdf" } };
                    break;
                case EnumPTests.FPI:
                    p = new Process { StartInfo = { FileName = ApplicationInfo.GetDirectory() + @"\Forms\FPImethod.pdf" } };
                    break;
                case EnumPTests.KettellA:
                    p = new Process { StartInfo = { FileName = ApplicationInfo.GetDirectory() + @"\Forms\KettellAmethod.pdf" } };
                    break;
                case EnumPTests.PNN:
                    p = new Process { StartInfo = { FileName = ApplicationInfo.GetDirectory() + @"\Forms\PNNmethod.pdf" } };
                    break;
                case EnumPTests.Modul2:
                    p = new Process { StartInfo = { FileName = ApplicationInfo.GetDirectory() + @"\Forms\Modul2Method.pdf" } };
                    break;
                case EnumPTests.Prognoz:
                    p = new Process { StartInfo = { FileName = ApplicationInfo.GetDirectory() + @"\Forms\PrognozMethod.pdf" } };
                    break;
                case EnumPTests.Addictive:
                    p = new Process { StartInfo = { FileName = ApplicationInfo.GetDirectory() + @"\Forms\AddictiveMethod.pdf" } };
                    break;
                case EnumPTests.Leongard:
                    p = new Process { StartInfo = { FileName = ApplicationInfo.GetDirectory() + @"\Forms\LeongardMethod.pdf" } };
                    break;
                case EnumPTests.NPNA:
                    p = new Process { StartInfo = { FileName = ApplicationInfo.GetDirectory() + @"\Forms\NPNAMethod.pdf" } };
                    break;
            }

            if (p != null) { p.Start(); }


        }




    }
}
