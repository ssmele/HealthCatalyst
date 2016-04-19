///By: Salvatore Stone Mele
///4/19/16

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;


namespace PeopleSearch
{

    /// <summary>
    /// This is the class that controls mainWindow, and addPersonWidnow. 
    /// </summary>
    public class PeopleSearchController
    {
        /// <summary>
        /// This is the MainWindow for the program.
        /// </summary>
        private IMainWindow window;

        /// <summary>
        /// This is the addPerson window that can be opened and closed for the program. 
        /// </summary>
        private IAddPersonWindow windowAddPerson;

        /// <summary>
        /// This is the folder path for the image folder. 
        /// </summary>
        private string imageFolderPath = AppDomain.CurrentDomain.BaseDirectory + "\\images";

        /// <summary>
        /// Seed to ensure that files match up with people. 
        /// </summary>
        private static int seed = 0;

        /// <summary>
        /// Controller for the program that sets up the windows, and subscribes the events. 
        /// </summary>
        /// <param name="window"></param>
        /// <param name="windowAddPerson"></param>
        public PeopleSearchController(IMainWindow window,IAddPersonWindow windowAddPerson)
        {
            //Setting up the windows. 
            this.window = window;
            this.windowAddPerson = windowAddPerson;

            //Subscribing all the events.
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

        /// <summary>
        /// This method is fired to determine if its the first time clicking the search box. If it is then it will clear the box so user can type. 
        /// </summary>
        public void HandleSearchTextPressed()
        {
            if (window.SearchTextBox == "Type in a first or last name.")
            {
                window.SearchTextBox = "";
            }
        }

        /// <summary>
        /// Resets all the text boxes in the addPersonWindow. 
        /// </summary>
        public void HandleResetAddPersonEvent()
        {
            //Reseting all text boxes.
            windowAddPerson.Address = "";
            windowAddPerson.Age = 0;
            windowAddPerson.FirstName = "";
            windowAddPerson.Lastname = "";
            windowAddPerson.Lastname = "";
            windowAddPerson.Interests = "";
            windowAddPerson.imagePath = "";
            windowAddPerson.resetWindowImage();
        }

        /// <summary>
        /// Displays the help window for the user. 
        /// </summary>
        public void HandleHelpEvent()
        {
            helpWindow hw = new helpWindow();
            hw.Show();
        }

        /// <summary>
        /// Calls the resetPeople method in the mainWindow to reset the people displayed. 
        /// </summary>
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
            string interests = windowAddPerson.Interests;
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

            //If the image folder doesnt exist then create it.
            if (!Directory.Exists(imageFolderPath))
            {
                Directory.CreateDirectory(imageFolderPath);
            }

            //Make a unique file name out of the given data. Also include a seed to account for the same name and age.
            string uniqueFilePath = windowAddPerson.FirstName + windowAddPerson.Lastname + windowAddPerson.Age + seed + ".jpg";
            string destFile = Path.Combine(imageFolderPath, uniqueFilePath);
            seed++;

            //COPY given file to destFile
            File.Copy(windowAddPerson.imagePath, destFile, true);
            
            //Setting file for the database to the destFile. 
            currentPerson.ImagePath = destFile;

            //Then reset the window for the next person. 
            HandleResetAddPersonEvent();

            //Add the person to the database.
            try
            {
                await addPerson(currentPerson);
            }
            catch(Exception)
            {
                windowAddPerson.showInAddPersonWindowMessage("Something went wrong when adding the person please try again.");
            }
        }

        /// <summary>
        /// Method to add the currentPerson information to the database. 
        /// </summary>
        /// <param name="newPerson"></param>
        /// <returns></returns>
        public async Task addPerson(Person newPerson)
        {
            //Adding person to DB. 
            using (var db = new PersonDBContext())
            {
                db.People.Add(newPerson);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// This method calls
        /// </summary>
        public void HandleCloseEvent()
        {
            window.closeWindow();
        }



        /// <summary>
        /// This method returns a list of people in the DB that have a matching first or last name. 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<List<Person>> personQuery(string name)
        {
            //List of people with the name. 
            List<Person> peopleList = new List<Person>();

            //DO QUEREY
            using (var context = new PersonDBContext())
            {
                // Query for all blogs with names starting with B 
                var query = from b in context.People
                            where b.FirstName.Trim().ToUpper() == name.Trim().ToUpper() ||
                            b.LastName.Trim().ToUpper() == name.Trim().ToUpper()
                            select b;

                foreach (var item in query)
                {
                    peopleList.Add(item);
                }
            }

            return peopleList;
        }

        //Does a query to search for people in the DB. 
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

                //Resets the window. 
                window.resetPeople();
            }
            //If there is atleast one person then show there given info. 
            else
            {
                window.showPeople(peopleList);
            }

        }

        /// <summary>
        /// This is the handler for when the AddPerson button is clicked in the File Menu. It will display the window. 
        /// </summary>
        public void HandleAddPersonEvent()
        {
            windowAddPerson.showWindow();
        }

        /// <summary>
        /// This is the handler for when the AddPerson button is closed. It will close the window. 
        /// </summary>
        public void HandleMainCloseAddPersonWindow()
        {
            windowAddPerson.closeWindow();
        }


        /// <summary>
        /// This is the handle for when the close button is clicked form the addPerson window. It will hide the window. 
        /// </summary>
        public void HandleAddPersonWindowCloseEvent()
        {
            windowAddPerson.hideWidndow();
        }
    }
}
