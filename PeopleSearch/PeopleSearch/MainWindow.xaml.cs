using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PeopleSearch
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {


        public class PeopleTest
        {

            //displaying at least name, address, age, interests, and a picture
            public string firstName { get; set; }
            public string lastName { get; set; }
        }

        public MainWindow()
        {   
            InitializeComponent();
            IAddPersonWindow addPersonWindow = new addPersonWindow();
            new PeopleSearchController(this,addPersonWindow);

            //Test init = new Test();
            //init.FirstName = new TextBox();
            //init.LastName = new TextBox();
            //init.Age = new TextBox();

            //init.FirstName.Text = "swag";
            //init.LastName.Text = "yung";
            //init.Age.Text = "15";
            PeopleModel tester = new PeopleModel();
            tester.firstName = "yo";
            tester.lastName = "swag";

            List<PeopleModel> x = new List<PeopleModel>();
            x.Add(new PeopleModel() { firstName = "swag", lastName = "yellow" ,imagePath = @"C:\Users\Stone\Pictures\zucchini-1.jpg",address = "395 East Odell lane",age = 3,interests = "playing fun wiht my frineds /n i love to jump \n in the mud"});
            this.listView.ItemsSource = x;
        }

        public event Action CloseEvent;
        public event Action<string> SearchEvent;
        public event Action addPersonEvent;
        public event Action ResetEvent;
        public event Action HelpEvent;

        //Closes the main window. 
        public void closeWindow()
        {
            this.Close();

        }

        /// <summary>
        /// This method will display a message to the user. 
        /// </summary>
        /// <param name="msg"></param>
        public void showMessageMain(string msg)
        {
            MessageBox.Show(msg);
        }


        /// <summary>
        /// This method sets the listViews source to the current peopleList.
        /// </summary>
        /// <param name="peopleList"></param>
        public void showPeople(List<PeopleModel> peopleList)
        {
            listView.ItemsSource = peopleList;
        }

        /// <summary>
        /// This method resets the people in the listView. 
        /// </summary>
        public void resetPeople()
        {
            listView.ItemsSource = null;
        }

        private void CloseMenu_Click(object sender, RoutedEventArgs e)
        {
            if (CloseEvent != null)
            {
                CloseEvent();
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if(SearchEvent != null)
            {
                SearchEvent(SearchText.Text);
            }
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            if(addPersonEvent != null)
            {
                addPersonEvent();
            }
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            if(resetButton != null)
            {
                ResetEvent();
            }
        }

        private void HelpMenu_Click(object sender, RoutedEventArgs e)
        {
            if(HelpEvent != null)
            {
                HelpEvent();
            }
        }
    }
}
