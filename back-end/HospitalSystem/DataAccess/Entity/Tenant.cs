using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Tenant: Entity
    {
        public virtual Apparatus? Apparatus { get; set; }
        public int? ApparatusId { get; set; }
        public virtual Ward Ward { get; set; } = null!;
        public int WardId { get; set; }
    }
}
