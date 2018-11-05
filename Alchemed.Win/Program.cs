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
            System.Threading.Thread.Sleep(100);
            SplashScreen.SetStatus("Loading 20%");
            System.Threading.Thread.Sleep(100);
            SplashScreen.SetStatus("Loading 40%");
            System.Threading.Thread.Sleep(100);
            SplashScreen.SetStatus("Loading 60%");
            System.Threading.Thread.Sleep(100);
            SplashScreen.SetStatus("Loading 80");
            System.Threading.Thread.Sleep(100);
            SplashScreen.SetStatus("Loading 100");
            System.Threading.Thread.Sleep(90);

            SplashScreen.CloseForm();

            try
            {
                if (IsConfigured())
                {
                    var mdi = new mdiMain();
                    if (mdi.IsDisposed == false)
                    {
                        Application.Run(mdi);
                    }
                    else
                    {
                        Configure cfg1 = new Configure();
                        cfg1.ShowDialog();
                    }
                }
                else
                {
                    Configure cfg2 = new Configure();
                    cfg2.ShowDialog();
                    if (IsConfigured() == false)
                    {
                        return;
                    }
                    else
                    {
                        var mdi = new mdiMain();
                        if (mdi.IsDisposed == false)
                        {
                            Application.Run(mdi);
                        }
                        else
                        {
                            Configure cfg3 = new Configure();
                            cfg3.ShowDialog();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                //throw ex;
            }


            //Application.Run( new frmConsult());
        }



        private static bool IsConfigured()
        {
            if (StaticFunctions.UseDropBoxStorage && string.IsNullOrEmpty(StaticFunctions.StorageFolder))
            {
                return false;
            }
            else if (StaticFunctions.UseCloadStorage && (string.IsNullOrEmpty(StaticFunctions.CloudStorageUrl) || string.IsNullOrEmpty(StaticFunctions.CloudApiKey)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
