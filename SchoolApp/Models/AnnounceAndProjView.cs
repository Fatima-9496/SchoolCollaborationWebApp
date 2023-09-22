using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models
{
    public class AnnounceAndProjView
    {
        [Key]
        public int AnprId { get; set; }
        public Announcement? Announcement { get; set; }
        public Project? Project { get; set; }
    }
}
