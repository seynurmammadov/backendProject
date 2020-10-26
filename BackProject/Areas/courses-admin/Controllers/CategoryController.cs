using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackProject.DAL;
using BackProject.Extentions;
using BackProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackProject.Areas.courses_admin.Controllers
{
    [Area("courses-admin")]
    [Authorize(Roles = "Admin,MainAdmin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Categories.Where(c => !c.IsDeleted).ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category ctg)
        {
            if (!ModelState.IsValid) return View(ctg);

            bool isExist = _context.Categories.Where(c=>!c.IsDeleted).Any(c => c.Name.ToLower() == ctg.Name.ToLower());
            if (isExist)
            {
                ModelState.AddModelError("Name", "This category already exist!");
                return View(ctg);
            }

            ctg.IsDeleted = false;
            ctg.Activeted = true;
            await _context.Categories.AddAsync(ctg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Category ctg = await _context.Categories.FindAsync(id);
            if (ctg == null) return NotFound();
            return View(ctg);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Category ctg)
        {
            if (id == null) return NotFound();
            if (!ModelState.IsValid) return View(ctg);
            Category dbCtg = await _context.Categories.FindAsync(id);
            if (dbCtg == null) return NotFound();
            if (dbCtg.Name.ToLower() != ctg.Name.ToLower())
            {
                bool isExist = _context.Categories.Any(c => c.Name.ToLower() == ctg.Name.ToLower());
                if (isExist)
                {
                    ModelState.AddModelError("Name", "This category already exist!");
                    return View(ctg);
                }
            }
            dbCtg.Name = ctg.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Status(int? id)
        {
            if (id == null) return NotFound();
            Category category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();

            _context.IncludeCourses(true);
            _context.IncludeEvents(true);
            _context.IncludeBlogs(true);

            string checkCategory = _context.CheckCategoryCourse(category, "disable");
            if (checkCategory != "success") return Json(checkCategory);

            checkCategory = _context.CheckCategoryEvent(category, "disable");
            if (checkCategory != "success") return Json(checkCategory);

            checkCategory = _context.CheckCategoryBlog(category, "disable");
            if (checkCategory != "success") return Json(checkCategory);

            if (category.CourseCategories != null)
            {
                foreach (CourseCategory item in category.CourseCategories)
                {
                    item.Activeted = !category.Activeted;
                }
            }
            if (category.EventCategories != null)
            {
                foreach (EventCategory item in category.EventCategories)
                {
                    item.Activeted = !category.Activeted;
                }
            }

            category.Activeted = !category.Activeted;

            await _context.SaveChangesAsync();
            return Json(new
            {
                suc = true,
                status = category.Activeted
            });
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Category category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            _context.IncludeCourses(true);
            _context.IncludeEvents(true);
            _context.IncludeBlogs(true);

            string checkCategory = _context.CheckCategoryCourse(category, "delete");
            if (checkCategory != "success") return Json(checkCategory);

             checkCategory = _context.CheckCategoryEvent(category, "delete");
            if (checkCategory != "success") return Json(checkCategory);

            checkCategory = _context.CheckCategoryBlog(category, "delete");
            if (checkCategory != "success") return Json(checkCategory);

            if (category.CourseCategories != null)
            {
                foreach (CourseCategory item in category.CourseCategories)
                {
                    item.IsDeleted = true;
                }
            }
            if (category.EventCategories != null)
            {
                foreach (EventCategory item in category.EventCategories)
                {
                    item.IsDeleted = true;
                }
            }
            category.IsDeleted = true;

            await _context.SaveChangesAsync();
            return Json("Deleted");
        }
    }
}