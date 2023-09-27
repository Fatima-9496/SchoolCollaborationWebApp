using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.Models
{
    public class AssignmentSubmission
    {
        [Key]
        public int SubmissionId { get; set; }
        //public int AssignmentId { get; set; }
        [ForeignKey("AppUser")]
        public string? StudentId { get; set; }
        [ForeignKey("Assignment")]
        public int? AssignmentId { get; set; }
        [Required]
        [Display(Name = "Submission Date")]
        public DateTime SubmissionDate { get; set; }
        [Display(Name = "Submission Text")]
        public string? SubmissionText { get; set; }
        [Display(Name = "Submission File")]
        public string? AnnouncementDocFile { get; set; }
        [NotMapped]
        [Display(Name = "Submission File")]
        public IFormFile? AnnouncementFile { get; set; }
        //[Range(1, 100)]
        //public int score { get; set; }
        public Assignment? Assignment { get; set; }
        public AppUser? AppUser { get; set; }        
    }
}
/*        [Key]
        public int SubmissionId { get; set; }
        //public int AssignmentId { get; set; }
        [ForeignKey("AppUser")]
        public string? StudentId { get; set; }
        [ForeignKey("Assignment")]
        public int? AssignmentId { get; set; }
        [Required]
        [Display(Name = "Submission Date")]
        public DateTime SubmissionDate { get; set; }
        [Display(Name = "Submission Text")]
        public string? SubmissionText { get; set; }
        public string? AnnouncementDocFile { get; set; }
        [NotMapped]
        [Display(Name = "Submission File")]
        public IFormFile? AnnouncementFile { get; set; }
        //[Range(1, 100)]
        //public int score { get; set; }
        public Assignment? Assignment { get; set; }
        public AppUser? AppUser { get; set; }*/