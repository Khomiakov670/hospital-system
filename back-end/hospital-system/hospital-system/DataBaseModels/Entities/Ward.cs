using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_system.DataBaseModels.Entities
{
    public class Ward
    {
        [Key]
        public int wardNumber { get; set; }
        public int floor { get; set; }
        public string type { get; set; }
    }
}
