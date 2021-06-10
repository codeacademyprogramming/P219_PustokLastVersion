using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.DAL;
using Pustok.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin")]

    public class AuthorController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AuthorController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {

            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Authors.Count() / 8d);

            List<Author> authors = _context.Authors.Include(x=>x.Books).Skip((page-1)*8).Take(8).ToList();
            return View(authors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            //Author author = new Author
            //{
            //    FullName = fullName,
            //    Desc = desc
            //};

            if(author.PhotoFile != null)
            {
                if (author.PhotoFile.ContentType != "image/png" && author.PhotoFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PhotoFile", "Mime type yanlisdir!");
                    return View();
                }

                if (author.PhotoFile.Length > (1024 * 1024) * 2)
                {
                    ModelState.AddModelError("PhotoFile", "Faly olcusu 2MB-dan cox ola bilmez!");
                    return View();
                }

                string rootPath = _env.WebRootPath;
                var filename = Guid.NewGuid().ToString() + author.PhotoFile.FileName;
                var path = Path.Combine(rootPath, "uploads", filename);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    author.PhotoFile.CopyTo(stream);
                }

                author.Photo = filename;
            }
           

            if (!ModelState.IsValid)
            {
                return View();
            }

            author.IsDeleted = false;
            _context.Authors.Add(author);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Author author = _context.Authors.FirstOrDefault(x => x.Id == id);

            if(author == null)
            {
                return RedirectToAction("index");
            }

            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(int id,Author author)
        {
            Author existAuthor = _context.Authors.FirstOrDefault(x => x.Id == id);

            if(existAuthor == null)
            {
                return RedirectToAction("index");
            }

            if(author.PhotoFile != null)
            {
                if (author.PhotoFile.ContentType != "image/png" && author.PhotoFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PhotoFile", "Mime type yanlisdir!");
                    return View();
                }

                if (author.PhotoFile.Length > (1024 * 1024) * 2)
                {
                    ModelState.AddModelError("PhotoFile", "Faly olcusu 2MB-dan cox ola bilmez!");
                    return View();
                }

                string filename = Guid.NewGuid().ToString() + author.PhotoFile.FileName;
                string path = Path.Combine(_env.WebRootPath, "uploads", filename);

                using(FileStream stream = new FileStream(path, FileMode.Create))
                {
                    author.PhotoFile.CopyTo(stream);
                }

                if(existAuthor.Photo != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads", existAuthor.Photo);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }

                existAuthor.Photo = filename;
            }
            else if(author.Photo == null)
            {
                if (existAuthor.Photo != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads", existAuthor.Photo);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }

                    existAuthor.Photo = null;
                }
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            existAuthor.FullName = author.FullName;
            existAuthor.Desc = author.Desc;

            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult Delete(int id)
        {
            Author author = _context.Authors.FirstOrDefault(x => x.Id == id);

            if (author == null) return Json(new { isSucceded = false });

            //List<Book> books = _context.Books.Where(x => x.AuthorId == id).ToList();
            //_context.Books.RemoveRange(books);

            //_context.Authors.Remove(author);

            author.IsDeleted = true;
            _context.SaveChanges();

            return Json(new {isSuccedded=true });
        }

        public IActionResult Restore(int id)
        {
            Author author = _context.Authors.FirstOrDefault(x => x.Id == id);

            if (author == null) return RedirectToAction("index");

            author.IsDeleted = false;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
