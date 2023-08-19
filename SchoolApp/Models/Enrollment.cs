using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }

        public int StudentId { get; set; }
        public Course? Course { get; set; }
    }
}
