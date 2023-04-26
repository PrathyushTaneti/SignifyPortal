namespace Signify.Models
{
    public class Attendance
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Date { get; set; } = string.Empty;

        [Required]
        public string Identity { get; set; } = string.Empty;

        [Required]
        public string Designation { get; set; } = string.Empty;
    }
}
