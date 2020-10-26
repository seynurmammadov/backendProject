using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackProject.DAL;
using BackProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackProject.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        public TeacherController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Teachers.Where(t => !t.IsDeleted && t.Activeted).ToList());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            Teacher teacher = await _context.Teachers.Where(t => !t.IsDeleted && t.Activeted && t.Id == id).Include(t=>t.teacherDescription).FirstOrDefaultAsync();
            if (teacher == null) return NotFound();
            return View(teacher);
        }
    }
}
