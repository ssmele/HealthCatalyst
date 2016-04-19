using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PeopleSearch
{
    interface IAddPersonWindow
    {
        event Action CloseEventAddPerson;
        event Action AddPersonEvent;
        event Action ResetAddPersonEvent;

        void showWindow();
        void hideWidndow();
        void closeWindow();
        void resetWindow();
        void showInAddPersonWindowMessage(string msg);


        string FirstName { get; set; }
        string Lastname { get; set; }
        string Address { get; set; }
        int Age { get; set; }
        string interests { get; set; }
        string imagePath { get; set; }
        Image imageObject { set; }
    }
}
