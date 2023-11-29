using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataVisual_Pro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private JsonDataManager _dataManager = new JsonDataManager();
        private List<Patient> patients;

        public MainWindow()
        {
            InitializeComponent();
            _dataManager = new JsonDataManager();
        }

        private void InitalizeData()
        {
            patients = _dataManager.LoadPatientData();
        }

        private void SaveData()
        {
            _dataManager.SavePatientData(patients);
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
            ((App)Application.Current).ShowLoginWindow();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveData();
        }

        private void MRNSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string enteredMRN = _MRNBox.Text;
            Patient existingPatient = patients.FirstOrDefault(p =>p.MRN == enteredMRN);

            if (existingPatient != null)
            {
                ShowPatientFoundMessage();
            }
            else
            {
                if (MessageBox.Show("Patient not found. Do you want to initialize a new patient?", "Initilization", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    InitializeNewPatient();
                }
            }
        }

        private void ShowPatientFoundMessage()
        {
            _patientFoundTextBlock.Visibility = Visibility.Visible;
            Task.Delay(3000).ContinueWith(_ =>
            {
               Dispatcher.Invoke(() => _patientFoundTextBlock.Visibility = Visibility.Collapsed);
            }, TaskScheduler.FromCurrentSynchronizationContext() );
        }

        private void InitializeNewPatient()
        {
            _patientFoundTextBlock.Text = "Patient Initialized";
            ShowPatientFoundMessage();
            SaveData();
        }

        private void CheckBox1_Checked(object sender, RoutedEventArgs e)
        {
            if (_CheckBox1.IsChecked == true)
            {
                _CheckBox2.IsChecked = false;
                _CheckBox3.IsChecked = false;
            }
        }
        private void CheckBox2_Checked(object sender, RoutedEventArgs e)
        {
            if (_CheckBox2.IsChecked == true)
            {
                _CheckBox1.IsChecked = false;
            }
        }
        private void CheckBox3_Checked(object sender, RoutedEventArgs e)
        {
            if (_CheckBox3.IsChecked == true)
            {
                _CheckBox1.IsChecked= false;
            }
        }
        private void CheckBox4_Checked(object sender, RoutedEventArgs e)
        {
            if (_CheckBox4.IsChecked == true)
            {
                _CheckBox7.IsChecked = false;
            }
        }
        private void CheckBox5_Checked(object sender, RoutedEventArgs e)
        {
            if (_CheckBox5.IsChecked == true)
            {
                _CheckBox7.IsChecked = false;
            }
        }
        private void CheckBox6_Checked(object sender, RoutedEventArgs e)
        {
            if (_CheckBox6.IsChecked == true)
            {
                _CheckBox7.IsChecked = false;
            }
        }
        private void CheckBox7_Checked(object sender, RoutedEventArgs e) //this is the standard isolation button
        {
            if (_CheckBox7.IsChecked == true)
            {
                _CheckBox4.IsChecked = false;
                _CheckBox5.IsChecked = false;
                _CheckBox6.IsChecked = false;
            }
        }
    }
}