using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Models
{
    public class BookImage:BaseEntity
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(maximumLength:100)]
        public string Name { get; set; }
        public bool IsPoster { get; set; }
        public bool IsHoverPoster { get; set; }

        public Book Book { get; set; }
    }
}
