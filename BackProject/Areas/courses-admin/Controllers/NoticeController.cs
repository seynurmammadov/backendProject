using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackProject.DAL;
using BackProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackProject.Areas.courses_admin.Controllers
{
    [Area("courses-admin")]
    [Authorize(Roles = "Admin,MainAdmin")]
    public class NoticeController : Controller
    {
        private readonly AppDbContext _context;

        public NoticeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.NoticeSections.Include(n=>n.Notices).FirstOrDefault());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(NoticeSection noticeSection)
        {

            if (!ModelState.IsValid) return View(noticeSection);
            NoticeSection noticeSectionDb = await _context.NoticeSections.FirstOrDefaultAsync();
            if (noticeSectionDb == null) return NotFound();

            noticeSectionDb.VideoUrl = noticeSection.VideoUrl;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Notice notice = await _context.Notices.FindAsync(id);
            if (notice == null) return NotFound();
            return View(notice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Notice notice)
        {
            if (id == null) return NotFound();
            if (!ModelState.IsValid) return View(notice);
            Notice noticeDb = await _context.Notices.FindAsync(id);
            if (noticeDb == null) return NotFound();

            noticeDb.NoticeTime = notice.NoticeTime;
            noticeDb.NoticeText = notice.NoticeText;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Notice notice)
        {
            if (!ModelState.IsValid) return View(notice);
            NoticeSection noticeSectionDb = await _context.NoticeSections.FirstOrDefaultAsync();
            noticeSectionDb.Notices = new List<Notice> { notice };
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            if(_context.Notices.Count()<2)  return Json("You should have 1 notice");
            Notice noticeDb = await _context.Notices.FindAsync(id);
            if (noticeDb == null) return NotFound();
             _context.Notices.Remove(noticeDb);
            await _context.SaveChangesAsync();
            return Json("Deleted");
        }
    }
}
