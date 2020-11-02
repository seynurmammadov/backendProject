using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BackProject.DAL;
using BackProject.Extentions;
using BackProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackProject.Areas.courses_admin.Controllers
{
    [Area("courses-admin")]
    [Authorize(Roles = "Admin,MainAdmin,coursesAdmin")]
    public class AccountSettings : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public AccountSettings(UserManager<AppUser> userManager, AppDbContext context, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            AppUser user =await  _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(AppUser user)
        {

            if (!ModelState.IsValid) return View(user);

            AppUser userDb = await _context.Users.Where(u=>u.UserName==User.Identity.Name).FirstOrDefaultAsync();
            if(userDb==null) return View(user);

            userDb.Name = user.Name;
            userDb.Surname = user.Surname;
            userDb.PhoneNumber = user.PhoneNumber;
            userDb.Email = user.Email;

            if (user.Photo != null)
            {
                if (!user.Photo.PhotoValidate(ModelState)) return View(user);

                string folder = Path.Combine("site", "img", "users");
                string fileName = await user.Photo.SaveImage(_env.WebRootPath, folder);

                userDb.Image = fileName;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
   
}
