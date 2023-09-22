using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.Models
{
    public class Announcement
    {
        [Key]
        public int AnnouncementId { get; set; }
        [Display(Name = "Announcement Title")]
        [StringLength(50, MinimumLength = 5)]
        [Required]
        public string AnnouncementTitle { get; set; }
        [Display(Name = "Announcement Description")]
        public string? AnnouncementDescription { get; set; }
        [Display(Name = "Post Date")]
        public DateTime? PostDate { get; set; }        
        [Display(Name = "Announcement Photo")]
        public string? AnnouncementPhoto { get; set; }
        [Display(Name = "Announcement Author")]
        [StringLength(40, MinimumLength = 5)]
        [Required]
        public string AnnouncementAuthor { get; set; }
        public string? AnnouncementDocFile { get; set; }
        [NotMapped]
        [Display(Name = "Announcement File")]
        public IFormFile? AnnouncementFile { get; set; }
        [ForeignKey("AppUser")]
        public String? AnnTearcherId { get; set; }
        public AppUser? AppUser { get; set; }       
    }
}
