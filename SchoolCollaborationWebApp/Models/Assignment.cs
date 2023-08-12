using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolCollaborationWebApp.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }
        [StringLength(20, MinimumLength = 3)]
        public string AssignmentTitle { get; set;}
        [StringLength(50)]
        public string AssignmentDescription { get; set;}
        [RegularExpression(@"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}$", ErrorMessage = "Invalid date and time format (YYYY-MM-DD HH:mm:ss)")]
        public DateTime Deadline { get; set;}
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<AssignmentSubmission> AssignmentSubmissions { get; set; }

    }
}
