using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolApp.Models;

namespace SchoolApp.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }
        //[StringLength(20, MinimumLength = 3)]
        public string? AssignmentTitle { get; set; }
        //[StringLength(50)]
        public string? AssignmentDescription { get; set; }
        public DateTime? Deadline { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
        public string? CourseIds { get; set; }
        public String? ATearcherId { get; set; }
        public string? AssignmentMaterial { get; set; }
        public string? AssignmentDocFile { get; set; }
        [NotMapped]
        [Display(Name = "Announcement File")]
        public IFormFile? AssignmentFile { get; set; }
        public AppUser? AppUser { get; set; }
        public ICollection<AssignmentSubmission>? AssignmentSubmissions { get; set; }

    }
}
