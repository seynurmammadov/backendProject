using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackProject.DAL;
using BackProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackProject.Areas.courses_admin.Controllers
{
    [Area("courses-admin")]
    [Authorize(Roles = "Admin,MainAdmin")]
    public class TagController : Controller
    {
        private readonly AppDbContext _context;
        public TagController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Tags.Where(c => !c.IsDeleted).ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tag tag)
        {
            if (!ModelState.IsValid) return View(tag);

            bool isExist = _context.Tags.Where(t => !t.IsDeleted).Any(t => t.Name.ToLower() == tag.Name.ToLower());
            if (isExist)
            {
                ModelState.AddModelError("Name", "This tag already exist!");
                return View(tag);
            }

            tag.IsDeleted = false;
            tag.Activeted = true;
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Tag tag = await _context.Tags.FindAsync(id);
            if (tag == null) return NotFound();
            return View(tag);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Tag tag)
        {
            if (id == null) return NotFound();
            if (!ModelState.IsValid) return View(tag);
            Tag dbTag = await _context.Tags.FindAsync(id);
            if (dbTag == null) return NotFound();
            if (dbTag.Name.ToLower() != tag.Name.ToLower())
            {
                bool isExist = _context.Tags.Where(t => !t.IsDeleted).Any(t => t.Name.ToLower() == tag.Name.ToLower());
                if (isExist)
                {
                    ModelState.AddModelError("Name", "This tag already exist!");
                    return View(tag);
                }
            }
            dbTag.Name = tag.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Status(int? id)
        {
            if (id == null) return NotFound();
            Tag tag = await _context.Tags.FindAsync(id);
            if (tag == null) return NotFound();

            tag.Activeted = !tag.Activeted;

            await _context.SaveChangesAsync();
            return Json(new
            {
                suc = true,
                status = tag.Activeted
            });
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Tag tag = await _context.Tags.FindAsync(id);
            if (tag == null) return NotFound();

            tag.IsDeleted = true;

            await _context.SaveChangesAsync();
            return Json("Deleted");
        }
    }
}
