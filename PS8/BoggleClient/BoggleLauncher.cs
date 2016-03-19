using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoggleClient
{
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
