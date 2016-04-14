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
using System.Windows.Shapes;
using Microsoft.Win32;

//TODO: GET DATABASE WORKING, Add REset to addperson window. Make sure reset of addperson keeps default picture. 

namespace PeopleSearch
{
    /// <summary>
    /// Interaction logic for addPersonWindow.xaml
    /// </summary>
    public partial class addPersonWindow : Window, IAddPersonWindow
    {
        public string imagePath
        {
            get;
            set;
        }


        public string FirstName
        {
            get
            {
                return fnTextBox.Text;
            }

            set
            {
                fnTextBox.Text = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lnTextBox.Text;
            }

            set
            {
                lnTextBox.Text = value;
            }
        }

        public string Address
        {
            get
            {
                return addressTextBox.Text;
            }

            set
            {
                addressTextBox.Text = value;
            }
        }

        public int Age
        {
            get
            {
                int age;
                if(int.TryParse(ageTextBox.Text, out age) == true)
                {
                    return age;
                }
                return 0;
            }

            set
            {
                ageTextBox.Text = value.ToString();
            }
        }

        public string interests
        {
            get
            {
                return intTextBox.ToString();
            }

            set
            {
                intTextBox.Document.Blocks.Clear();
            }
        }

        public Image imageObject
        {
            set
            {
                this.image.Source = null;
            }
        }

        public addPersonWindow()
        {
            InitializeComponent();

            //Sets default image. 
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(@"C:\Users\Stone\Source\Repos\HealthCatalyst\PeopleSearch\PeopleSearch\images\facebook-default-no-profile-pic.jpg");
            myBitmapImage.DecodePixelWidth = 200;
            myBitmapImage.EndInit();
            this.image.Source = myBitmapImage;
        }

        public event Action CloseEventAddPerson;
        public event Action AddPersonEvent;

        public void hideWidndow()
        {
            this.Hide();
        }

        public void showWindow()
        {
            this.Show();
        }

        public void closeWindow()
        {
            this.Close();
        }

        private void CloseMenu_Click(object sender, RoutedEventArgs e)
        {
            if(CloseEventAddPerson != null)
            {
                CloseEventAddPerson();
            }
        }

        private void fileDialogButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".jpeg";
            dialog.Filter = "Image (.jpg)| *.jpg";
            dialog.ShowDialog();

            imagePath = dialog.FileName;
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(dialog.FileName);
            myBitmapImage.DecodePixelWidth = 200;
            myBitmapImage.EndInit();
            //set image source
            this.image.Source = myBitmapImage;
        }

        public void showInAddPersonWindowMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        private void addPersonButton_Click(object sender, RoutedEventArgs e)
        {
            if(AddPersonEvent != null)
            {
                AddPersonEvent();
            }
        }
    }
}
