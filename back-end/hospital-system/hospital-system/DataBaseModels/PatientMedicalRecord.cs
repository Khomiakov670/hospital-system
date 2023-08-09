using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_system.DataBaseModels
{
    internal class PatientMedicalRecord
    {
        public int medicalRecordId { get; set; }
        public int patientId { get; set; }
        public int doctorId { get; set; }
        public string symptoms { get; set; }
        public string status  { get; set; }
        public string diagnosis { get; set; }
        public DateTime dateOfOpen { get; set; }
        public DateTime dateOfClose { get; set; }
        public int treatmentId { get; set; } 
    }
}
