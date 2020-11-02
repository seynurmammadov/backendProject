using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackProject.DAL;
using BackProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackProject.Controllers
{
    public class ResetController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        public ResetController(UserManager<AppUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<IActionResult> Index(string id)
        {
            if (id == null) return NotFound();
            AppUser user = await _context.Users.Where(user => user.ActiveCode == id).FirstOrDefaultAsync();
            if (user == null) return NotFound();

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string id, string NewPassword)
        {
            if (id == null) return NotFound();
            AppUser user = await _context.Users.Where(user => user.ActiveCode == id).FirstOrDefaultAsync();
            if (user == null) return NotFound();


            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            IdentityResult identityResult = await _userManager.ResetPasswordAsync(user, token, NewPassword);
            if (!identityResult.Succeeded)
            {
                TempData["error"] = "";
                foreach (var item in identityResult.Errors)
                {
                    TempData["error"] += item.Description.ToString();
                }
                return View(user);
            }
            user.ActiveCode = null;
            await _context.SaveChangesAsync();
            return RedirectToAction("index","home");
        }
        public async Task<IActionResult> Unsubscribe(string id)
        {
            if (id == null) return NotFound();
            SubscribedUsers user = await _context.SubscribedUsers.Where(user => user.ActiveCode == id).FirstOrDefaultAsync();
            if (user == null) return NotFound();
            user.Actived = false;
            await _context.SaveChangesAsync();
            return RedirectToAction("index", "home");

        }
    }
}
