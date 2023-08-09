using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_system.DataBaseModels
{
    internal class Ward
    {
        public int wardNumber { get; set; }
        public int floor { get; set; }
        public int patientId { get; set; }
        public string type { get; set; }
    }
}
