using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name should not be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email Should not be empty"), EmailAddress(ErrorMessage = "Email format is invalid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Gender should not be empty")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "BirthDate should not be empty"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0}:dd-MM-YYYY")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Phone Number should not be empty"), RegularExpression(@"^[08][0-9]{10,11}$", ErrorMessage = "Phone number should start with '08'"), MinLength(11, ErrorMessage = "Minimum 11 characters"), MaxLength(12, ErrorMessage = "Maximum 12 characters")]
        public string PhoneNumber { get; set; }

        public Account Account { get; set; }
        public Role Role { get; set; }
        public Transaction Transaction { get; set; }
    }
}
