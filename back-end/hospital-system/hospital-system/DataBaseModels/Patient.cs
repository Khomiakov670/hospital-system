using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_system.DataBaseModels
{
    internal class Patient
    {
        public int declarationNumber { get; set; }
        public string fullName { get; set; }
        public string sex { get; set; }
        public string phoneNumber { get; set; }
        public DateTime dayOfBirth { get; set; }
    }
}
