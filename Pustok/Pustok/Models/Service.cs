using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Models
{
    public class Service:BaseEntity
    {
        [Required]
        [StringLength(maximumLength:100)]
        public string Title { get; set; }

        [StringLength(maximumLength: 100)]
        public string SubTitle { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string Icon { get; set; }

        public int Order { get; set; }
    }
}
