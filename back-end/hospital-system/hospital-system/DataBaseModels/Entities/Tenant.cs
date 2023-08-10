using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_system.DataBaseModels.Entities
{
    public class Tenant
    {
        [Key]
        public int tenantId { get; set; }
        [ForeignKey(nameof(Patient))]
        public int patientId { get; set; }
        [ForeignKey(nameof(Ward))]
        public int wardId { get; set; }
    }
}
