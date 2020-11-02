using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackProject.DAL;
using BackProject.Extentions;
using BackProject.Models;
using BackProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? id)
        {
           

            if (id == null)
            {
                List<Blog> blogs = _context.Blogs.Where(b => !b.IsDeleted && b.Activeted).OrderByDescending(b => b.Created_at).Take(9).ToList();
                _context.IncludeModeratorsBlog(true);
                return View(blogs);
            }
            else
            {
                List<BlogCategory> blogCategories = _context.BlogCategories.Where(b => b.Activeted && !b.IsDeleted && b.CategoryId == id).Include(b => b.Blog).ToList();
                List<Blog> blogs = new List<Blog>();
                foreach (BlogCategory item in blogCategories)
                {
                    blogs.Add(item.Blog);
                }
                _context.IncludeModeratorsBlog(true);

                return View(blogs);
            }
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            Blog blog = await _context.Blogs.Where(b => !b.IsDeleted && b.Activeted && b.Id == id).FirstOrDefaultAsync();
            if (blog == null) return NotFound();

            _context.IncludeCategoryBlog(true);

            List<Blog> lastestBlog = _context.Blogs.Where(b => !b.IsDeleted && b.Activeted).OrderByDescending(b => b.Created_at).Take(3).ToList();

            _context.IncludeModeratorsBlog(true);

            List<Tag> tags = _context.GetTags();

            BlogVM blogVM = new BlogVM()
            {
                Blog = blog,
                LastestBlog = lastestBlog,
                Tags = tags
            };
            return View(blogVM);
        }
        public IActionResult Search(string val)
        {

            List<Blog> Blogs = _context.Blogs.Where(b => !b.IsDeleted && b.Activeted && b.Name.Contains(val)).OrderByDescending(b => b.Created_at).Take(10).ToList();
            _context.IncludeModeratorsBlog(true);
            return PartialView("_SearchPartialBlog", Blogs);
        }
    }
}
