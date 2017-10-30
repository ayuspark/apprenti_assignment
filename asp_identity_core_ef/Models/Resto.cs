using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace asp_identity_core_ef.Models
{
    public class Resto
    {
        [Key]
        public int RestoId { get; set; }
        public string Name { get; set; }
        public List<RestoReview> Reviews { get; set; }
        public Resto()
        {
            Reviews = new List<RestoReview>();
        }
    }
}