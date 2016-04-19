///By: Salvatore Stone Mele
///4/19/16

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

        /// <summary>
        /// Sets up the window. and calls constructor for two windows. 
        /// </summary>
        public MainWindow()
        {   
            //Setting up controller. 
            InitializeComponent();
            //Setting up constructor for controller. 
            IAddPersonWindow addPersonWindow = new addPersonWindow();
            new PeopleSearchController(this,addPersonWindow);
            //Starting the gridView to an empty list. 
            List<Person> x = new List<Person>();
        }

        //Events
        public event Action CloseEvent;
        public event Action<string> SearchEvent;
        public event Action addPersonEvent;
        public event Action ResetEvent;
        public event Action HelpEvent;
        public event Action SearchTextPressed;

        /// <summary>
        /// Gettter and setter for the search textBox. 
        /// </summary>
        public string SearchTextBox
        {
            get
            {
                return SearchText.Text;
            }
            set
            {
                SearchText.Text = value;
            }
        }


        /// <summary>
        /// Closes the main window. 
        /// </summary>
        public void closeWindow()
        {
            this.Close();

        }

        /// <summary>
        /// This method will display a message to the user. 
        /// </summary>
        /// <param name="msg">Message intended for the user. </param>
        public void showMessageMain(string msg)
        {
            MessageBox.Show(msg);
        }


        /// <summary>
        /// This method sets the listViews source to the current peopleList.
        /// </summary>
        /// <param name="peopleList"></param>
        public void showPeople(List<Person> peopleList)
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

        /// <summary>
        /// This method fires the CloseEvent() when the close button is clicked. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseMenu_Click(object sender, RoutedEventArgs e)
        {
            if (CloseEvent != null)
            {
                CloseEvent();
            }
        }

        /// <summary>
        /// THis method fires when the Search button is clicked. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if(SearchEvent != null)
            {
                SearchEvent(SearchText.Text);
            }
        }

        /// <summary>
        /// THis method fires when the addPerson is clicked in the file Menu. 
        /// </summary>
        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            if(addPersonEvent != null)
            {
                addPersonEvent();
            }
        }


        /// <summary>
        /// This method fires when the reset button is clicked. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            if(resetButton != null)
            {
                ResetEvent();
            }
        }

        /// <summary>
        /// This method fires when the help button is clicked. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpMenu_Click(object sender, RoutedEventArgs e)
        {
            if(HelpEvent != null)
            {
                HelpEvent();
            }
        }

        /// <summary>
        /// This method fires when the searchButton is actually clicked. It will clear the text if its the first click to it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchText_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if(SearchTextPressed != null)
            {
                SearchTextPressed();
            }
        }
    }
}
