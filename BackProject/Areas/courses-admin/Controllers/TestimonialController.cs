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

namespace BackProject.Areas.courses_admin.Controllers
{
    [Area("courses-admin")]
    [Authorize(Roles = "Admin,MainAdmin")]
    public class TestimonialController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHostingEnvironment _env;

        public TestimonialController(AppDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.TestimonialSections.ToList());
        }
        public IActionResult Create()
        {
            if (_context.TestimonialSections.Count() >= 5) return RedirectToAction(nameof(Index));
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TestimonialSection testimonial)
        {
            if (!ModelState.IsValid) return View(testimonial);

            if (_context.TestimonialSections.Count() >= 5)
            {
                ModelState.AddModelError("Photos", "You can show only 5 testimonial");
                return View(testimonial);
            }

            if (!testimonial.Photo.PhotoValidate(ModelState)) return View(testimonial);

            string folder = Path.Combine("site", "img", "testimonial");
            string fileName = await testimonial.Photo.SaveImage(_env.WebRootPath, folder);

            testimonial.Image = fileName;

            await _context.TestimonialSections.AddRangeAsync(testimonial);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            TestimonialSection testimonial = await _context.TestimonialSections.FindAsync(id);
            if (testimonial == null) return NotFound();
            return View(testimonial);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, TestimonialSection testimonial)
        {

            if (id == null) return NotFound();
            TestimonialSection testimonialDb = await _context.TestimonialSections.FindAsync(id);
            if (testimonialDb == null) return NotFound();
            if (!ModelState.IsValid) return View(testimonialDb);

            if (testimonial.Photo != null)
            {
                if (!testimonial.Photo.PhotoValidate(ModelState)) return View(testimonialDb);
                string folder = Path.Combine("site", "img", "testimonial");
                string fileName = await testimonial.Photo.SaveImage(_env.WebRootPath, folder);
                testimonialDb.Image = fileName;
            }
            testimonialDb.Name = testimonial.Name;
            testimonialDb.Surname = testimonial.Surname;
            testimonialDb.Position = testimonial.Position;
            testimonialDb.ShortDescription = testimonial.ShortDescription;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            if (_context.TestimonialSections.Count() < 2) return Json("You should have 1 notice");
            TestimonialSection testimonialDb = await _context.TestimonialSections.FindAsync(id);
            if (testimonialDb == null) return NotFound();
            _context.TestimonialSections.Remove(testimonialDb);
            await _context.SaveChangesAsync();
            return Json("Deleted");
        }
    }
}
