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
            //boggleDB = new PeopleContext();
            //using (boggleDB)
            //{
            //    boggleDB.People.
            //}

            this.window = window;
            this.windowAddPerson = windowAddPerson;

            window.CloseEvent += HandleCloseEvent;
            window.SearchEvent += HandleSearchEvent;
            window.CloseEvent += HandleMainCloseAddPersonWindow;
            window.addPersonEvent += HandleAddPersonEvent;
            windowAddPerson.CloseEventAddPerson += HandleAddPersonWindowCloseEvent;
            windowAddPerson.AddPersonEvent += HandleAddToDBPersonEvent;
            window.ResetEvent += HandleResetEvent;
            window.HelpEvent += HandleHelpEvent;


        }

        public void HandleHelpEvent()
        {
            helpWindow hw = new helpWindow();
            hw.Show();
        }

        public void HandleResetEvent()
        {
            window.resetPeople();
        }

        /// <summary>
        /// This will take the current information from the addPerson window and construct an object representing that person. It will then add that PeopleModel object
        /// to the database. 
        /// </summary>
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

            //boggleDB.addPersonToDB(currentPerson);



            //Clear all input texts boxes now.
            windowAddPerson.Address = "";
            windowAddPerson.Age = 0;
            windowAddPerson.FirstName = "";
            windowAddPerson.Lastname = "";
            windowAddPerson.Lastname = "";
            windowAddPerson.interests = "";
            windowAddPerson.imagePath = "";
            windowAddPerson.imageObject = null;
        }

        public void HandleCloseEvent()
        {
            window.closeWindow();
        }

        public void HandleSearchEvent(string name)
        {
            //List of people with the name. 
            List<PeopleModel> peopleList = new List<PeopleModel>();

            //DO QUEREY
            using (var context = new PeopleContext())
            {
                // Query for all blogs with names starting with B 
                var query = from b in context.People
                            where b.firstName == name ||
                            b.lastName == name
                            select b;

                foreach (var item in query)
                {
                    peopleList.Add(item);
                }
            }

            //If there was no one found display message for user. 
            if(peopleList.Count == 0)
            {
                window.showMessageMain("Sorry there was no people found for the given name!");
            }
            //If there is atleast one person then show there given info. 
            else
            {
                window.showPeople(peopleList);
            }
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
