using System;
using System.Windows.Forms;

namespace SemniarPI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static SettingsObject so;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            so = SettingsObject.GetSettings();
            Application.Run(MainForm.GetInstance());
        }
    }
}
