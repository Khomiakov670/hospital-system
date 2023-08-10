using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_system.DataBaseModels.Entities
{
    public class Treatment
    {
        [Key]
        public int treatmentId { get; set; }
        public string? medicines { get; set; }
        public string? procedures { get; set; }
        public string? recommendations { get; set; }
    }
}
