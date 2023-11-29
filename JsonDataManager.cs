using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace DataVisual_Pro
{
    public class JsonDataManager
    {
        private static string dataDirectory = "PatientData";        

        public JsonDataManager()
        { //Ensures that there is a directory to save the files to
            if (!Directory.Exists(dataDirectory))
            {
                Directory.CreateDirectory(dataDirectory);
            }            
        }
        public void SavePatientData(Patient patient)
        {
            try
            {
                string filePath = Path.Combine(dataDirectory, $"{patient.MRN}.json");

                string jsonData = JsonConvert.SerializeObject(patient, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        public Patient LoadPatientData(string mrn)
        {            
            string filePath = Path.Combine(dataDirectory, $"{mrn}.json");

            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Patient>(jsonData);
            }

            return null; //Handles the case where data is not found
        }
        
        public static void InitializePatientData(string mrn)
        { 
            string filePath = Path.Combine(dataDirectory, $"{mrn}.json");
            try
            {
                if (!Directory.Exists(dataDirectory))
                {
                    Directory.CreateDirectory(dataDirectory);
                }
                if (!File.Exists(filePath))
                {
                    string emptyData = "{}";
                    File.WriteAllText(filePath, emptyData);
                }                
            }
            catch (IOException ex)
            {                
                MessageBox.Show("An error occurred while initializing patient data:\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (UnauthorizedAccessException ex)
            {                
                MessageBox.Show("You don't have permission to create the patient data file:\n" + ex.Message, "Permission Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {                
                MessageBox.Show("An error occurred:\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }    
}
    