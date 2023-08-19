using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models
{
    public class Announcement
    {
        [Key]
        public int AnnouncementId { get; set; }
        //[StringLength(20, MinimumLength = 3)]
        public string AnnouncementTitle { get; set; }
        //[StringLength(50)]
        public string AnnouncementDescription { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
