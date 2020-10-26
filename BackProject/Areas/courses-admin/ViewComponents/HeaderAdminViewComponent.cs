using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackProject.DAL;
using BackProject.Models;
using Microsoft.AspNetCore.Identity;
using BackProject.ViewModels;

namespace BackProject.Areas.courses_admin.ViewComponents
{
    [Area("courses-admin")]

    public class HeaderAdminViewComponent:ViewComponent
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;

        public HeaderAdminViewComponent(AppDbContext db , UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            AppUser user = await _userManager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)User);

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
    }
}
