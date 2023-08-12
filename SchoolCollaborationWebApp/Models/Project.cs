using System.ComponentModel.DataAnnotations;

namespace SchoolCollaborationWebApp.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public int StudentId { get; set; }
        [StringLength(20, MinimumLength = 3)]
        public string ProjectTitle { get; set; }
        [RegularExpression(@"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}$", ErrorMessage = "Invalid date and time format (YYYY-MM-DD HH:mm:ss)")]
        public DateTime DateCompleted { get; set; }
        [StringLength(60)]
        public string ProjectDescription { get; set; }
        [RegularExpression(@"^(file:///([A-Za-z]:/|/)(?:[^/\\:*?""<>|]+/)*[^/\\:*?""<>|]+(?:\.\w{1,6})?)$", ErrorMessage = "Invalid local file path")]
        public string MediaUrl { get; set;} 
        
        public User User { get; set; }
    }
}
