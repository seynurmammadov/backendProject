using BackProject.DAL;
using BackProject.Extentions;
using BackProject.Models;
using BackProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Helpers
{
    public static class Helper
    {
        public static void DeleteFile(string root, string fileName, params string[] paths)
        {
            foreach (string item in paths)
            {
                root = Path.Combine(root, item);
            }
            string deletePath = Path.Combine(root, fileName);
            if (System.IO.File.Exists(deletePath))
            {
                System.IO.File.Delete(deletePath);
            }
        }
        public enum Roles {
            Admin,
            Member,
            courseModerator,
            MainAdmin
        }

        public static async Task<object[]> CreateVM(AppDbContext _context, UserManager<AppUser> _userManager)
        {
            List<Category> ctg = _context.Categories.Where(c => !c.IsDeleted && c.Activeted).ToList();
            List<AppUser> appUsers = _userManager.Users.Where(u => u.Activeted).ToList();
            List<UserVM> userVMs = new List<UserVM>();
            foreach (AppUser user in appUsers)
            {
                string moderator = (await _userManager.GetRolesAsync(user))[0];
                if (moderator == Helpers.Helper.Roles.courseModerator.ToString())
                {
                    UserVM userVM = new UserVM()
                    {
                        Id = user.Id,
                        Username = user.UserName
                    };
                    userVMs.Add(userVM);
                }

            }
            object[] obj = {ctg,userVMs};
            return obj;
        }
        public static bool CheckLengthArray<T>(T[] arr, ModelStateDictionary modelState)
        {
            if (arr.Length == 0) { 
                modelState.AddModelError("", "Select Options !!!");
                return true;
            }
            return false;
        }
      /*  public static bool IsExistName(AppDbContext _context)
        {
            bool IsExist = _context.Courses.Where(c => c.IsDeleted == false)
              .Any(c => c.Name.ToLower() == course.Name.ToLower());
            if (IsExist)
            {
                ModelState.AddModelError("Name", "This product title already exist!!!");
                return View(course);
            }
        }*/
    
    }
}
