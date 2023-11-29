using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using JsonConverter = Newtonsoft.Json.JsonConverter;
using System.Windows;
using System.Security.Policy;

namespace DataVisual_Pro
{
    public class Patient
    {
        public string MRN {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial {  get; set; }
        public string Height {  get; set; }
        public string Weight {  get; set; }
        public string BirthDate { get; set; }
        public string Sex {  get; set; }
        public string Allergies { get; set; }
        public string Provider {  get; set; }
        public string Diagnosis { get; set; }
        public string CodeStatus { get; set; }
        public string IsolationStatus { get; set; }
        public string MedicalHistory {  get; set; }
        public string CurrentIllnessHistory { get; set; }
        public string SurgicalHistory {  get; set; }
        public string FamilyHealthHistory {  get; set; }
    }
}
