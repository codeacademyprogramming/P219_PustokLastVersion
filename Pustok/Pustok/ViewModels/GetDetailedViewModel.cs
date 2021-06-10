using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.ViewModels
{
    public class GetDetailedViewModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Subtitle { get; set; }
        public Category Category { get; set; }
        public bool IsAvailable { get; set; }
        public double Rate { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DicountedPrice { get; set; }
        public List<BookTag> BookTags { get; set; }
        public string PosterName { get; set; }
        public Author Author { get; set; }
    }
}
