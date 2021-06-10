using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.DAL;
using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]

    public class TagController : Controller
    {
        private readonly AppDbContext _context;
        public TagController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling((_context.Tags.Count()/5m));

            List<Tag> tags = _context.Tags.Include(x=>x.BookTags).Skip((page - 1) * 5).Take(5).ToList();

            return View(tags);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tag tag)
        {
            if (!ModelState.IsValid) return View();

            if(_context.Tags.Any(x=>x.Name.ToLower() == tag.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "This tag already created");
                return View();
            }

            _context.Tags.Add(tag);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Tag tag = _context.Tags.FirstOrDefault(x => x.Id == id);

            if (tag == null)
                return RedirectToAction("index");

            return View(tag);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (Tag tag,int id)
        {
            if (!ModelState.IsValid) return View();

            Tag existTag = _context.Tags.FirstOrDefault(x => x.Id == id);

            if (existTag == null) return RedirectToAction("index");

            if(_context.Tags.Any(x=>x.Id != id && x.Name.ToLower() == tag.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "This tag already created");
                return View();
            }

            existTag.Name = tag.Name;
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Tag existTag = _context.Tags.FirstOrDefault(x => x.Id == id);

            if (existTag == null) return Json(new { IsSucceed = false });

            _context.Remove(existTag);
            _context.SaveChanges();

            return Json(new { IsSucceed = true});
        }


    }
}
