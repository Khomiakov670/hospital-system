using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_system.DataBaseModels.Entities
{
    public class Treatment_Record
    {
        [ForeignKey(nameof(Treatment))]
        public int TreatmentId { get; set; }
        public Treatment treatment { get; set; }
        [ForeignKey(nameof(PatientMedicalRecord))]
        public int recordId { get; set; }
        public PatientMedicalRecord record { get; set; }
    }
}
