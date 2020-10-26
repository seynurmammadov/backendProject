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
    [Authorize(Roles = "Admin,MainAdmin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        public BlogController(AppDbContext context, UserManager<AppUser> userManager, IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Blog> blogs = _context.Blogs.Where(b => !b.IsDeleted).ToList();
            _context.IncludeCategoryBlog(false);
            _context.IncludeModeratorsBlog(true);
            return View(blogs);
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
        public async Task<IActionResult> Create(Blog blog, string[] Moderators, int[] Categories)
        {
            object[] obj = await Helpers.Helper.CreateVM(_context, _userManager);
            ViewBag.Categories = obj[0];
            ViewBag.Moderators = obj[1];
            if (Helpers.Helper.CheckLengthArray(Categories, ModelState)) return View(blog);
            if (Helpers.Helper.CheckLengthArray(Moderators, ModelState)) return View(blog);

            if (!ModelState.IsValid) return View(blog);

            bool IsExist = _context.Blogs.Where(b => !b.IsDeleted).Any(b => b.Name.ToLower() == blog.Name.ToLower());
            if (IsExist)
            {
                ModelState.AddModelError("Name", "This course name already exist!!!");
                return View(blog);
            }

            if (!blog.Photo.PhotoValidate(ModelState)) return View(blog);

            string folder = Path.Combine("site", "img", "blog");
            string fileName = await blog.Photo.SaveImage(_env.WebRootPath, folder);

            blog.Image = fileName;

            List<BlogCategory> blogCategories = new List<BlogCategory>();
            foreach (int id in Categories)
            {
                blogCategories.Add(new BlogCategory
                {
                    CategoryId = id,
                    BlogId = blog.Id,
                    Activeted = blog.Activeted
                });
            }
            List<BlogModerator> blogModerators = new List<BlogModerator>();
            foreach (string id in Moderators)
            {
                blogModerators.Add(new BlogModerator
                {
                    ModeratorId = id,
                    BlogId = blog.Id,
                    Activeted = blog.Activeted
                });
            }

            blog.BlogCategories = blogCategories;
            blog.BlogModerators = blogModerators;
            blog.IsDeleted = false;
            blog.Created_at = DateTime.Now;
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Blog blog = await _context.Blogs.Where(b => !b.IsDeleted && b.Id == id).FirstOrDefaultAsync();
            if (blog == null) return NotFound();

            _context.IncludeCategoryBlog(true);
            _context.IncludeModeratorsBlog(true);
            object[] obj = await Helpers.Helper.CreateVM(_context, _userManager);
            ViewBag.Categories = obj[0];
            ViewBag.Moderators = obj[1];

            return View(blog);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Blog blog, string[] Moderators, int[] Categories)
        {
            object[] obj = await Helpers.Helper.CreateVM(_context, _userManager);
            ViewBag.Categories = obj[0];
            ViewBag.Moderators = obj[1];
            if (id == null) return NotFound();

            Blog blogDb = await _context.Blogs.Where(b => !b.IsDeleted && b.Id == id).FirstOrDefaultAsync();
            _context.IncludeModeratorsBlog(false);
            _context.IncludeCategoryBlog(false);
            if (blogDb == null) return NotFound();
            if (!ModelState.IsValid) return View(blogDb);
            if (Helpers.Helper.CheckLengthArray(Categories, ModelState)) return View(blogDb);
            if (Helpers.Helper.CheckLengthArray(Moderators, ModelState)) return View(blogDb);



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
            List<BlogModerator> blogModerators = new List<BlogModerator>();
            foreach (string moderatorId in Moderators)
            {
                blogModerators.Add(new BlogModerator
                {
                    ModeratorId = moderatorId,
                    BlogId = blog.Id,
                    Activeted = blog.Activeted
                });
            }

            blogDb.Name = blog.Name;
            blogDb.Description = blog.Description;
            blogDb.Activeted = blog.Activeted;
            blogDb.BlogCategories = blogCategories;
            blogDb.BlogModerators = blogModerators;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Status(int? id)
        {
            if (id == null) return NotFound();
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Blog blog = await _context.Blogs.FindAsync(id);
            if (blog == null) return NotFound();

            _context.IncludeCategoryBlog(false);
            _context.IncludeModeratorsBlog(true);

            foreach (BlogCategory item in blog.BlogCategories)
            {
                item.IsDeleted = true;
            }
            foreach (BlogModerator item in blog.BlogModerators)
            {
                item.IsDeleted = true;
            }
            blog.IsDeleted = true;

            await _context.SaveChangesAsync();
            return Json("Deleted");
        }

    }
}
