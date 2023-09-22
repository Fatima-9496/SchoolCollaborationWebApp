using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        
        //[StringLength(20, MinimumLength = 3)]
        public string ProjectTitle { get; set; }
        
        //[StringLength(60)]
        public string ProjectDescription { get; set; }
        public DateTime DateCompleted { get; set; }
        public string ProjectArea { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        [Display(Name = "Photo")]
        public IFormFile? ImageFile { get; set; }
        public string? MediaUrl { get; set; }
        [NotMapped]
        [Display(Name = "Photo")]
        public IFormFile? PhotoFile { get; set; }
        [ForeignKey("AppUser")]
        public String? StudentId { get; set; }

        public AppUser? AppUser { get; set; }
        //public IFormFile? proMedia { get; set; }
       // public string FileType { get; set; }
    }
}
