using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models
{
    public class AppUser : IdentityUser
    {

        //[Required]
        [Display(Name = "User Name")]
        [StringLength(30)]
        public string? AppUsername { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? AppUserEmail { get; set; }
        [DataType(DataType.Password)]
        public string? AppUserPassword { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public string? AppUserConfirmPassword { get; set; }
        
    }
}
