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
        public MainWindow()
        {
            InitializeComponent();
            IAddPersonWindow addPersonWindow = new addPersonWindow();
            new PeopleSearchController(this,addPersonWindow);
            List<string> x = new List<string>();
            //x.Add("swag");
            //x.Add("yo");
            //x.Add("swag");
            //x.Add("yo");
            //x.Add("swag");
            //x.Add("yo");
            //x.Add("swag");
            //x.Add("yo");
            //x.Add("swag");
            //x.Add("yo");
            //x.Add("swag");
            //x.Add("yo");
            //x.Add("swag");
            //x.Add("yo");
            //x.Add("swag");
            //x.Add("yo");
            //PeopleModel d = new PeopleModel();
            //d.address = "swag";
            //d.age = 3;
            //d.firstName = "stone";
            //d.lastName = "mele";
            //d.interests = "cool stuff";
            //x.Add(d);
            //x.Add(d);
            //x.Add(d);
            this.peopleListBox.ItemsSource = x;
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
