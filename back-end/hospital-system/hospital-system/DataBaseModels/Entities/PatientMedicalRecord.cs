using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_system.DataBaseModels.Entities
{
   
    public class PatientMedicalRecord
    {
        [Key]
        public int medicalRecordId { get; set; }
        [ForeignKey(nameof(Patient))]
        public int patientId { get; set; }
        public Patient patient { get; set; }
        [ForeignKey(nameof(Doctor))]
        public int doctorId { get; set; }
        public Doctor doctor { get; set; }
        public string symptoms { get; set; }
        public string status { get; set; }
        public string? diagnosis { get; set; }
        public DateTime dateOfOpen { get; set; }
        public DateTime? dateOfClose { get; set; }
    }
}
