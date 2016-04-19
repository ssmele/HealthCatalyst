///By: Salvatore Stone Mele
///4/19/16

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PeopleSearch
{
    /// <summary>
    /// Interface to determmine which methods, events, and variables a addPersonWindow should have. 
    /// </summary>
    public interface IAddPersonWindow
    {
        //Events
        event Action CloseEventAddPerson;
        event Action AddPersonEvent;
        event Action ResetAddPersonEvent;

        //Methods
        void showWindow();
        void hideWidndow();
        void closeWindow();
        void resetWindowImage();
        void showInAddPersonWindowMessage(string msg);

        //Variables
        string FirstName { get; set; }
        string Lastname { get; set; }
        string Address { get; set; }
        int Age { get; set; }
        string Interests { get; set; }
        string imagePath { get; set; }
        Image imageObject { set; }
    }
}
