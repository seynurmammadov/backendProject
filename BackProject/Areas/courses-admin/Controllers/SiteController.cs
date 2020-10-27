using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BackProject.DAL;
using BackProject.Extentions;
using BackProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackProject.Areas.courses_admin.Controllers
{
    [Area("courses-admin")]
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin,MainAdmin")]
    public class SiteController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _contextAccessor;
        public SiteController(AppDbContext context, IWebHostEnvironment env, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.SiteInfo.FirstOrDefault());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(SiteInfo siteInfo)
        {

            if (!ModelState.IsValid) return View(siteInfo);
            SiteInfo dbSiteInfo = await _context.SiteInfo.FirstOrDefaultAsync();
            if (dbSiteInfo == null) return NotFound();

            if (siteInfo.Photo != null)
            {
                if (!siteInfo.Photo.PhotoValidate(ModelState)) return View(siteInfo);
                string folder = Path.Combine("site", "img", "logo");
                string fileName = await siteInfo.Photo.SaveImage(_env.WebRootPath, folder);
                dbSiteInfo.Logo = fileName;
            }
            dbSiteInfo.Title = siteInfo.Title;
            dbSiteInfo.PhoneNumber1 = siteInfo.PhoneNumber1;
            dbSiteInfo.PhoneNumber2 = siteInfo.PhoneNumber2;
            dbSiteInfo.ShortDescription = siteInfo.ShortDescription;
            dbSiteInfo.Facebook = siteInfo.Facebook;
            dbSiteInfo.Pinterest = siteInfo.Pinterest;
            dbSiteInfo.Twitter = siteInfo.Twitter;
            dbSiteInfo.Address = siteInfo.Address;
            dbSiteInfo.Email = siteInfo.Email;
            dbSiteInfo.SiteUrl = _contextAccessor.HttpContext.Request.Scheme + System.Uri.SchemeDelimiter + _contextAccessor.HttpContext.Request.Host.Value;
            dbSiteInfo.LocationLatitude = siteInfo.LocationLatitude;
            dbSiteInfo.LocationLongitude = siteInfo.LocationLongitude;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
