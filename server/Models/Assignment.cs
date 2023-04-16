namespace Signify.Models
{
    public class Assignment
    {
        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "Invalid ID")]
        public int Id { get; set; }


        [Required(ErrorMessage = "Missing Assignment Link")]
        public string ProgramLink { get; set; } = string.Empty;


        [Required(ErrorMessage = "Missing Assignment Name")]
        public string ProgramName { get; set; } = string.Empty;
    }
}
