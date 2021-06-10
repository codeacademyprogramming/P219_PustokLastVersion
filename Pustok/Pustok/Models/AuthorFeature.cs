using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Models
{
    public class AuthorFeature:BaseEntity
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public Author Author { get; set; }
    }
}
