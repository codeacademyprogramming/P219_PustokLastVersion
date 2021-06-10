using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Models
{
    public class Slider:BaseEntity
    {
        [Required]
        [StringLength(maximumLength:100)]
        public string Image { get; set; }

        [StringLength(maximumLength:100)]
        public string Title { get; set; }

        [StringLength(maximumLength:250)]
        public string Subtitle { get; set; }

        [StringLength(maximumLength:10)]
        public string Price { get; set; }

        [StringLength(maximumLength:250)]
        public string RedirectUrl { get; set; }
        public int Order { get; set; }
    }
}
