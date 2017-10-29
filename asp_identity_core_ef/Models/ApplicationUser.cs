using System;
using Microsoft.AspNetCore.Identity;

namespace asp_identity_core_ef.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime Birthday { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
    }
}