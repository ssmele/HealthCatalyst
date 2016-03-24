// Written by: Hanna Larsen & Salvatore Stone Mele
//              u0741837       u0897718
//Date: 3/24/16

using System.Windows.Forms;

namespace BoggleClient
{

    /// <summary>
    /// Contenxt for our Boggle Client. 
    /// </summary>
    class BoggleContext : ApplicationContext
    {

        private int windowCount = 0;

        /// <summary>
        /// Context for the Boggle. Singleton pattern. 
        /// </summary>
        private static BoggleContext context;

        private BoggleContext()
        {
        }

        /// <summary>
        /// Singleton pattern. If we try and make a new context and its already there return it. If its not
        /// make it and return it. 
        /// </summary>
        /// <returns>Spreadsheet Context</returns>
        public static BoggleContext GetContext()
        {
            if (context == null)
            {
                context = new BoggleContext();
            }
            return context;
        }

        /// <summary>
        /// Opens up a new Boggle window and subscribes its close event to a decrement of windowCount.
        /// </summary>
        public void RunNew()
        {
            BoggleWindow window = new BoggleWindow();

            //After Controller is implemented
            new Controller(window);

            //Increment windowCount
            windowCount++;

            //When this window closes fire an event and if window count equals zero
            //close the thread.
            window.FormClosed += (o, e) => { if (--windowCount <= 0) ExitThread(); };

            //Start the new form
            window.Show();
        }
    }
}
