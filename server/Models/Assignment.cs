namespace Signify.Models
{
    public class Assignment
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Missing Assignment Link")]
        public string ProgramLink { get; set; } = string.Empty;


        [Required(ErrorMessage = "Missing Assignment Name")]
        public string ProgramName { get; set; } = string.Empty;
    }
}
