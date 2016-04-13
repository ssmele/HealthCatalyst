using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch
{
    interface IMainWindow
    {

        event Action SearchEvent;
        event Action addPersonEvent;
        event Action CloseEvent;
        void closeWindow();
    }
}
