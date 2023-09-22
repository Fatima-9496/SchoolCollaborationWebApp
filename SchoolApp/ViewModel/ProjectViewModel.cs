using SchoolApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.ViewModel
{
    public class ProjectViewModel
    {
        [Key]
        public int ProjectId { get; set; }

        //[StringLength(20, MinimumLength = 3)]
        public string ProjectTitle { get; set; }

        //[StringLength(60)]
        public string ProjectDescription { get; set; }
        public DateTime DateCompleted { get; set; }
        public IFormFile? MediaUrl { get; set; }
        [ForeignKey("AppUser")]
        public String? StudentId { get; set; }

        public AppUser? AppUser { get; set; }
        
    }
}
