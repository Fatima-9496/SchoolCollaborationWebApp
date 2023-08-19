using System.ComponentModel.DataAnnotations;

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
        public string ImageMediaUrl { get; set; }
        public string VideoMediaUrl { get; set; }


    }
}
