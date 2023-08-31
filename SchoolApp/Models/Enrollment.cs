using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        [ForeignKey("AppUser")]
        public String? StudentId { get; set; }
        public Course? Course { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
