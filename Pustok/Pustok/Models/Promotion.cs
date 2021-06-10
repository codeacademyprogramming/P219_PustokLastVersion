using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Models
{
    public class Promotion:BaseEntity
    {
        [StringLength(maximumLength:100)]
        public string Title { get; set; }

        [StringLength(maximumLength: 100)]
        public string SubTitle { get; set; }


        [StringLength(maximumLength: 250)]
        public string RedirectUrl { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public string Image { get; set; }

        public bool LocationStatus { get; set; }
    }
}
