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
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        public EventController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Event> @event = _context.Events.Where(e => !e.IsDeleted && e.Activeted).OrderByDescending(e => e.Created_at).Take(9).ToList();
            return View(@event);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            Event @event = await _context.Events.Where(e => !e.IsDeleted && e.Activeted && e.Id == id).FirstOrDefaultAsync();
            if (@event == null) return NotFound();

            _context.IncludeCategoryEvent(true);
            List<Event> lastestEvent = _context.Events.Where(e => !e.IsDeleted && e.Activeted).OrderByDescending(e => e.Created_at).Take(3).ToList();

            _context.IncludeModeratorsEvent(true);

            List<Tag> tags = _context.GetTags();

            EventVM eventVM = new EventVM()
            {
                Event = @event,
                LastestEvent = lastestEvent,
                Tags = tags
            };
            return View(eventVM);
        }
    }
}
