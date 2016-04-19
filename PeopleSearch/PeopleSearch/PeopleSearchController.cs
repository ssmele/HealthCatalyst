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
        //private static PeopleContext peopleDB = new PeopleContext();

        public PeopleSearchController(IMainWindow window,IAddPersonWindow windowAddPerson)
        {
            this.window = window;
            this.windowAddPerson = windowAddPerson;

            window.CloseEvent += HandleCloseEvent;
            window.SearchEvent += HandleSearchEvent;
            window.CloseEvent += HandleMainCloseAddPersonWindow;
            window.SearchTextPressed += HandleSearchTextPressed;
            window.addPersonEvent += HandleAddPersonEvent;
            windowAddPerson.CloseEventAddPerson += HandleAddPersonWindowCloseEvent;
            windowAddPerson.AddPersonEvent += HandleAddToDBPersonEvent;
            window.ResetEvent += HandleResetEvent;
            window.HelpEvent += HandleHelpEvent;
            windowAddPerson.ResetAddPersonEvent += HandleResetAddPersonEvent;
        }

        public void HandleSearchTextPressed()
        {
            if (window.SearchTextBox == "Type in a first or last name.")
            {
                window.SearchTextBox = "";
            }
        }

        public void HandleResetAddPersonEvent()
        {
            //Reseting all text boxes.
            windowAddPerson.Address = "";
            windowAddPerson.Age = 0;
            windowAddPerson.FirstName = "";
            windowAddPerson.Lastname = "";
            windowAddPerson.Lastname = "";
            windowAddPerson.interests = "";
            windowAddPerson.imagePath = "";
            windowAddPerson.resetWindow();
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
        public async void HandleAddToDBPersonEvent()
        {
            Person currentPerson = new Person();

            //Checking address.
            string address = windowAddPerson.Address;
            if(address == null || address.Length == 0)
            {
                windowAddPerson.showInAddPersonWindowMessage("Please provide a valid address and try again.");
                return;
            }
            currentPerson.Address = address;

            //Checking age.
            int age = windowAddPerson.Age;
            if (age <= 0)
            {
                windowAddPerson.showInAddPersonWindowMessage("Please provide a valid age and try again.");
                return;
            }
            currentPerson.Age = age;

            //Checking first name.
            string fn = windowAddPerson.FirstName;
            if (fn == null || fn.Length == 0)
            {
                windowAddPerson.showInAddPersonWindowMessage("Please provide a valid first name and try again.");
                return;
            }
            currentPerson.FirstName = fn;

            //Checking last name.
            string ln = windowAddPerson.Lastname;
            if (ln == null || ln.Length == 0)
            {
                windowAddPerson.showInAddPersonWindowMessage("Please provide a valid last name and try again.");
                return;
            }
            currentPerson.LastName = ln;

            //Checking interests.
            string interests = windowAddPerson.interests;
            if (interests == null || interests.Length == 0)
            {
                windowAddPerson.showInAddPersonWindowMessage("Please provide a valid interests and try again.");
                return;
            }
            currentPerson.Interests = interests;

            //Checking imagePath
            string filePath = windowAddPerson.imagePath;
            if(filePath == null || filePath.Length == 0)
            {
                windowAddPerson.showInAddPersonWindowMessage("Please provide a valid image and try again.");
                return;
            }
            currentPerson.ImagePath = filePath;

            await addPerson(currentPerson);
        }


        public async Task addPerson(Person newPerson)
        {
            //Then reset the window for the next person. 
            HandleResetAddPersonEvent();

            //Adding person to DB. 
            using (var db = new PersonDBContext())
            {
                db.People.Add(newPerson);
                db.SaveChanges();
            }
            return;
        }

        public void HandleCloseEvent()
        {
            window.closeWindow();
        }


        public async Task<List<Person>> personQuery(string name)
        {
            //List of people with the name. 
            List<Person> peopleList = new List<Person>();

            //DO QUEREY
            using (var context = new PersonDBContext())
            {
                // Query for all blogs with names starting with B 
                var query = from b in context.People
                            where b.FirstName == name ||
                            b.LastName == name
                            select b;

                foreach (var item in query)
                {
                    peopleList.Add(item);
                }
            }

            return peopleList;
        }

        public async void HandleSearchEvent(string name)
        {
            //List of people with the name. 
            List<Person> peopleList = new List<Person>();

            //Do the query asyn
            peopleList = await personQuery(name);

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
