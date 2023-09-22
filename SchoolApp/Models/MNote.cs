using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.Models
{
    public class MNote
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedDate { get; set; }
        [ForeignKey("AppUser")]
        public string? StudentId { get; set; }

        public AppUser? AppUser { get; set; }   
    }
}
