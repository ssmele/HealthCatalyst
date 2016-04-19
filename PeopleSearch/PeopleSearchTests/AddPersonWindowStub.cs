///By: Salvatore Stone Mele
///4/19/16

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleSearch;
using System.Windows.Controls;

namespace PeopleSearchTests
{
    class AddPersonWindowStub : IAddPersonWindow
    {
        public string Address
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public System.Windows.Controls.Image imageObject
        {
            set
            {
                throw new NotImplementedException();
            }
        }

        public string imagePath
        {
            get;
            set;
        }

        public string Interests
        {
            get;
            set;
        }

        public string Lastname
        {
            get;
            set;
        }

        public event Action AddPersonEvent;
        public event Action CloseEventAddPerson;
        public event Action ResetAddPersonEvent;

        public void closeWindow()
        {
            throw new NotImplementedException();
        }

        public void hideWidndow()
        {
            throw new NotImplementedException();
        }

        public void resetWindowImage()
        {
            throw new NotImplementedException();
        }

        public void showInAddPersonWindowMessage(string msg)
        {
            throw new NotImplementedException();
        }

        public void showWindow()
        {
            throw new NotImplementedException();
        }
    }
}
