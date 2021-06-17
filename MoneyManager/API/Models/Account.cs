using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Account")]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Password should not be empty"), DataType(DataType.Password)]
        public string Password { get; set; }

        public User User { get; set; }
    }
}
