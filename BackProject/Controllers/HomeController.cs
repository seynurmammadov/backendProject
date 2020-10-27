using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BackProject.Models;
using BackProject.DAL;
using BackProject.ViewModels;

namespace BackProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Sliders> slider = _context.Sliders.Where(s => s.Activeted && !s.IsDeleted).ToList();
            HomeVM homeVM = new HomeVM()
            {
                Sliders = slider
            };
            return View(homeVM);
        }
    }
}
