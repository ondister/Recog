using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Recog.Data;
using Recog.TestConstruktor;
using Recog.Scaning;
namespace Recog
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            MainLoader ml = new MainLoader();
            ml.ConnectComplite += new ConnectHandler(ml_ConnectComplite);
            ml.Start();

        }

        static void ml_ConnectComplite(object sender, ConnectArgs e)
        {
          
            if (e.IsSuccess == true)
            {
                MainMenu mm = new MainMenu();
                mm.SetDesktopLocation(0, 0);
                mm.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
                MainLoader ml = (MainLoader)sender;
                mm.pGlobalEntities = ml.GE;
                mm.fGlobalEntities = ml.FE;
                Application.Run(mm);
            }
            else 
            {
                ConnectionForm connsettingform = new ConnectionForm(true);
                Application.Run(connsettingform);
               
            }
        }

        
    }
}
