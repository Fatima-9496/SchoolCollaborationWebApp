using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Course Name")]
        //[Required]
        public string? CourseName { get; set; }
        [Display(Name = "Course Description")]
        public string? CourseDescription { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        public string? CourseDocFile { get; set; }
        [NotMapped]
        [Display(Name = "Course File")]
        [Required]
        public IFormFile? CourseFile { get; set; }
        [ForeignKey("AppUser")]
        public string? CTearcherId { get; set; }
        public AppUser? AppUser { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }
        public ICollection<Assignment> Assignments { get; set; }

    }
}
/*[Key]
        public int CourseId { get; set; }
        [StringLength(20, MinimumLength = 3)]
        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        [Display(Name = "Course Description")]
        public string? CourseDescription { get; set; }
        [Display(Name = "Start Date")]
        [Required]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string CourseDocFile { get; set; }
        [NotMapped]
        [Display(Name = "Course File")]
        [Required]
        public IFormFile CourseFile { get; set; }
        [ForeignKey("AppUser")]
        public string? CTearcherId { get; set; }
        public AppUser? AppUser { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }
        public ICollection<Assignment> Assignments { get; set; }*/