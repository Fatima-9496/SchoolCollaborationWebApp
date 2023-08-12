using System.ComponentModel.DataAnnotations;

namespace SchoolCollaborationWebApp.Models
{
    public class Test
    {
        [Key]
        public int TestId { get; set; }
        public int CourseId { get; set;}
        [StringLength(20, MinimumLength = 3)]
        public string TestTitle { get; set; }
        [StringLength(50)]
        public string TestDescription { get; set; }
        [RegularExpression(@"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}$", ErrorMessage = "Invalid date and time format (YYYY-MM-DD HH:mm:ss)")]
        public DateTime TestStartTime { get; set; }
        [RegularExpression(@"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}$", ErrorMessage = "Invalid date and time format (YYYY-MM-DD HH:mm:ss)")]
        public DateTime  TestEndTime { get; set; }
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public Course Course { get; set;}

        public ICollection<TestSubmission> TestSubmissions { get; set; }

    }
}
