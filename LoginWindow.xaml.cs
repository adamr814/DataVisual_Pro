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

namespace DataVisual_Pro
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private List<User> users = new List<User>
        {
            new User {Username = "admin", Password = "admin123" },
            new User {Username = "instructor", Password = "instructor123" },
            new User {Username = "student", Password = "student123" },
        };
    
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string enteredUsername = _UsernameBox.Text;
            string enteredPassword = _PasswordBox.Password;

            //Validating credentials against list
            if (ValidateCredentials(enteredUsername, enteredPassword))
            {
                DialogResult = true;
                Close();
            }
            //show message here if it does not work on the app.xaml.cs
        }

        private bool ValidateCredentials(string username, string password)
        {
            return users.Any(user => user.Username == username && user.Password == password);
        }
    }

    public class User
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
