using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stomatology.Areas.Moderator.Models
{
    [Table("ProceduresTB")]
    public class Procedure
    {
        [Key]
        public int ProcedureID { get; set; }

        [Required(ErrorMessage = "required")]
        [StringLength(50)]
        public string ProcedureName { get; set; }
        [Required(ErrorMessage = "required")]
        public decimal Price { get; set; }
        [StringLength(200)]
        public string Info { get; set; }
        public Dentist Dentist { get; set; }
        public string Img { get; set; }
    }
}
