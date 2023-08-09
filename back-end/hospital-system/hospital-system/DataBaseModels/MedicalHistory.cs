using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_system.DataBaseModels
{
    internal class MedicalHistory
    {
        public int medicalHistoryId { get; set; }
        public int patientId { get; set; }
        public int medicalRecordId  { get; set; }
    }
}
