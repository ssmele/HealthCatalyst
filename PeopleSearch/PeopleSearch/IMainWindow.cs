using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch
{
    interface IMainWindow
    {

        event Action<string> SearchEvent;
        event Action addPersonEvent;
        event Action CloseEvent;
        event Action ResetEvent;
        event Action HelpEvent;
        void closeWindow();
        void resetPeople();

        void showPeople(List<PeopleModel> peopleList);

        void showMessageMain(string msg);
    }
}
