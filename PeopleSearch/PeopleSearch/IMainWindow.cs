using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch
{
    public interface IMainWindow
    {

        event Action<string> SearchEvent;
        event Action addPersonEvent;
        event Action CloseEvent;
        event Action ResetEvent;
        event Action HelpEvent;
        event Action SearchTextPressed;


        void closeWindow();
        void resetPeople();
        void showPeople(List<Person> peopleList);
        void showMessageMain(string msg);

        string SearchTextBox { get; set; }

    }
}
