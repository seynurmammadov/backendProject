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
    public class EventModerController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        public EventModerController(AppDbContext context, UserManager<AppUser> userManager, IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
        }
        public IActionResult Index()
        {
            List<EventModerator> events = _context.EventModerators.Where(e => !e.IsDeleted && e.ModeratorId == _userManager.GetUserId(User)).Include(e => e.Event).ToList();
            _context.IncludeCategoryEvent(false);
            return View(events);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            EventModerator moder = await _context.EventModerators.Where(c => !c.IsDeleted && c.ModeratorId == _userManager.GetUserId(User) && c.EventId == id).Include(c => c.Event).FirstOrDefaultAsync();
            if (moder == null) return NotFound();
            Event @event = await _context.Events.Where(e => !e.IsDeleted && e.Id == id).FirstOrDefaultAsync();
            if (@event == null) return NotFound();

            _context.IncludeCategoryEvent(false);

            List<Category> ctg = _context.Categories.Where(c => !c.IsDeleted && c.Activeted).ToList();
            ViewBag.Categories = ctg;

            return View(@event);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Event @event, int[] Categories)
        {
            List<Category> ctg = _context.Categories.Where(c => !c.IsDeleted && c.Activeted).ToList();
            ViewBag.Categories = ctg;

            if (id == null) return NotFound();

            EventModerator moder = await _context.EventModerators.Where(c => !c.IsDeleted && c.ModeratorId == _userManager.GetUserId(User) && c.EventId == id).Include(c => c.Event).FirstOrDefaultAsync();
            if (moder == null) return NotFound();
            Event eventDb = await _context.Events.Where(e => !e.IsDeleted && e.Id == id).FirstOrDefaultAsync();
            _context.IncludeCategoryEvent(false);
            if (@event == null) return NotFound();

            if (id == null) return NotFound();
            if (Helpers.Helper.CheckLengthArray(Categories, ModelState)) return View(eventDb);


            if (!ModelState.IsValid) return View(eventDb);

            if (@event.Title != eventDb.Title)
            {
                bool IsExist = _context.Events.Where(e => !e.IsDeleted).Any(e => e.Title.ToLower() == @event.Title.ToLower());
                if (IsExist)
                {
                    ModelState.AddModelError("Name", "This course name already exist!!!");
                    return View(eventDb);
                }
            }

            if (@event.Photo != null)
            {
                if (!@event.Photo.PhotoValidate(ModelState)) return View(eventDb);
                string folder = Path.Combine("site", "img", "event");
                string fileName = await @event.Photo.SaveImage(_env.WebRootPath, folder);
                eventDb.Image = fileName;
            }



            List<EventCategory> eventCategories = new List<EventCategory>();
            foreach (int categoryId in Categories)
            {
                eventCategories.Add(new EventCategory
                {
                    CategoryId = categoryId,
                    EventId = @event.Id,
                    Activeted = @event.Activeted
                });
            }
           

            eventDb.Title = @event.Title;
            eventDb.StartTime = @event.StartTime;
            eventDb.EndTime = @event.EndTime;
            eventDb.Description = @event.Description;
            eventDb.Venue = @event.Venue;
            eventDb.EventCategories = eventCategories;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Status(int? id)
        {
            if (id == null) return NotFound();
            EventModerator moder = await _context.EventModerators.Where(c => !c.IsDeleted && c.ModeratorId == _userManager.GetUserId(User) && c.EventId == id).Include(c => c.Event).FirstOrDefaultAsync();
            if (moder == null) return NotFound();
            Event @event = await _context.Events.FindAsync(id);
            if (@event == null) return NotFound();

            _context.IncludeCategoryEvent(false);
            _context.IncludeModeratorsEvent(true);

            foreach (EventCategory item in @event.EventCategories)
            {
                item.Activeted = !@event.Activeted;
            }
            foreach (EventModerator item in @event.EventModerators)
            {
                item.Activeted = !@event.Activeted;
            }
            @event.Activeted = !@event.Activeted;
            await _context.SaveChangesAsync();
            return Json(new
            {
                suc = true,
                status = @event.Activeted
            });
        }
    }
}
