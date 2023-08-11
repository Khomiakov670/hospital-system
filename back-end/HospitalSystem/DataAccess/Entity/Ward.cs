using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Ward : Entity
    {
        public virtual List<Tenant> Tenants { get; set; } = null!;
    }
}
