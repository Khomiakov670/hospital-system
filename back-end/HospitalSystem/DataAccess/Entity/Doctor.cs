using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Doctor: User
    {
        public virtual List<Record> Records { get; set; }
    }
}
