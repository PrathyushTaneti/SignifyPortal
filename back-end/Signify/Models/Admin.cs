using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signify.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(30, ErrorMessage = "Email ID is too long")]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        [MinLength(10, ErrorMessage = "User Name Should Be In 10 to 20 Characters")]
        [MaxLength(20, ErrorMessage = "User Name Should Be In 10 to 20 Characters")]
        public string UserName { get; set; } = string.Empty;
    }
}
