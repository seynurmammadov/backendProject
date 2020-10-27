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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackProject.Areas.courses_admin.Controllers
{
    [Area("courses-admin")]
    [Authorize(Roles = "Admin,MainAdmin")]
    public class AboutSectionController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHostingEnvironment _env;

        public AboutSectionController(AppDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.AboutSections.FirstOrDefault());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(AboutSection about)
        {

            if (!ModelState.IsValid) return View(about);
            AboutSection aboutDb = await _context.AboutSections.FirstOrDefaultAsync();
            if (aboutDb == null) return NotFound();

            if (aboutDb.Photo != null)
            {
                if (!aboutDb.Photo.PhotoValidate(ModelState)) return View(about);
                string folder = Path.Combine("site", "img", "about");
                string fileName = await about.Photo.SaveImage(_env.WebRootPath, folder);
                aboutDb.Image = fileName;
            }
            aboutDb.Title = about.Title;
            aboutDb.Description = about.Description;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
