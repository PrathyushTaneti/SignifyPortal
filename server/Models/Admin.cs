namespace Signify.Models
{
    public class Admin
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(30, ErrorMessage = "Email ID is too long")]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        [MinLength(6, ErrorMessage = "User Name Should Be In 10 to 20 Characters")]
        [MaxLength(20, ErrorMessage = "User Name Should Be In 10 to 20 Characters")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
