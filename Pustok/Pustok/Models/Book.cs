using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Pustok.Models
{
    public class Book:BaseEntity
    {
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        [Required]
        [StringLength(maximumLength:150)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength:20)]
        public string Code { get; set; }

        [StringLength(maximumLength: 250)]
        public string Subtitle { get; set; }

        [StringLength(maximumLength: 1500)]
        public string Desc { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ProducingPrice { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountPercent { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DicountedPrice { get; set; }
        public double Rate { get; set; }
      
        public bool IsAvailable { get; set; }

        public bool IsNew { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime CreatedAt { get; set; }

        [NotMapped]
        public IFormFile PosterPhoto { get; set; }
        [NotMapped]
        public int? PosterId { get; set; }
        [NotMapped]
        public IFormFile HoverPosterPhoto { get; set; }
        [NotMapped]
        public List<IFormFile> Photos { get; set; }
        [NotMapped]
        public List<int> PhotoIds { get; set; }

        [NotMapped]
        public List<int> TagIds { get; set; }

        public Category Category { get; set; }
        public Author Author { get; set; }
        public List<BookImage> BookImages { get; set; }
        public List<BookTag> BookTags { get; set; }

        public List<BookComment> BookComments { get; set; }
    }
}
