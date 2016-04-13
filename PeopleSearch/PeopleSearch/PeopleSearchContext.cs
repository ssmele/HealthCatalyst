using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PeopleSearch
{
    class PeopleSearchContext 
    {

        private int windowCount = 0;

        private static PeopleSearchContext context;

        private PeopleSearchContext()
        {
        }

        public static PeopleSearchContext GetContext()
        {
            if (context == null)
            {
                context = new PeopleSearchContext();
            }
            return context;
        }

        public void RunNew()
        {
            MainWindow window = new MainWindow();

            //After Controller is implemented
            //new PeopleSearchController(window);

            //Increment windowCount
            windowCount++;

            //When this window closes fire an event and if window count equals zero
            //close the thread.
            //window.Closed += (o, e) => { if (--windowCount <= 0) ExitThread(); };

            //Start the new form
            window.Show();
        }
    }
}
