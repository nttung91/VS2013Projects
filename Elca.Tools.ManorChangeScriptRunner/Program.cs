using System;
using System.Windows.Forms;
using DevExpress.LookAndFeel;

namespace Elca.Tools.ManorChangeScriptRunner
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

            DevExpress.Skins.SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            Application.Run(new FrmRunScriptVN());
        }
    }
}