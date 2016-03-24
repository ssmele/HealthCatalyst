// Written by: Hanna Larsen & Salvatore Stone Mele
//              u0741837       u0897718
//Date: 3/24/16

using System;
using System.Windows.Forms;

namespace BoggleClient
{

    /// <summary>
    /// This class Launches our boggle game. 
    /// </summary>
    static class BoggleLauncher
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Getting spreadsheet context and get a window running inside of it.
            var context = BoggleContext.GetContext();
            BoggleContext.GetContext().RunNew();
            Application.Run(context);
        }
    }
}
