using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleSearch;

namespace PeopleSearchTests
{
    class MainWindowStub : IMainWindow
    {
        public string SearchTextBox
        {
            get; set;
        }

        public event Action addPersonEvent;
        public event Action CloseEvent;
        public event Action HelpEvent;
        public event Action ResetEvent;
        public event Action<string> SearchEvent;
        public event Action SearchTextPressed;

        public void closeWindow()
        {
            throw new NotImplementedException();
        }

        public void resetPeople()
        {
            throw new NotImplementedException();
        }

        public void showMessageMain(string msg)
        {
            throw new NotImplementedException();
        }

        public void showPeople(List<Person> peopleList)
        {
            throw new NotImplementedException();
        }
    }
}
