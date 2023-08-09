using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_system.DataBaseModels
{
    internal class Tenant
    {
        public int tenantId { get; set; }
        public int patientId { get; set; }
        public int wardId { get; set; }
    }
}
