using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackProject.DAL;
using BackProject.Models;
using BackProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackProject.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Teacher> teachers = _context.Teachers.Where(t => !t.IsDeleted && t.Activeted).Take(4).OrderByDescending(teachers => teachers.Id).ToList();
            AboutSection aboutSection = _context.AboutSections.FirstOrDefault();
            NoticeSection noticeSection = _context.NoticeSections.Include(n => n.Notices).FirstOrDefault();
            List<TestimonialSection> testimonialSection = _context.TestimonialSections.ToList();

            HomeVM homeVM = new HomeVM()
            {
                Teachers = teachers,
                AboutSections = aboutSection,
                NoticeSections = noticeSection,
                TestimonialSections = testimonialSection
            };
            return View(homeVM);
        }
    }
}
