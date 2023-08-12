using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolCollaborationWebApp.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [StringLength(20, MinimumLength = 3)]
        public string CourseName { get; set; }
        [StringLength(50)]
        public string CourseDescription { get; set; }
        [RegularExpression(@"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}$", ErrorMessage = "Invalid date and time format (YYYY-MM-DD HH:mm:ss)")]
        public DateTime StartDate { get; set; }
        [RegularExpression(@"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}$", ErrorMessage = "Invalid date and time format (YYYY-MM-DD HH:mm:ss)")]
        public DateTime EndDate { get; set; }
        public int TeacherId {get; set; }
        public User User { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<Test> Tests { get; set; }
        

    }
}
