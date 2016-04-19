///By: Salvatore Stone Mele
///4/19/16

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearch;

namespace PeopleSearchTests
{
    [TestClass]
    public class MainWindowTests
    {

        [TestMethod]
        public void TestMethod1()
        {
            AddPersonWindowStub stub1 = new AddPersonWindowStub();
            MainWindowStub stub = new MainWindowStub();
            PeopleSearchController controller = new PeopleSearchController(stub, stub1);

            stub.closeWindow();
            
        }
    }
}
