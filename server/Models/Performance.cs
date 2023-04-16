namespace Signify.Models
{
    public class Performance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RollNumber { get; set; } = string.Empty;

        [Required]
        public string PerformanceOfStudent { get; set; } = string.Empty;

        [Required]
        public string QuizName { get; set; } = string.Empty;
    }
}
