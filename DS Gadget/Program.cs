using Bluegrams.Application;
using System;
using System.Windows.Forms;

namespace DS_Gadget
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            try
            {
                PortableSettingsProvider.SettingsFileName = "DS Gadget.config";
                PortableSettingsProvider.ApplyProvider(Properties.Settings.Default);
                Properties.Settings settings = Properties.Settings.Default;
                if (settings.UpgradeRequired)
                {
                    settings.Upgrade();
                    settings.UpgradeRequired = false;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
                settings.Save();

            }
            catch (Exception ex)
            {
                GadgetLogger.Log($"Exception: ");
                GadgetLogger.Log(ex.Message);
                GadgetLogger.Log(ex.StackTrace);
                GadgetLogger.Log($"Raw: ");
                GadgetLogger.Log(ex.ToString());
                GadgetLogger.Flush();
                MessageBox.Show("Exception. Please see GadgetLog.txt for more information!", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }

        }
    }
}
