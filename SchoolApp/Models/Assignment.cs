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
        [Display(Name = "Assignment Title")]
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 20 characters.")]
        public string AssignmentTitle { get; set; }
        [Display(Name = "Assignment Description")]
        public string? AssignmentDescription { get; set; }
        [Display(Name = "Dead Line")]
        [Required]
        public DateTime? Deadline { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
        public string? ATearcherId { get; set; }
        public string? AssignmentDocFile { get; set; }
        [NotMapped]
        [Display(Name = "Assignment File")]
        public IFormFile? AssignmentFile { get; set; }
        public AppUser? AppUser { get; set; }
        public ICollection<AssignmentSubmission>? AssignmentSubmissions { get; set; }

    }
}
/*using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolApp.Models;

namespace SchoolApp.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 20 characters.")]
        public string AssignmentTitle { get; set; }
        [Display(Name = "Assignment Description")]
        public string? AssignmentDescription { get; set; }
        [Required]
        [Display(Name = "Dead line")]
        public DateTime? Deadline { get; set; }
        [ForeignKey("Course")]
        [Required]
        public int? CourseId { get; set; }
        [Display(Name = "Course Name")]
        public Course? Course { get; set; }
        public String? ATearcherId { get; set; }
        public string? AssignmentDocFile { get; set; }
        [NotMapped]
        [Display(Name = "Assignment File")]
        public IFormFile? AssignmentFile { get; set; }
        public AppUser? AppUser { get; set; }
        public ICollection<AssignmentSubmission>? AssignmentSubmissions { get; set; }

    }
}
*/