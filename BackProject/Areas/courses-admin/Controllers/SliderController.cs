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
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace BackProject.Areas.courses_admin.Controllers
{
    [Area("courses-admin")]
    [Authorize(Roles = "Admin,MainAdmin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHostingEnvironment _env;

        public SliderController(AppDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Sliders.Where(s=> !s.IsDeleted).ToList());
        }
        public IActionResult Create()
        {
            if (_context.Sliders.Count() >= 5) return RedirectToAction(nameof(Index));
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sliders slider)
        {
            if (!ModelState.IsValid) return View(slider);

            if (_context.Sliders.Count() >= 5)
            {
                ModelState.AddModelError("Photos", "You can show only 5 slides");
                return View(slider);
            }

            if (!slider.Photo.PhotoValidate(ModelState)) return View(slider);

            string folder = Path.Combine("site", "img", "slider");
            string fileName = await slider.Photo.SaveImage(_env.WebRootPath, folder);

            slider.Image = fileName;
            slider.IsDeleted = false;

            await _context.Sliders.AddRangeAsync(slider);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Sliders slider = await _context.Sliders.Where(s => !s.IsDeleted && s.Id == id).FirstOrDefaultAsync();
            if (slider == null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Sliders slider)
        {
        
            if (id == null) return NotFound();
            Sliders sliderDb = await _context.Sliders.Where(s => !s.IsDeleted && s.Id == id).FirstOrDefaultAsync();
            if (sliderDb == null) return NotFound();
            if (!ModelState.IsValid) return View(sliderDb);

            if (slider.Photo != null)
            {
                if (!slider.Photo.PhotoValidate(ModelState)) return View(sliderDb);
                string folder = Path.Combine("site", "img", "slider");
                string fileName = await slider.Photo.SaveImage(_env.WebRootPath, folder);
                sliderDb.Image = fileName;
            }
            sliderDb.Title = slider.Title;
            sliderDb.ShortDescription = slider.ShortDescription;
            sliderDb.Activeted = slider.Activeted;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Status(int? id)
        {
            if (id == null) return NotFound();
            Sliders slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            if (_context.Sliders.Count(s => s.Activeted && !s.IsDeleted) < 2 && slider.Activeted)
            {
                return Json("Image isnt' change status!");
            }

            slider.Activeted = !slider.Activeted;
            await _context.SaveChangesAsync();
            return Json(new
            {
                suc = true,
                status = slider.Activeted
            });
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Sliders slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            if (_context.Sliders.Count(s => s.Activeted && !s.IsDeleted) < 2)
            {
                return Json("Image isnt' delete!");
            }


            slider.IsDeleted = true;

            await _context.SaveChangesAsync();
            return Json("Deleted");
        }
    }
}
