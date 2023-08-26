using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models
{
    public class AssignmentSubmission
    {
        [Key]
        public int SubmissionId { get; set; }
        //public int AssignmentId { get; set; }
        public int UserId { get; set; }
        [RegularExpression(@"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}$", ErrorMessage = "Invalid date and time format (YYYY-MM-DD HH:mm:ss)")]
        public DateTime SubmissionDate { get; set; }
        public string SubmissionFileUrl { get; set; }
        [Range(1, 100)]
        public int score { get; set; }
        public Assignment Assignment { get; set; }
        public AppUser AppUser { get; set; }
    }
}
