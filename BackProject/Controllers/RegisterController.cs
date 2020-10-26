using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackProject.Extentions;
using BackProject.Helpers;
using BackProject.Models;
using BackProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackProject.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RegisterController(UserManager<AppUser> userManager, SignInManager<AppUser> signManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signManager = signManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("index", "home");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegisterVM register)
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("index", "home");

            if (!ModelState.IsValid)
            {
                return View(register);
            }
            AppUser user = new AppUser()
            {
                Name = register.Name,
                Surname = register.Surname,
                UserName = register.Username,
                PhoneNumber = register.PhoneNumber,
                Email = register.Email,
                Activeted = true
            };
            IdentityResult identityResult = await _userManager.CreateAsync(user, register.Password);

            if (!identityResult.Succeeded)
            {
                ModelState.GetAllErrors(identityResult);
                return View(register);
            }
            await _userManager.AddToRoleAsync(user, Helper.Roles.Member.ToString());
            await _signManager.SignInAsync(user, register.RememberMe);
            return RedirectToAction("index", "home");
        }
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("index", "home");
            await _signManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        /* public async Task CreateRole()
            {
                if (!await _roleManager.RoleExistsAsync("Admin"))
                    await _roleManager.CreateAsync(new IdentityRole()
                    {
                        Name = "Admin"
                    });
                if (!await _roleManager.RoleExistsAsync("Member"))
                {
                    await _roleManager.CreateAsync(new IdentityRole()
                    {
                        Name = "Member"
                    });
                }
                if (!await _roleManager.RoleExistsAsync("courseModerator"))
                {
                    await _roleManager.CreateAsync(new IdentityRole()
                    {
                        Name = "courseModerator"
                    });
                }
                if (!await _roleManager.RoleExistsAsync("MainAdmin"))
                {
                    await _roleManager.CreateAsync(new IdentityRole()
                    {
                        Name = "MainAdmin"
                    });
                }

            }*/
    }
}