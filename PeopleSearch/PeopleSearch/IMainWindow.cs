///By: Salvatore Stone Mele
///4/19/16

using System;
using System.Collections.Generic;

namespace PeopleSearch
{
    /// <summary>
    /// THis interface determines what methods, variables, and events a mainWindow should have. 
    /// </summary>
    public interface IMainWindow
    {
        //Events
        event Action<string> SearchEvent;
        event Action addPersonEvent;
        event Action CloseEvent;
        event Action ResetEvent;
        event Action HelpEvent;
        event Action SearchTextPressed;

        //Methods
        void closeWindow();
        void resetPeople();
        void showPeople(List<Person> peopleList);
        void showMessageMain(string msg);

        string SearchTextBox { get; set; }

    }
}
