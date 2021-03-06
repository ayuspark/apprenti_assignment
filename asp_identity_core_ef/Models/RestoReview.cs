using System;
using System.ComponentModel.DataAnnotations;

namespace asp_identity_core_ef.Models
{
    public class RestoReview
    {
        [Key]
        public int RestoReviewId { get; set; }
        public string ReviewContent { get; set; }
        public DateTime Created { get; set; }
        public int RestoId { get; set; }
        public string ApplicationUserEmail { get; set; }
    }
}