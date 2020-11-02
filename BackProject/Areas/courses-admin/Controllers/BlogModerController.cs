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
    public class BlogModerController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        public BlogModerController(AppDbContext context, UserManager<AppUser> userManager, IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
        }
        public IActionResult Index()
        {
            List<BlogModerator> blogs = _context.BlogModerators.Where(b => !b.IsDeleted && b.ModeratorId == _userManager.GetUserId(User)).Include(b => b.Blog).ToList();
            _context.IncludeCategoryBlog(false);
            return View(blogs);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            BlogModerator moder = await _context.BlogModerators.Where(b => !b.IsDeleted && b.ModeratorId == _userManager.GetUserId(User) && b.BlogId == id).Include(c => c.Blog).FirstOrDefaultAsync();
            if (moder == null) return NotFound();
            Blog blog = await _context.Blogs.Where(b => !b.IsDeleted && b.Id == id).FirstOrDefaultAsync();
            if (blog == null) return NotFound();

            _context.IncludeCategoryBlog(true);

            List<Category> ctg = _context.Categories.Where(c => !c.IsDeleted && c.Activeted).ToList();
            ViewBag.Categories = ctg;

            return View(blog);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Blog blog, int[] Categories)
        {
            List<Category> ctg = _context.Categories.Where(c => !c.IsDeleted && c.Activeted).ToList();
            ViewBag.Categories = ctg;

            if (id == null) return NotFound();

            BlogModerator moder = await _context.BlogModerators.Where(b => !b.IsDeleted && b.ModeratorId == _userManager.GetUserId(User) && b.BlogId == id).Include(c => c.Blog).FirstOrDefaultAsync();
            if (moder == null) return NotFound();

            Blog blogDb = await _context.Blogs.Where(b => !b.IsDeleted && b.Id == id).FirstOrDefaultAsync();
            _context.IncludeCategoryBlog(false);
            if (blogDb == null) return NotFound();
            if (!ModelState.IsValid) return View(blogDb);
            if (Helpers.Helper.CheckLengthArray(Categories, ModelState)) return View(blogDb);



            if (blog.Name != blogDb.Name)
            {
                bool IsExist = _context.Blogs.Where(b => !b.IsDeleted).Any(b => b.Name.ToLower() == blog.Name.ToLower());
                if (IsExist)
                {
                    ModelState.AddModelError("Name", "This course name already exist!!!");
                    return View(blogDb);
                }
            }

            if (blog.Photo != null)
            {
                if (!blog.Photo.PhotoValidate(ModelState)) return View(blogDb);
                string folder = Path.Combine("site", "img", "blog");
                string fileName = await blog.Photo.SaveImage(_env.WebRootPath, folder);
                blogDb.Image = fileName;
            }



            List<BlogCategory> blogCategories = new List<BlogCategory>();
            foreach (int categoryId in Categories)
            {
                blogCategories.Add(new BlogCategory
                {
                    CategoryId = categoryId,
                    BlogId = blog.Id,
                    Activeted = blog.Activeted
                });
            }

            blogDb.Name = blog.Name;
            blogDb.Description = blog.Description;
            blogDb.BlogCategories = blogCategories;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Status(int? id)
        {
            if (id == null) return NotFound();

            BlogModerator moder = await _context.BlogModerators.Where(b => !b.IsDeleted && b.ModeratorId == _userManager.GetUserId(User) && b.BlogId == id).Include(c => c.Blog).FirstOrDefaultAsync();
            if (moder == null) return NotFound();


            Blog blog = await _context.Blogs.FindAsync(id);
            if (blog == null) return NotFound();

            _context.IncludeCategoryBlog(false);
            _context.IncludeModeratorsBlog(true);

            foreach (BlogCategory item in blog.BlogCategories)
            {
                item.Activeted = !blog.Activeted;
            }
            foreach (BlogModerator item in blog.BlogModerators)
            {
                item.Activeted = !blog.Activeted;
            }
            blog.Activeted = !blog.Activeted;
            await _context.SaveChangesAsync();
            return Json(new
            {
                suc = true,
                status = blog.Activeted
            });
        }
    }
}
