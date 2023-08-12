using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolCollaborationWebApp.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }
        public int CourseId { get; set;}
        
        public int StudentId { get; set; }
        public Course? Course { get; set; }
        [ForeignKey("StudentId")]
        public User? User { get; set; }
    }
}
