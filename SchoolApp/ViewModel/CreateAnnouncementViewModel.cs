using SchoolApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.ViewModel
{
    public class CreateAnnouncementViewModel
    {
        [Key]
        public int AnnouncementId { get; set; }
        public string AnnouncementTitle { get; set; }
        public string? AnnouncementDescription { get; set; }
        public DateTime? PostDate { get; set; }
        public IFormFile? AnnouncementPhoto { get; set; }
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
