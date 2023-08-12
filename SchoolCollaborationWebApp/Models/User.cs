using System.ComponentModel.DataAnnotations;

namespace SchoolCollaborationWebApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "User Name")]
        [StringLength(30)]
        public string Username { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public bool  IsTeacher { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<AssignmentSubmission> AssignmentSubmissions { get; set; }
        public ICollection<TestSubmission> TestSubmissions { get; set; }


    }
}
