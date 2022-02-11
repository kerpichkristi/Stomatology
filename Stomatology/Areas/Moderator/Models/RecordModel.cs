using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stomatology.Areas.Moderator.Models
{
    [Table("RecordsTB")]
    public class Record
    {
        [Key]
        public int RecordID { get; set; }

        [Required(ErrorMessage = "Enter First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; } 

        [Required(ErrorMessage = "Enter Phone Number")]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter Address")]
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(200)]
        public string Info { get; set; }
        public Dentist Dentist { get; set; }
        public Procedure Procedure { get; set; }

        [Required(ErrorMessage = "Enter Date Of Visit")]
        public DateTime Date { get; set; }
        public bool Subscribe { get; set; }


    }
}
