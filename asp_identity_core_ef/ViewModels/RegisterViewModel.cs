using System;
using System.ComponentModel.DataAnnotations;

namespace asp_identity_core_ef.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string FName { get; set; }

        [Required]
        public string LName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}
