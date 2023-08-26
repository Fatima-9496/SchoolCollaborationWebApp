using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.Models
{
    public class AssignmentSubmission
    {
        [Key]
        public int SubmissionId { get; set; }
        //public int AssignmentId { get; set; }
        [ForeignKey("AppUser")]
        public string StudentId { get; set; }
        [ForeignKey("Assignment")]
        public int AssignmentId { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string? SubmissionText { get; set; }
        public string? SubmissionFileUrl { get; set; }
        //[Range(1, 100)]
        //public int score { get; set; }
        public Assignment? Assignment { get; set; }
        public AppUser AppUser { get; set; }
        public bool IsSubmitted { get; set; }
    }
}
