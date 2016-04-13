using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch
{
    class PeopleSearchController
    {

        private IMainWindow window;
        private IAddPersonWindow windowAddPerson;
        private PeopleContext boggleDB;

        public PeopleSearchController(IMainWindow window,IAddPersonWindow windowAddPerson)
        {
            boggleDB = new PeopleContext();
            using (boggleDB)
            {
                boggleDB.People.Create();
            }

            this.window = window;
            this.windowAddPerson = windowAddPerson;

            window.CloseEvent += HandleCloseEvent;
            window.SearchEvent += HandleSearchEvent;
            window.CloseEvent += HandleMainCloseAddPersonWindow;
            window.addPersonEvent += HandleAddPersonEvent;
            windowAddPerson.CloseEventAddPerson += HandleAddPersonWindowCloseEvent;
            windowAddPerson.AddPersonEvent += HandleAddToDBPersonEvent;


        }

        public void HandleAddToDBPersonEvent()
        {
            PeopleModel currentPerson = new PeopleModel();

            //Checking address.
            string address = windowAddPerson.Address;
            if(address == null || address.Length == 0)
            {
                windowAddPerson.showInAddPersonWindowMessage("Please provide a valid address and try again.");
                return;
            }
            currentPerson.address = address;

            //Checking age.
            int age = windowAddPerson.Age;
            if (age <= 0)
            {
                windowAddPerson.showInAddPersonWindowMessage("Please provide a valid age and try again.");
                return;
            }
            currentPerson.age = age;

            //Checking first name.
            string fn = windowAddPerson.FirstName;
            if (fn == null || fn.Length == 0)
            {
                windowAddPerson.showInAddPersonWindowMessage("Please provide a valid first name and try again.");
                return;
            }
            currentPerson.firstName = fn;

            //Checking last name.
            string ln = windowAddPerson.Lastname;
            if (ln == null || ln.Length == 0)
            {
                windowAddPerson.showInAddPersonWindowMessage("Please provide a valid last name and try again.");
                return;
            }
            currentPerson.lastName = ln;

            //Checking interests.
            string interests = windowAddPerson.interests;
            if (interests == null || interests.Length == 0)
            {
                windowAddPerson.showInAddPersonWindowMessage("Please provide a valid interests and try again.");
                return;
            }
            currentPerson.interests = interests;
            currentPerson.interests = "swag";

            //Checking imagePath
            string filePath = windowAddPerson.imagePath;
            if(filePath == null || filePath.Length == 0)
            {
                windowAddPerson.showInAddPersonWindowMessage("Please provide a valid image and try again.");
                return;
            }
            currentPerson.imagePath = filePath;

            boggleDB.addPersonToDB(currentPerson);
        }

        public void HandleCloseEvent()
        {
            window.closeWindow();
        }

        public void HandleSearchEvent()
        {
            //DO WORK. 
        }

        public void HandleAddPersonEvent()
        {
            windowAddPerson.showWindow();
        }

        public void HandleMainCloseAddPersonWindow()
        {
            windowAddPerson.closeWindow();
        }

        public void HandleAddPersonWindowCloseEvent()
        {
            windowAddPerson.hideWidndow();
        }
    }
}
