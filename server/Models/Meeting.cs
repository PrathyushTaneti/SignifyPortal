namespace Signify.Models
{
    public class Meeting
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string JoinLink { get; set; } = string.Empty;

        [Required]
        public string Subject { get; set; } = string.Empty;

        [Required]
        public DateTime StartTime { get; set; }
    }
}
