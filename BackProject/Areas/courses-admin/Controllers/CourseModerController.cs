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
    [Authorize(Roles = "courseModerator")]
    public class CourseModerController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        public CourseModerController(AppDbContext context, UserManager<AppUser> userManager, IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
        }
        public IActionResult Index()
        {
            List<CourseModerator> courses = _context.CourseModerators.Where(c => !c.IsDeleted && c.ModeratorId == _userManager.GetUserId(User)).Include(c=>c.Course).ToList();
            _context.IncludeCategory(false);
            return View(courses);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            CourseModerator moder = await _context.CourseModerators.Where(c => !c.IsDeleted && c.ModeratorId == _userManager.GetUserId(User) && c.CourseId == id).Include(c => c.Course).FirstOrDefaultAsync();
            if (moder == null) return NotFound();
            Course course = await _context.Courses.Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (course == null) return NotFound();

            _context.IncludeCategory(true);
            List<Category> ctg = _context.Categories.Where(c => !c.IsDeleted && c.Activeted).ToList();
            ViewBag.Categories = ctg;

            return View(course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Course course, int[] Categories)
        {
            List<Category> ctg = _context.Categories.Where(c => !c.IsDeleted && c.Activeted).ToList();
            ViewBag.Categories = ctg;
            if (id == null) return NotFound();
            CourseModerator moder = await _context.CourseModerators.Where(c => !c.IsDeleted && c.ModeratorId == _userManager.GetUserId(User) && c.CourseId == id).Include(c => c.Course).FirstOrDefaultAsync();
            if (moder == null) return NotFound();
            Course courseDb = await _context.Courses.Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            _context.IncludeCategory(false);
            if (courseDb == null) return NotFound();
            if (!ModelState.IsValid) return View(courseDb);
            if (Helpers.Helper.CheckLengthArray(Categories, ModelState)) return View(courseDb);

            if (course.Name != courseDb.Name)
            {
                bool IsExist = _context.Courses.Where(c => !c.IsDeleted).Any(c => c.Name.ToLower() == course.Name.ToLower());
                if (IsExist)
                {
                    ModelState.AddModelError("Name", "This course name already exist!!!");
                    return View(courseDb);
                }
            }

            if (course.Photo != null)
            {
                if (!course.Photo.PhotoValidate(ModelState)) return View(courseDb);
                string folder = Path.Combine("site", "img", "course");
                string fileName = await course.Photo.SaveImage(_env.WebRootPath, folder);
                courseDb.Image = fileName;
            }



            List<CourseCategory> courseCategories = new List<CourseCategory>();
            foreach (int categoryId in Categories)
            {
                courseCategories.Add(new CourseCategory
                {
                    CategoryId = categoryId,
                    CourseId = course.Id,
                    Activeted = course.Activeted
                });
            }
           
            courseDb.Name = course.Name;
            courseDb.ShortDescription = course.ShortDescription;
            courseDb.Description = course.Description;
            courseDb.CourseCategories = courseCategories;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Status(int? id)
        {
            if (id == null) return NotFound();
            CourseModerator moder =  _context.CourseModerators.Where(c => !c.IsDeleted && c.ModeratorId == _userManager.GetUserId(User) && c.CourseId == id).FirstOrDefault();
            if (moder == null) return NotFound();
            Course course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();

            _context.IncludeCategory(false);
            _context.IncludeModerators(true);

            foreach (CourseCategory item in course.CourseCategories)
            {
                item.Activeted = !course.Activeted;
            }
            foreach (CourseModerator item in course.CourseModerators)
            {
                item.Activeted = !course.Activeted;
            }
            course.Activeted = !course.Activeted;
            await _context.SaveChangesAsync();
            return Json(new
            {
                suc = true,
                status = course.Activeted
            });
        }
    }
}
