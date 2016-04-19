///By: Salvatore Stone Mele
///4/19/16

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Windows.Documents;

//TODO:  ASYNC

namespace PeopleSearch
{
    /// <summary>
    /// Interaction logic for addPersonWindow.xaml
    /// </summary>
    public partial class addPersonWindow : Window, IAddPersonWindow
    {
        //Getters and setters for aspects of the addPersoWindow.

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
                //Ensures we have a number if not just set text box to zero so an error is thrown. 
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

        public string Interests
        {
            get
            {
                //Have to do some tricky stuff to get text out of richText Box. 
                string interestString = new TextRange(intTextBox.Document.ContentStart, intTextBox.Document.ContentEnd).Text;
                return interestString;
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


        /// <summary>
        /// This constructor initializes the window, and sets the default image.
        /// </summary>
        public addPersonWindow()
        {
            InitializeComponent();

            //Sets default image. 
            //BitmapImage myBitmapImage = new BitmapImage();
            //myBitmapImage.BeginInit();
            //myBitmapImage.UriSource = new Uri(@"C:\Users\Stone\Source\Repos\HealthCatalyst\PeopleSearch\PeopleSearch\images\facebook-default-no-profile-pic.jpg");
            //myBitmapImage.DecodePixelWidth = 200;
            //myBitmapImage.EndInit();
            this.image.Source = null;
        }

        /// <summary>
        /// Events available to fire for this window. 
        /// </summary>
        public event Action CloseEventAddPerson;
        public event Action AddPersonEvent;
        public event Action ResetAddPersonEvent;


        /// <summary>
        /// This method resets the default method. 
        /// </summary>
        public void resetWindowImage()
        {
            //BitmapImage myBitmapImage = new BitmapImage();
            //myBitmapImage.BeginInit();
            //myBitmapImage.UriSource = new Uri(@"C:\Users\Stone\Source\Repos\HealthCatalyst\PeopleSearch\PeopleSearch\images\facebook-default-no-profile-pic.jpg");
            //myBitmapImage.DecodePixelWidth = 200;
            //myBitmapImage.EndInit();
            this.image.Source = null; //myBitmapImage;
        }


        /// <summary>
        /// THis method simply hides the addPersonWindow.
        /// </summary>
        public void hideWidndow()
        {
            this.Hide();
        }

        /// <summary>
        /// This method simply opens the addPersonWindow.
        /// </summary>
        public void showWindow()
        {
            this.Show();
        }

        /// <summary>
        /// THis method clowses the window. 
        /// </summary>
        public void closeWindow()
        {
            this.Close();
        }

        /// <summary>
        /// Event that is fired when close is clicked.
        /// </summary>
        private void CloseMenu_Click(object sender, RoutedEventArgs e)
        {
            if(CloseEventAddPerson != null)
            {
                CloseEventAddPerson();
            }
        }

        /// <summary>
        /// Gets the image file and displays it in the image panel. 
        /// </summary>
        private void fileDialogButton_Click(object sender, RoutedEventArgs e)
        {
            //Open File dialog and get the result. 
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".jpeg";
            dialog.Filter = "Image (.jpg)| *.jpg";
            var result = dialog.ShowDialog();

            //Check to make sure image there before creating it. 
            if (result.Value == false)
            {
                return;
            }

            //Trys to display given image. If cant display message. 
            try
            {
                //If Image was there then format it and add it to the image source. 
                imagePath = dialog.FileName;
                BitmapImage myBitmapImage = new BitmapImage();
                myBitmapImage.BeginInit();
                myBitmapImage.UriSource = new Uri(dialog.FileName);
                myBitmapImage.DecodePixelWidth = 200;
                myBitmapImage.EndInit();
                //set image source
                this.image.Source = myBitmapImage;
            }
            catch(Exception)
            {
                this.showInAddPersonWindowMessage("Could not use given image please try again!");
            }
        }

        /// <summary>
        /// Display a message box to user from addPersonWindow. 
        /// </summary>
        /// <param name="msg"></param>
        public void showInAddPersonWindowMessage(string msg)
        {
            MessageBox.Show(msg);
        }


        /// <summary>
        /// This event is fired when the addPersonButton is clicked. 
        /// </summary>
        private void addPersonButton_Click(object sender, RoutedEventArgs e)
        {
            if(AddPersonEvent != null)
            {
                AddPersonEvent();
            }
        }

        /// <summary>
        /// This event is fired when the reset button is clicked. 
        /// </summary>
        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            if(ResetAddPersonEvent != null)
            {
                ResetAddPersonEvent();
            }
        }
    }
}