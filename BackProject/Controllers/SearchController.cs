using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackProject.DAL;
using BackProject.Extentions;
using BackProject.Models;
using BackProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BackProject.Controllers
{
    public class SearchController : Controller
    {
        private readonly AppDbContext _context;
        public SearchController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string val)
        {
            List<Course> courses = _context.Courses.Where(c => !c.IsDeleted && c.Activeted && c.Name.Contains(val)).OrderByDescending(c => c.Created_at).Take(10).ToList();
            List<Event> events = _context.Events.Where(e => !e.IsDeleted && e.Activeted && e.Title.Contains(val)).OrderByDescending(e => e.Created_at).Take(10).ToList();
            List<Teacher> teachers = _context.Teachers.Where(t => !t.IsDeleted && t.Activeted && (t.Name.Contains(val) || t.Surname.Contains(val))).OrderByDescending(t => t.Id).Take(10).ToList();
            List<Blog> blogs = _context.Blogs.Where(b => !b.IsDeleted && b.Activeted && b.Name.Contains(val)).OrderByDescending(b => b.Created_at).Take(10).ToList();
            _context.IncludeModeratorsBlog(true);
            SearchVM searchVM = new SearchVM()
            {
                Courses = courses,
                Events = events,
                Blogs = blogs,
                Teachers= teachers
            };
            return View(searchVM);
        }
        public IActionResult Search(string val)
        {
            List<Course> courses = _context.Courses.Where(c => !c.IsDeleted && c.Activeted && c.Name.Contains(val)).OrderByDescending(c => c.Created_at).Take(10).ToList();
            List<Event> events = _context.Events.Where(e => !e.IsDeleted && e.Activeted && e.Title.Contains(val)).OrderByDescending(e => e.Created_at).Take(10).ToList();
            List<Teacher> teachers = _context.Teachers.Where(t => !t.IsDeleted && t.Activeted && (t.Name.Contains(val) || t.Surname.Contains(val))).OrderByDescending(t => t.Id).Take(10).ToList();
            List<Blog> blogs = _context.Blogs.Where(b => !b.IsDeleted && b.Activeted && b.Name.Contains(val)).OrderByDescending(b => b.Created_at).Take(10).ToList();
            _context.IncludeModeratorsBlog(true);
            SearchVM searchVM = new SearchVM()
            {
                Courses = courses,
                Events = events,
                Blogs = blogs,
                Teachers=teachers
            };
            return PartialView("_SearchPartial", searchVM);
        }
    }
}
