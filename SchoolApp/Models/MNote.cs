using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace SchoolApp.Models
{
    public class MNote
    {
        public int Id { get; set; }
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }
        public string? Content { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [ForeignKey("AppUser")]
        public string? StudentId { get; set; }

        public AppUser? AppUser { get; set; }   
    }
}
