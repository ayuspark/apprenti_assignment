using System;
using System.ComponentModel.DataAnnotations;

namespace asp_candyman.Models
{
    public class UserRegister : BaseEntity
    {
        [Required]
        [MinLength(1)]
        [MaxLength(8)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Letters only.")]
        [Display(Name = "First Name")]
        public string FName { get; set; }
        
        [Required]
        [MinLength(1)]
        [MaxLength(8)]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Letters only.")]
        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [MinLength(4)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(4)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password must match.")]
        public string ConfirmPass { get; set; }
    }


    public class UserLogin : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string LoginEmail { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string LoginPassword { get; set; }   
    }


    public class IndexPage : BaseEntity
    {
        public UserLogin LoginDisplay { get; set; }
        public UserRegister RegisterDisplay { get; set; }
    }
}
