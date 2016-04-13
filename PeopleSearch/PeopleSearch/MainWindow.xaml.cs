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


    public class Test
    {
        public TextBox FirstName { get; set; }
        public TextBox LastName { get; set; }
        public TextBox Age { get; set; }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {



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
            tester.age = 0;
            tester.address = "swag";
            tester.firstName = "yo";
            tester.lastName = "swag";

            List<PeopleModel> x = new List<PeopleModel>();
            x.Add(tester);

            this.listView.ItemsSource = x;
        }

        public event Action CloseEvent;
        public event Action SearchEvent;
        public event Action addPersonEvent;

        //Closes the main window. 
        public void closeWindow()
        {
            this.Close();

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
                SearchEvent();
            }
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            if(addPersonEvent != null)
            {
                addPersonEvent();
            }
        }
    }
}
