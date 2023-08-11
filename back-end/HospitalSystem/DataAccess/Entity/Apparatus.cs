using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Apparatus : Entity
    {
        public virtual Tenant Tenant { get; set; } = null!;
        public int TenantId { get; set; }
    }
}
