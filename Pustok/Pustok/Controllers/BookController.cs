using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pustok.DAL;
using Pustok.Models;
using Pustok.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string search,int? categoryId,int page=1)
        {
            List<Book> books = new List<Book>();
            int totalCount;
            decimal totalPage;
            ViewBag.SelectedPage = page;
            ViewBag.Search = search;


            if (categoryId == null)
            {
                books = _context.Books
                      .Include(x => x.Author).Include(x => x.BookImages)
                      .Where(x=>string.IsNullOrWhiteSpace(search)?true:(x.Name.ToLower().Contains(search.ToLower())))
                    .Skip((page - 1) * 3).Take(3).ToList();


                totalCount = _context.Books.Where(x => string.IsNullOrWhiteSpace(search) ? true : (x.Name.ToLower().Contains(search.ToLower()))).Count();
               
            }
            else
            {
                books = _context.Books
                    .Include(x=>x.Author).Include(x=>x.BookImages)
                    .Where(x => string.IsNullOrWhiteSpace(search) ? true : (x.Name.ToLower().Contains(search.ToLower())))
                    .Where(x => x.CategoryId == categoryId).Skip((page - 1) * 3).Take(3).ToList();
                ViewBag.SelectedCategoryId = categoryId;
                totalCount = _context.Books.Where(x => string.IsNullOrWhiteSpace(search) ? true : (x.Name.ToLower().Contains(search.ToLower()))).Where(x => x.CategoryId == categoryId).Count();
            }


            totalPage = Math.Ceiling(totalCount / 3m);
            ViewBag.TotalPage = totalPage;

            return View(books);
        }
        public IActionResult Detail(int id)
        {
            Book book = _context.Books
                .Include(x=>x.BookImages)
                .Include(x=>x.BookTags).ThenInclude(x=>x.Tag)
                .Include(x=>x.Author).Include(x=>x.Category)
                .Include(x=>x.BookComments).ThenInclude(x=>x.AppUser)
                .FirstOrDefault(x => x.Id == id);

            ViewBag.TotalCommentPage = Math.Ceiling(book.BookComments.Count() / 2m);

            if(book == null)
            {
                return RedirectToAction("index");
            }

            BookDetailViewModel bookVM = new BookDetailViewModel
            {
                Book = book,
                RelatedBooks = _context.Books
                .Include(x=>x.BookImages).Include(x=>x.Author)
                .Where(x => x.CategoryId == book.CategoryId && x.Id != id).Take(5).ToList()
            };


            return View(bookVM);
        }
        public IActionResult AddBasket(int id)
        {
            //HttpContext.Session.SetString("bookName", "Dusunenler ve dusundurenler");
            //HttpContext.Response.Cookies.Append("name", "Qaranligin hekayesi");

            Book book = _context.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
                return Json(new { isSucceeded = false });


            //List<BasketItemViewModel> baskteItems = new List<BasketItemViewModel>();
            //BasketItemViewModel bookVM = new BasketItemViewModel
            //{
            //    Id = book.Id,
            //    Name = book.Name,
            //    Poster = book.BookImages.FirstOrDefault(x => x.IsPoster)?.Name,
            //    Code = book.Code,
            //    Price = book.DiscountPercent > 0 ? book.DicountedPrice : book.Price,
            //    Count = 1,
            //    TotalPrice = book.DiscountPercent > 0 ? book.DicountedPrice : book.Price
            //};

            List<BookBasketItem> bookBaskets = new List<BookBasketItem>();
            BookBasketItem bookBasketItem = new BookBasketItem
            {
                Id = book.Id,
                Count = 1
            };

            if (HttpContext.Request.Cookies["basket"] == null)
            {
                bookBaskets.Add(bookBasketItem);
            }
            else
            {
                bookBaskets = JsonConvert.DeserializeObject<List<BookBasketItem>>(HttpContext.Request.Cookies["basket"]);

                var existBasketItem = bookBaskets.FirstOrDefault(x => x.Id == book.Id);

                if (existBasketItem != null)
                {
                    existBasketItem.Count += 1;
                }
                else
                {
                    bookBaskets.Add(bookBasketItem);
                }
            }

            decimal totalPrice = 0;
            foreach (var item in bookBaskets)
            {
                Book bk = _context.Books.FirstOrDefault(x => x.Id == item.Id);
                decimal salePrice = bk.DiscountPercent > 0 ? bk.Price * (100 - bk.DiscountPercent) / 100 : bk.Price;
                totalPrice += salePrice * item.Count;
            }


            HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(bookBaskets, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));

            return Json(new { isSucceeded = true, totalPrice, totalCount=bookBaskets.Count() });    
        }
        public IActionResult ShowBasket()
        {
            //var bookName = HttpContext.Session.GetString("bookName");
            //var name = HttpContext.Request.Cookies["name"];

            var bookStr = HttpContext.Request.Cookies["basket"];
            List<BasketItemViewModel> book = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(bookStr);

            return Ok(book);
        }

        public IActionResult LoadBasket()
        {
            var bookStr = HttpContext.Request.Cookies["basket"];
            List<BookBasketItem> cookieBasketItems = JsonConvert.DeserializeObject<List<BookBasketItem>>(bookStr);

            List<BasketItemViewModel> basketItems = new List<BasketItemViewModel>();

            foreach (var item in cookieBasketItems)
            {
                Book book = _context.Books.Include(x=>x.BookImages).FirstOrDefault(x => x.Id == item.Id);
                BasketItemViewModel basketItem = new BasketItemViewModel
                {
                    Id = book.Id,
                    Count = item.Count,
                    Code = book.Code,
                    Name = book.Name,
                    Price = book.DiscountPercent > 0 ? book.Price * (100 - book.DiscountPercent) / 100 : book.Price,
                    Poster = book.BookImages.FirstOrDefault(x => x.IsPoster)?.Name
                };
                basketItem.TotalPrice = basketItem.Price * basketItem.Count;

                basketItems.Add(basketItem);
            }

            return PartialView("_BasketItems", basketItems);
        }



        [Authorize(Roles = "Member")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(BookComment comment)
        {
            if (!ModelState.IsValid) return RedirectToAction("index");

            Book book = _context.Books.Include(x=>x.BookComments).FirstOrDefault(x => x.Id == comment.BookId);

            if(book == null) return RedirectToAction("index");

            var user = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            comment.AppUserId = user.Id;

            if (_context.BookComments.Any(x => x.BookId == comment.BookId && x.AppUserId == user.Id))
            {
                return RedirectToAction("index");
            }

            double commentCount = book.BookComments.Count() +1;
             comment.CreatedAt = DateTime.UtcNow;
            _context.BookComments.Add(comment);

            book.Rate = Math.Ceiling((book.BookComments.Sum(x => x.Rate) + comment.Rate) / commentCount);

            _context.SaveChanges();

            return RedirectToAction("detail", new { id = comment.BookId });

        }


        public IActionResult LoadComment(int id,int page = 1)
        {
            List<BookComment> comments = _context.BookComments.Include(x=>x.AppUser).Where(x => x.BookId == id).OrderByDescending(x => x.CreatedAt).Skip((page - 1) * 2).Take(2).ToList();

            return PartialView("_BookComments", comments);
        }

      

    }
}
