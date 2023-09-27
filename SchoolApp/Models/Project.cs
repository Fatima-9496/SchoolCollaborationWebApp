using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Display(Name = "Project Title")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 20 characters.")]
        [Required]
        public string ProjectTitle { get; set; }
        [Display(Name = "Project Description")]
        public string? ProjectDescription { get; set; }
        [Display(Name = "Date Completed")]
        [Required]
        public DateTime DateCompleted { get; set; }
        [Required]
        [Display(Name = "Project Area")]
        public string ProjectArea { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        [Display(Name = "Project Photo")]
        public IFormFile? ImageFile { get; set; }
        public string? MediaUrl { get; set; }
        [NotMapped]
        [Display(Name = "Project Document")]
        public IFormFile? PhotoFile { get; set; }
        [ForeignKey("AppUser")]
        public string? StudentId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
