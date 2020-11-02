using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackProject.DAL;
using BackProject.Extentions;
using BackProject.Models;
using BackProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackProject.Areas.courses_admin.Controllers
{
    [Area("courses-admin")]
    [Authorize(Roles = "Admin,MainAdmin")]
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UsersController(UserManager<AppUser> userManager, AppDbContext db, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _db = db;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()    
        {
            List<AppUser> appUsers = _userManager.Users.ToList();
            List<UserVM> userVMs = new List<UserVM>();
            foreach (AppUser user in appUsers)
            {
                UserVM userVM = new UserVM()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    Username = user.UserName,
                    Activeted = user.Activeted,
                    Role = ((await _userManager.GetRolesAsync(user))[0])
                };
                userVMs.Add(userVM);
            }
            return View(userVMs);
        }
        public async Task<IActionResult> Status(string id)
        {
            if (id == null) return NotFound();

            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            string role = (await _userManager.GetRolesAsync(user))[0];
            if (role == "MainAdmin") return NotFound();
            if (User.Identity.Name == user.UserName) return NotFound();

            if (User.IsInRole("Admin"))
            {
                if (role == "Admin")
                {
                    return NotFound();
                }
            }
            _db.IncludeCoursesFromModerator(true);
            _db.IncludeEventFromModerator(true);
            _db.IncludeBlogFromModerator(true);

            string checkCategory = _db.CheckUserCourse(user);
            if (checkCategory != "success") return Json(checkCategory);

            checkCategory = _db.CheckUserEvent(user);
            if (checkCategory != "success") return Json(checkCategory);

            checkCategory = _db.CheckUserBlog(user);
            if (checkCategory != "success") return Json(checkCategory);

            if (user.CourseModerators != null)
            {
                foreach (CourseModerator item in user.CourseModerators)
                {
                    item.Activeted = !user.Activeted;
                }
            }
            if (user.EventModerators != null)
            {
                foreach (EventModerator item in user.EventModerators)
                {
                    item.Activeted = !user.Activeted;
                }
            }


            user.Activeted = !user.Activeted;
            await _db.SaveChangesAsync();
            return Json(new
            {
                suc = true,
                status = user.Activeted
            });

        }

        public async Task<IActionResult> ChangeRole(string id)
        {
            if (id == null) return NotFound();
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            string role = (await _userManager.GetRolesAsync(user))[0];
            if (role == "MainAdmin") return NotFound();
            if (User.Identity.Name == user.UserName) return NotFound();

            if (User.IsInRole("Admin"))
            {
                if (role == "Admin")
                {
                    return NotFound();
                }
            }

            UserVM userVM = new UserVM()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Image = user.Image,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Username = user.UserName,
                Activeted = user.Activeted,
                Role = ((await _userManager.GetRolesAsync(user))[0]),
                Roles = _roleManager.Roles.Select(x => x.Name).Where(x => x != "MainAdmin").ToList()
            };
            return View(userVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeRole(string id, string role)
        {
            if (role == null) return NotFound();
            if (id == null) return NotFound();
            if (!await _roleManager.RoleExistsAsync(role)) return NotFound();
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            if (User.Identity.Name == user.UserName) return NotFound();

            string db_role = (await _userManager.GetRolesAsync(user))[0];
            if (db_role == "MainAdmin") return NotFound();

            if (User.Identity.Name == user.UserName) return NotFound();

            if (User.IsInRole("Admin"))
            {
                if (db_role == "Admin")
                {
                    return NotFound();
                }
            }

            string oldRole = (await _userManager.GetRolesAsync(user))[0];
            IdentityResult identityResult = await _userManager.RemoveFromRoleAsync(user, oldRole);
            if (!identityResult.Succeeded)
            {
                return NotFound();
            }

            IdentityResult identityResultNew = await _userManager.AddToRoleAsync(user, role);
            if (!identityResultNew.Succeeded)
            {
                return NotFound();
            }
            return RedirectToAction("index");
        }
        public async Task<IActionResult> ResetPassword(string id)
        {
            if (id == null) return NotFound();
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            string role = (await _userManager.GetRolesAsync(user))[0];
            if (role == "MainAdmin" && User.Identity.Name != user.UserName) return NotFound();

            if (User.IsInRole("Admin"))
            {
                if (role == "Admin" && User.Identity.Name != user.UserName)
                {
                    return NotFound();
                }
            }
            UserVM userVM = new UserVM()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Image = user.Image,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Username = user.UserName,
                Activeted = user.Activeted,
                Role = ((await _userManager.GetRolesAsync(user))[0]),
            };
            return View(userVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string id, string NewPassword)
        {
            if (id == null) return NotFound();
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            string role = (await _userManager.GetRolesAsync(user))[0];
            if (role == "MainAdmin" && User.Identity.Name != user.UserName) return NotFound();

            if (User.IsInRole("Admin"))
            {
                if (role == "Admin" && User.Identity.Name != user.UserName)
                {
                    return NotFound();
                }
            }

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
            return RedirectToAction("index");
        }
    }
}