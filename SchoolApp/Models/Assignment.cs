using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }
        //[StringLength(20, MinimumLength = 3)]
        public string AssignmentTitle { get; set; }
        //[StringLength(50)]
        public string AssignmentDescription { get; set; }
        public DateTime? Deadline { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<AssignmentSubmission>? AssignmentSubmissions { get; set; }

    }
}
