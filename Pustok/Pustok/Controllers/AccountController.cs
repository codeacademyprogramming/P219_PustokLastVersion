using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pustok.DAL;
using Pustok.Models;
using Pustok.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser admin = new AppUser
        //    {
        //        UserName = "SuperAdmin",
        //        FullName = "Hikmet Abbasov"
        //    };

        // passsword:admin123
        //    await _userManager.CreateAsync(admin,"admin123");
        //    await _userManager.AddToRoleAsync(admin, "Admin");

        //    return Ok();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(MemberRegisterModel registerModel)
        {
            if (!ModelState.IsValid) return View();

            AppUser existUser = await _userManager.FindByNameAsync(registerModel.UserName);

            if(existUser != null)
            {
                ModelState.AddModelError("UserName", "UserName already taken");
                return View();
            }

            AppUser user = new AppUser
            {
                FullName = registerModel.FullName,
                UserName = registerModel.UserName,
            };

            var result =  await _userManager.CreateAsync(user,registerModel.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Code);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(user, "Member");

            await _signInManager.SignInAsync(user, true);   

            return RedirectToAction("index","home");
        }

        public IActionResult Login()
        {   
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(MemberLoginModel loginModel)
        {
            AppUser user = await _userManager.FindByNameAsync(loginModel.UserName);

            if(user == null || user.IsAdmin)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.IsPersistent, true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect");
                return View();
            }

            return RedirectToAction("index", "home");
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login");
        }


        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Edit()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            MemberEditModel member = new MemberEditModel
            {
                Address = user.Address,
                ContactPhone = user.ContactPhone,
                FullName = user.FullName,
                UserName = user.UserName,
            };
            return View(member);
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MemberEditModel member)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            if(_userManager.Users.Any(x=>x.UserName == member.UserName && x.Id != user.Id))
            {
                ModelState.AddModelError("UserName", "UserName already taken!");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            user.UserName = member.UserName;
            user.FullName = member.FullName;
            user.ContactPhone = member.ContactPhone;
            user.Address = member.Address;


            if (!string.IsNullOrWhiteSpace(member.Password))
            {
                if (string.IsNullOrWhiteSpace(member.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPassword", "CurrentPassword can not be emtpy");
                    return View();
                }

                var result = await _userManager.ChangePasswordAsync(user, member.CurrentPassword, member.Password);
                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                    return View();
                }
            }
            await _userManager.UpdateAsync(user);

            await _signInManager.SignInAsync(user, true);
            return RedirectToAction("index", "home");
        }


    }
}
