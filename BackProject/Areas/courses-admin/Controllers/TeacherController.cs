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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackProject.Areas.courses_admin.Controllers
{
    [Area("courses-admin")]
    [Authorize(Roles = "Admin,MainAdmin")]
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TeacherController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Teachers.Where(t => !t.IsDeleted).ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherVM teacherVM)
        {
            if (!ModelState.IsValid) return View(teacherVM);

            Teacher teacher = teacherVM.Teacher;
            TeacherDescription teacherDescription = teacherVM.TeacherDescription;

            bool isExist = _context.Teachers.Where(t => !t.IsDeleted).Any(t => (t.Email.ToLower() == teacher.Email.ToLower()) || (t.PhoneNumber.ToLower() == teacher.PhoneNumber.ToLower())) ;
            if (isExist)
            {
                ModelState.AddModelError("Name", "Teacher with this email or number already exist!");
                return View(teacherVM);
            }

            if (!teacher.Photo.PhotoValidate(ModelState)) return View(teacherVM);

            string folder = Path.Combine("site", "img", "teacher");
            string fileName = await teacher.Photo.SaveImage(_env.WebRootPath, folder);

            teacher.Image = fileName;
            teacher.IsDeleted = false;
            teacher.teacherDescription = teacherDescription;

            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Teacher teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null) return NotFound();
            TeacherDescription teacherDescription = await _context.TeacherDescriptions.Where(t => t.TeacherId == id).FirstOrDefaultAsync();
            if (teacherDescription == null) return NotFound();
            TeacherVM teacherVM = new TeacherVM()
            {
                Teacher = teacher,
                TeacherDescription = teacherDescription
            };
            return View(teacherVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, TeacherVM teacherVM)
        {
            if (id == null) return NotFound();
            Teacher teacherDb = await _context.Teachers.FindAsync(id);
            if (teacherDb == null) return NotFound();
            TeacherDescription teacherDescriptionDb = await _context.TeacherDescriptions.Where(t => t.TeacherId == id).FirstOrDefaultAsync();
            if (teacherDescriptionDb == null) return NotFound();

            Teacher teacher = teacherVM.Teacher;
            TeacherDescription teacherDescription = teacherVM.TeacherDescription;

            if ((teacher.Email.ToLower() != teacherDb.Email.ToLower()) || (teacher.PhoneNumber.ToLower() != teacherDb.PhoneNumber.ToLower()))
            {
                bool isExist = _context.Teachers.Where(t => !t.IsDeleted).Any(t => (t.Email.ToLower() == teacher.Email.ToLower()) || (t.PhoneNumber.ToLower() == teacher.PhoneNumber.ToLower()));
                if (isExist)
                {
                    ModelState.AddModelError("Name", "Teacher with this email or number already exist!");
                    return View(teacherVM);
                }
            }
            if (teacher.Photo != null)
            {
                if (!teacher.Photo.PhotoValidate(ModelState)) return View(teacherVM);
                string folder = Path.Combine("site", "img", "teacher");
                string fileName = await teacher.Photo.SaveImage(_env.WebRootPath, folder);
                teacherDb.Image = fileName;
            }
            teacherDb.Name = teacher.Name;
            teacherDb.Surname = teacher.Surname;
            teacherDb.Position = teacher.Position;
            teacherDb.Email = teacher.Email;
            teacherDb.PhoneNumber = teacher.PhoneNumber;
            teacherDb.Skype = teacher.Skype;
            teacherDb.Pinterest = teacher.Pinterest;
            teacherDb.Facebook = teacher.Facebook;
            teacherDb.Twitter = teacher.Twitter;
            teacherDb.Activeted = teacher.Activeted;
            teacherDescriptionDb = teacherDescription;
            teacherDb.teacherDescription = teacherDescriptionDb;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Status(int? id)
        {
            if (id == null) return NotFound();
            Teacher teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null) return NotFound();

            teacher.Activeted = !teacher.Activeted;

            await _context.SaveChangesAsync();
            return Json(new
            {
                suc = true,
                status = teacher.Activeted
            });
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Teacher teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null) return NotFound();

            teacher.IsDeleted = true;
         
            await _context.SaveChangesAsync();
            return Json("Deleted");
        }
    }
}
