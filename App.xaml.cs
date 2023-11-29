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
        private static MainWindow? mainWindow = null;
        
        public static MainWindow? MainWindow
        {
            get { return mainWindow; } set { mainWindow = value; }
        }
        public App()
        {
            InitializeComponent();
            mainWindow = new MainWindow();
            mainWindow.Visibility = Visibility.Hidden;
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ShowLoginWindow();
        }
        internal void ShowLoginWindow()
        {
            while (true)
            {
                var loginWindow = new LoginWindow();
                if (loginWindow.ShowDialog() == true)
                {
                    try
                    {
                        if (mainWindow != null)
                        {
                            mainWindow.Visibility = Visibility.Visible;
                        }
                        loginWindow.Close();
                        break;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error in MainWindow: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Login failed. Please Try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    mainWindow.Close();
                    loginWindow.Close();
                }
            }
        }
    }
}
