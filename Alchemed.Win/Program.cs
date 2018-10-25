using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultWill
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            SplashScreen.ShowSplashScreen();
            Application.DoEvents();
            SplashScreen.SetStatus("Loading 0");
            System.Threading.Thread.Sleep(500);
            SplashScreen.SetStatus("Loading 20%");
            System.Threading.Thread.Sleep(300);
            SplashScreen.SetStatus("Loading 40%");
            System.Threading.Thread.Sleep(900);
            SplashScreen.SetStatus("Loading 60%");
            System.Threading.Thread.Sleep(100);
            SplashScreen.SetStatus("Loading 80");
            System.Threading.Thread.Sleep(400);

            SplashScreen.SetStatus("Loading 100");
            System.Threading.Thread.Sleep(90);

            Application.Run(new frmConsult());
        }
    }
}
