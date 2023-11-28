using System.Configuration;
using System.Data;
using System.Windows;

namespace DataVisual_Pro
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal void ShowLoginWindow()
        {
            while (true)
            {
                var loginWindow = new LoginWindow();
                if (loginWindow.ShowDialog() == true)
                {
                    var mainWindow = new MainWindow();
                    mainWindow.Show();

                    break;
                }
                else
                {
                    MessageBox.Show("Login failed. Please Try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ShowLoginWindow();            
        }
    }
}
