using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebNetCoreWithReact.Models
{
    [Table("Daprt")]
    public class Daprt
    {
        [Key]
        [Required]
        public int DepartNumber { get; set; }

        [MaxLength(50)]
        public string Departname { get; set; }

        [MaxLength(50)]
        public string Locations { get; set; }
    }
}
