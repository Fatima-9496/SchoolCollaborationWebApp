using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models
{
    public class AppUser : IdentityUser
    {

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        [StringLength(30)]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        [StringLength(30)]
        public string? LastName { get; set; }
        
    }
}
