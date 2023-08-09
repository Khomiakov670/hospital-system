using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_system.DataBaseModels
{
    internal class Treatment
    {
        public int treatmentId { get; set; }
        public int medicalRecordId { get; set; }
        public string medicines { get; set; }
        public string procedures { get; set; }
        public string recommendations { get; set; }
    }
}
