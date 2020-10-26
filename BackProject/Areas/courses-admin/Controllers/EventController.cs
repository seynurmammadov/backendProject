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
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        public EventController(AppDbContext context, UserManager<AppUser> userManager, IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Event> events = _context.Events.Where(e => !e.IsDeleted).ToList();
            _context.IncludeCategoryEvent(false);
            _context.IncludeModeratorsEvent(true);
            return View(events);
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
        public async Task<IActionResult> Create(Event @event, string[] Moderators, int[] Categories)
        {
            object[] obj = await Helpers.Helper.CreateVM(_context, _userManager);
            ViewBag.Categories = obj[0];
            ViewBag.Moderators = obj[1];
            if (Helpers.Helper.CheckLengthArray(Categories, ModelState)) return View(@event);
            if (Helpers.Helper.CheckLengthArray(Moderators, ModelState)) return View(@event);

            if (!ModelState.IsValid) return View(@event);

            bool IsExist = _context.Courses.Where(e => !e.IsDeleted).Any(e => e.Name.ToLower() == @event.Title.ToLower());
            if (IsExist)
            {
                ModelState.AddModelError("Title", "This course name already exist!!!");
                return View(@event);
            }

            if (!@event.Photo.PhotoValidate(ModelState)) return View(@event);

            string folder = Path.Combine("site", "img", "event");
            string fileName = await @event.Photo.SaveImage(_env.WebRootPath, folder);

            @event.Image = fileName;

            List<EventCategory> eventCategories = new List<EventCategory>();
            foreach (int id in Categories)
            {
                eventCategories.Add(new EventCategory
                {
                    CategoryId = id,
                    EventId = @event.Id,
                    Activeted = @event.Activeted
                });
            }
            List<EventModerator> eventModerators = new List<EventModerator>();
            foreach (string id in Moderators)
            {
                eventModerators.Add(new EventModerator
                {
                    ModeratorId = id,
                    EventId = @event.Id,
                    Activeted = @event.Activeted
                });
            }

            @event.EventCategories = eventCategories;
            @event.EventModerators = eventModerators;
            @event.IsDeleted = false;
            @event.Created_at = DateTime.Now;
            await _context.Events.AddAsync(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Event @event = await _context.Events.Where(e => !e.IsDeleted && e.Id == id).FirstOrDefaultAsync();
            if (@event == null) return NotFound();


            _context.IncludeCategoryEvent(false);
            _context.IncludeModeratorsEvent(true);
            object[] obj = await Helpers.Helper.CreateVM(_context, _userManager);
            ViewBag.Categories = obj[0];
            ViewBag.Moderators = obj[1];

            return View(@event);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Event @event, string[] Moderators, int[] Categories)
        {
            object[] obj = await Helpers.Helper.CreateVM(_context, _userManager);
            ViewBag.Categories = obj[0];
            ViewBag.Moderators = obj[1];

            Event eventDb = await _context.Events.Where(e=> !e.IsDeleted && e.Id == id).FirstOrDefaultAsync();
            _context.IncludeCategoryEvent(false);
            _context.IncludeModeratorsEvent(false);
            if (@event == null) return NotFound();

            if (id == null) return NotFound();
            if (Helpers.Helper.CheckLengthArray(Categories, ModelState)) return View(eventDb);
            if (Helpers.Helper.CheckLengthArray(Moderators, ModelState)) return View(eventDb);


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
            List<EventModerator> eventModerators = new List<EventModerator>();
            foreach (string moderatorId in Moderators)
            {
                eventModerators.Add(new EventModerator
                {
                    ModeratorId = moderatorId,
                    EventId = @event.Id,
                    Activeted = @event.Activeted
                });
            }

            eventDb.Title = @event.Title;
            eventDb.StartTime = @event.StartTime;
            eventDb.EndTime = @event.EndTime;
            eventDb.Description = @event.Description;
            eventDb.Venue = @event.Venue;
            eventDb.Activeted = @event.Activeted;
            eventDb.EventCategories = eventCategories;
            eventDb.EventModerators = eventModerators;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Status(int? id)
        {
            if (id == null) return NotFound();
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Event @event = await _context.Events.FindAsync(id);
            if (@event == null) return NotFound();

            _context.IncludeCategoryEvent(false);
            _context.IncludeModeratorsEvent(true);

            foreach (EventCategory item in @event.EventCategories)
            {
                item.IsDeleted = true;
            }
            foreach (EventModerator item in @event.EventModerators)
            {
                item.IsDeleted = true;
            }
            @event.IsDeleted = true;

            await _context.SaveChangesAsync();
            return Json("Deleted");
        }
    }
}
