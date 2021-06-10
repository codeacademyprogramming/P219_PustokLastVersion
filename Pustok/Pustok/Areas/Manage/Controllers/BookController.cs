using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.DAL;
using Pustok.Helpers;
using Pustok.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("manage")]
    public class BookController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BookController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.Books.Count() / 5m);

            List<Book> books = _context.Books.Include(x=>x.Author).Skip((page-1)*5).Take(5).ToList();

            return View(books);
        }

        public IActionResult Create()
        {
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Tags = _context.Tags.ToList();

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Book book)
        {
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Tags = _context.Tags.ToList();


            if (!_context.Authors.Any(x=>x.Id == book.AuthorId))
            {
                ModelState.AddModelError("AuthorId", "Xeta var!");
            }

            if(!_context.Categories.Any(x=>x.Id == book.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "Xeta var!");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            if(book.PosterPhoto != null)
            {
                if (book.PosterPhoto.ContentType != "image/png" && book.PosterPhoto.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PosterPhoto", "Mime type yanlisdir!");
                    return View();
                }

                if (book.PosterPhoto.Length > (1024 * 1024) * 2)
                {
                    ModelState.AddModelError("PosterPhoto", "Faly olcusu 2MB-dan cox ola bilmez!");
                    return View();
                }

                string filename = FileManager.Save(_env.WebRootPath, "uploads", book.PosterPhoto);

                BookImage bookImage = new BookImage
                {
                    Book = book,
                    IsHoverPoster = false,
                    IsPoster = true,
                    Name = filename
                };

                _context.BookImages.Add(bookImage);
            }

            if (book.HoverPosterPhoto != null)
            {
                if (book.HoverPosterPhoto.ContentType != "image/png" && book.HoverPosterPhoto.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("HoverPosterPhoto", "Mime type yanlisdir!");
                    return View();
                }

                if (book.HoverPosterPhoto.Length > (1024 * 1024) * 2)
                {
                    ModelState.AddModelError("HoverPosterPhoto", "Faly olcusu 2MB-dan cox ola bilmez!");
                    return View();
                }

                string filename = FileManager.Save(_env.WebRootPath, "uploads", book.HoverPosterPhoto);

                BookImage bookImage = new BookImage
                {
                    Book = book,
                    IsHoverPoster = true,
                    IsPoster = false,
                    Name = filename
                };

                _context.BookImages.Add(bookImage);
            }

            if (book.Photos != null)
            {
                foreach (var photo in book.Photos)
                {
                    if (photo.ContentType != "image/png" && photo.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("photos", "Mime type yanlisdir!");
                        return View();
                    }

                    if (photo.Length > (1024 * 1024) * 2)
                    {
                        ModelState.AddModelError("photos", "Faly olcusu 2MB-dan cox ola bilmez!");
                        return View();
                    }

                    string filename = FileManager.Save(_env.WebRootPath, "uploads", photo);

                    BookImage bookImage = new BookImage
                    {
                        Book = book,
                        IsHoverPoster = false,
                        IsPoster = false,
                        Name = filename
                    };

                    _context.BookImages.Add(bookImage);
                }

            }


            if (book.DiscountPercent > 0)
            {
                book.DicountedPrice = book.Price * (100 - book.DiscountPercent) / 100;
            }
            book.CreatedAt = DateTime.UtcNow;

            if(book.TagIds != null)
            {
                foreach (var tagId in book.TagIds)
                {
                    BookTag bookTag = new BookTag
                    {
                        Book = book,
                        TagId = tagId
                    };
                    //book.BookTags.Add(bookTag);
                    _context.BookTags.Add(bookTag);
                }
            }
           

            _context.Books.Add(book);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Book book = _context.Books.Include(x=>x.BookTags).Include(x=>x.BookImages).FirstOrDefault(x => x.Id == id);

            if (book == null) return RedirectToAction("index");

            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Tags = _context.Tags.ToList();

            return View(book);
        }

        [ValidateAntiForgeryToken]  
        [HttpPost]
        public IActionResult Edit(int id, Book book)
        {
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Tags = _context.Tags.ToList();

            Book existBook = _context.Books.Include(x=>x.BookImages).FirstOrDefault(x => x.Id == id);

            if (existBook == null) return RedirectToAction("index");

            if (!_context.Authors.Any(x => x.Id == book.AuthorId)) return RedirectToAction("index");

            if (!_context.Categories.Any(x => x.Id == book.CategoryId)) return RedirectToAction("index");




            existBook.Name = book.Name;
            existBook.DiscountPercent = book.DiscountPercent;
            existBook.Price = book.Price;
            existBook.ProducingPrice = book.ProducingPrice;
            existBook.Subtitle = book.Subtitle;
            existBook.Desc = book.Desc;
            existBook.Code = book.Code;
            existBook.IsAvailable = book.IsAvailable;
            existBook.IsNew = book.IsNew;
            existBook.IsFeatured = book.IsFeatured;
            existBook.CategoryId = book.CategoryId;
            existBook.AuthorId = book.AuthorId;

            if (book.DiscountPercent>0)
            {
                existBook.DicountedPrice = existBook.Price * (100 - book.DiscountPercent) / 100;
            }
            else
            {
                existBook.DicountedPrice = 0;
            }

            if (book.PosterPhoto != null)
            {
                if (book.PosterPhoto.ContentType != "image/png" && book.PosterPhoto.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PosterPhoto", "Mime type yanlisdir!");
                    return View(existBook);
                }

                if (book.PosterPhoto.Length > (1024 * 1024) * 2)
                {
                    ModelState.AddModelError("PosterPhoto", "Faly olcusu 2MB-dan cox ola bilmez!");
                    return View(existBook);
                }

                string filename = FileManager.Save(_env.WebRootPath, "uploads", book.PosterPhoto);

                BookImage poster = _context.BookImages.FirstOrDefault(x => x.BookId == id && x.IsPoster);

                if (poster != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads", poster.Name);

                    poster.Name = filename;
                }
                else
                {
                    poster = new BookImage
                    {
                        BookId = id,
                        IsHoverPoster = false,
                        IsPoster = true,
                        Name = filename
                    };

                    _context.BookImages.Add(poster);
                }
            }
            else if(book.PosterId == null)
            {
                BookImage poster = _context.BookImages.FirstOrDefault(x => x.BookId == id && x.IsPoster);

                if(poster != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads", poster.Name);
                    _context.BookImages.Remove(poster);
                }
            }

            if(book.Photos != null)
            {
                foreach (var item in book.Photos)
                {
                    if (item.ContentType != "image/png" && item.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("PosterPhoto", "Mime type yanlisdir!");
                        return View(book);
                    }

                    if (item.Length > (1024 * 1024) * 2)
                    {
                        ModelState.AddModelError("PosterPhoto", "Faly olcusu 2MB-dan cox ola bilmez!");
                        return View(book);
                    }

                    string filename = FileManager.Save(_env.WebRootPath, "uploads", item);

                    BookImage poster = new BookImage
                    {
                        BookId = id,
                        IsHoverPoster = false,
                        IsPoster = false,
                        Name = filename
                    };

                    _context.BookImages.Add(poster);
                    
                }

            }

            List<BookImage> existBookIds = _context.BookImages.Where(b => b.BookId == book.Id && !b.IsHoverPoster && !b.IsPoster).ToList();

            foreach (var item in existBookIds)
            {
                if (!book.PhotoIds.Contains(item.Id))
                {
                    _context.BookImages.Remove(item);
                }
            }

            var existTags = _context.BookTags.Where(x => x.BookId == id).ToList();

            if(book.TagIds != null)
            {
                foreach (var tagId in book.TagIds)
                {
                    var existTag = existTags.FirstOrDefault(x => x.TagId == tagId);
                    if (existTag == null)
                    {
                        BookTag bookTag = new BookTag
                        {
                            BookId = id,
                            TagId = tagId
                        };
                        _context.BookTags.Add(bookTag);
                    }
                    else
                    {
                        existTags.Remove(existTag);
                    }
                }

            }

            _context.BookTags.RemoveRange(existTags);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Bilinmedik bir xeta bas verdi");
                return View(existBook);
            }

            return RedirectToAction("index");
        }
    }
}
