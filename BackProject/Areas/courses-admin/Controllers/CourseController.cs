using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BackProject.DAL;
using BackProject.Extentions;
using BackProject.Models;
using BackProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackProject.Areas.courses_admin.Controllers
{
    [Area("courses-admin")]
    [Authorize(Roles = "Admin,MainAdmin")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        public CourseController(AppDbContext context, UserManager<AppUser> userManager, IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Course> courses = _context.Courses.Where(c => !c.IsDeleted).ToList();
            _context.IncludeCategory(false);
            _context.IncludeModerators(true);
            return View(courses);
        }
        public async Task<IActionResult> Create()
        {
            object[] obj = await Helpers.Helper.CreateVM(_context, _userManager);
            ViewBag.Categories = obj[0];
            ViewBag.Moderators = obj[1];
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course, string[] Moderators, int[] Categories)
        {
            object[] obj = await Helpers.Helper.CreateVM(_context, _userManager);
            ViewBag.Categories = obj[0];
            ViewBag.Moderators = obj[1];
            if (Helpers.Helper.CheckLengthArray(Categories, ModelState)) return View(course);
            if (Helpers.Helper.CheckLengthArray(Moderators, ModelState)) return View(course);

            if (!ModelState.IsValid) return View(course);

            bool IsExist = _context.Courses.Where(c => !c.IsDeleted).Any(c => c.Name.ToLower() == course.Name.ToLower());
            if (IsExist)
            {
                ModelState.AddModelError("Name", "This course name already exist!!!");
                return View(course);
            }

            if(!course.Photo.PhotoValidate(ModelState)) return View(course);

            string folder = Path.Combine("site", "img", "course");
            string fileName = await course.Photo.SaveImage(_env.WebRootPath, folder);

            course.Image = fileName;

            List<CourseCategory> courseCategories = new List<CourseCategory>();
            foreach (int id in Categories)
            {
                courseCategories.Add(new CourseCategory
                {
                    CategoryId = id,
                    CourseId = course.Id,
                    Activeted = course.Activeted
                });
            }
            List<CourseModerator> courseModerators = new List<CourseModerator>();
            foreach (string id in Moderators)
            {
                courseModerators.Add(new CourseModerator
                {
                    ModeratorId = id,
                    CourseId = course.Id,
                    Activeted = course.Activeted
                });
            }

            course.CourseCategories = courseCategories;
            course.CourseModerators = courseModerators;
            course.IsDeleted = false;
            course.Created_at = DateTime.Now;
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Course course = await _context.Courses.Where(c=>!c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            if (course == null) return NotFound();

            _context.IncludeCategory(true);
            _context.IncludeModerators(true);
            object[] obj = await Helpers.Helper.CreateVM(_context, _userManager);
            ViewBag.Categories = obj[0];
            ViewBag.Moderators = obj[1];

            return View(course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int?id, Course course, string[] Moderators, int[] Categories)
        {
            object[] obj = await Helpers.Helper.CreateVM(_context, _userManager);
            ViewBag.Categories = obj[0];
            ViewBag.Moderators = obj[1];
            if (id == null) return NotFound();

            Course courseDb = await _context.Courses.Where(c => !c.IsDeleted && c.Id == id).FirstOrDefaultAsync();
            _context.IncludeModerators(false);
            _context.IncludeCategory(false);
            if (courseDb == null) return NotFound();
            if (!ModelState.IsValid) return View(courseDb);
            if (Helpers.Helper.CheckLengthArray(Categories, ModelState)) return View(courseDb);
            if (Helpers.Helper.CheckLengthArray(Moderators, ModelState)) return View(courseDb);
          
           

            if (course.Name!=courseDb.Name)
            {
                bool IsExist = _context.Courses.Where(c => !c.IsDeleted).Any(c => c.Name.ToLower() == course.Name.ToLower());
                if (IsExist)
                {
                    ModelState.AddModelError("Name", "This course name already exist!!!");
                    return View(courseDb);
                }
            }

            if (course.Photo!=null)
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
            List<CourseModerator> courseModerators = new List<CourseModerator>();
            foreach (string moderatorId in Moderators)
            {
                courseModerators.Add(new CourseModerator
                {
                    ModeratorId = moderatorId,
                    CourseId = course.Id,
                    Activeted = course.Activeted
                });
            }

            courseDb.Name = course.Name;
            courseDb.ShortDescription = course.ShortDescription;
            courseDb.Description = course.Description;
            courseDb.Activeted = course.Activeted;
            courseDb.CourseCategories = courseCategories;
            courseDb.CourseModerators = courseModerators;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Status(int? id)
        {
            if (id == null) return NotFound();
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Course course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();

            _context.IncludeCategory(false);
            _context.IncludeModerators(true);

            foreach (CourseCategory item in course.CourseCategories)
            {
                item.IsDeleted = true;
            }
            foreach (CourseModerator item in course.CourseModerators)
            {
                item.IsDeleted = true;
            }
            course.IsDeleted = true;

            await _context.SaveChangesAsync();
            return Json("Deleted");
        }


    }
}