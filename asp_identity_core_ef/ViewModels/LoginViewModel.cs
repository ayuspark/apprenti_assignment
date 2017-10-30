using System;
using System.ComponentModel.DataAnnotations;

namespace asp_identity_core_ef.ViewModels
{
    public class LoginViewModel
    {
        [Required, DataType(DataType.Password), MinLength(4), MaxLength(50)]
        public string Password { set; get; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
