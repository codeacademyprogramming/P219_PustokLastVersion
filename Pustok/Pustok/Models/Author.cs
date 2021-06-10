using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Models
{
    public class Author:BaseEntity
    {
        [Required(ErrorMessage = "FullName mecburidir!")]
        [StringLength(maximumLength:25,ErrorMessage = "Max uzunluq 25 ola biler!")]
        public string FullName { get; set; }

        [StringLength(maximumLength:500, ErrorMessage = "Max uzunluq 500 ola biler!")]
        public string Desc { get; set; }
        public bool? IsDeleted { get; set; }

        [StringLength(maximumLength:100)]
        public string Photo { get; set; }

        [NotMapped]
        public IFormFile PhotoFile { get; set; }

        public List<Book> Books { get; set; }
        public List<AuthorFeature> AuthorFeatures { get; set; }
    }
}
