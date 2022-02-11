using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stomatology.Areas.Moderator.Models
{
    [Table("DentistsTB")]
    public class Dentist
    {
        [Key]
        public int DentistID { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [StringLength(50)]
        public string DentistName { get; set; }

        [Required(ErrorMessage = "Enter Age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        public ICollection<Procedure> Procedure { get; set; }
    }
}
