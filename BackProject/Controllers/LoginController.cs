using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackProject.Helpers;
using BackProject.Models;
using BackProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signManager;
        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("index", "home");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginVM login)
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("index", "home");

            if (!ModelState.IsValid) return View(login);

            AppUser user = await _userManager.FindByNameAsync(login.LogName);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(login.LogName);
                if (user == null)
                {
                    ModelState.AddModelError("", "Email or Password is Wrong");
                    return View(login);
                }
            }
            if (!user.Activeted)
            {
                ModelState.AddModelError("", "Your account is  Deactivatived!");
                return View(login);
            }
            var signInResult = await _signManager.PasswordSignInAsync(user, login.Password, login.RememberMe, true);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email or Password is Wrong");
                return View(login);
            }

            string role = (await _userManager.GetRolesAsync(user))[0];
            if (role == Helper.Roles.Member.ToString())
            {
                return RedirectToAction("index", "home");
            }
            else return RedirectToAction("index", "dashboard", new
            {
                area = "courses-admin"
            });

        }
    }
}