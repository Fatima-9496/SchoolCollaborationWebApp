using System.ComponentModel.DataAnnotations;

namespace SchoolCollaborationWebApp.Models
{
    public class TestSubmission
    {
        [Key]
        public int TestSubmissionId { get; set; }
        public int TestId { get; set; }
        public int CourseId { get; set; }
        [Range(1,100)]
        public int Score { get; set; }
        public User User { get; set; }
        public Test Test { get; set; }

    }
}
