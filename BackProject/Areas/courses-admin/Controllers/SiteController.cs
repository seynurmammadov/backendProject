using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackProject.DAL;
using BackProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackProject.Areas.courses_admin.Controllers
{
    [Area("courses-admin")]
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin,MainAdmin")]
    public class SiteController : Controller
    {
        private readonly AppDbContext _context;
        public SiteController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.SiteInfo.FirstOrDefault());
        }
       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(SiteInfo siteInfo)
        {

            if (!ModelState.IsValid) return View(siteInfo);
            SiteInfo dbSiteInfo = await _context.SiteInfo.FirstOrDefaultAsync();
            if (dbSiteInfo == null) return NotFound();
            siteInfo.Id.

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }*/
    }
}
