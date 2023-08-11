using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Record : Entity
    {
        public virtual Patient Patient { get; set; } = null!;
        public int PatientId { get; set; }
        public virtual Doctor Doctor { get; set; } = null!;
        public int DoctorId { get; set; }
        public virtual Treatment? Treatment { get; set; }
        public int? TreatmentId { get; set; }
        public virtual Tenant? Tenant { get; set; }
        public int? TenantId { get; set; }

    }
}
