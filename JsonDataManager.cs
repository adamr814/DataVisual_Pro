using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace DataVisual_Pro
{
    public class JsonDataManager
    {
        private string dataFolderPath = "PatientData";
        private string fileExtension = ".json";

        public JsonDataManager()
        {
            Directory.CreateDirectory(dataFolderPath); //Ensures that there is a directory to save the files to
        }
        public void SavePatientData(Patient patient)
        {
            string fileName = GetFileName(patient.MRN);
            string filePath = Path.Combine(dataFolderPath, fileName);

            string jsonData = JsonConvert.SerializeObject(patient);
            File.WriteAllText(filePath, jsonData);
        }

        public Patient LoadPatientData(string mrn)
        {
            string fileName = GetFileName(mrn);
            string filePath = Path.Combine(dataFolderPath, fileName);

            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Patient>(jsonData);
            }

            return null; //Handles the case where data is not found
        }

        private string GetFileName(string mrn)
        {
            return $"{mrn}{fileExtension}";
        }
    }
}
    