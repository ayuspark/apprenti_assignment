using System;
using System.ComponentModel.DataAnnotations;

namespace asp_candyman.Models
{
    public abstract class BaseEntity { }

    public class Quote : BaseEntity
    {
        [Required]
        [MinLength(1)]
        [MaxLength(140)]
        public string QuoteContent { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(8)]
        public string Name { get; set; }
    }
}
