using BackProject.DAL;
using BackProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Extentions
{
    public static class Extention
    {
        public static bool IsType(this IFormFile file, string type)
        {
            return file.ContentType.Contains(type);
        }

        public static bool MaxLength(this IFormFile file, int kb)
        {
            return file.Length / 1024 > kb;
        }
        public async static Task<string> SaveImage(this IFormFile file, string root, params string[] paths)
        {
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            foreach(string item in paths)
            {
                root = Path.Combine(root, item);
            }
            string resultPash = Path.Combine(root, fileName);
            using (FileStream fileStream = new FileStream(resultPash, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }
        public static bool PhotoValidate(this IFormFile Photo, ModelStateDictionary modelState)
        {
            if (Photo == null)
            {
                modelState.AddModelError("Photo", "Please select photo for course!!!");
                return false;
            }
            if (!Photo.IsType("image"))
            {
                modelState.AddModelError("Photo", "Please select image types!!!");
                return false;
            }

            if (Photo.MaxLength(3000))
            {
                modelState.AddModelError("Photo", "Image length must be max 300kb!!!");
                return false;
            }
            return true;
        }
        public static void GetAllErrors(this ModelStateDictionary modelState, IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError("", error.Description + " ");
            }
        }

        public static void IncludeCategory(this AppDbContext _context, bool active)
        {
            _context.CourseCategories
            .Where(c => !c.IsDeleted);
            if (active)
            {
                _context.CourseCategories.Where(c => c.Activeted);
            };
            _context.CourseCategories
            .Include(c => c.Category)
            .Where(c => c.Category.Activeted && !c.Category.IsDeleted)
            .ToList();
        }
        public static void IncludeModerators(this AppDbContext _context, bool active)
        {
            _context.CourseModerators
            .Where(c => !c.IsDeleted);
            if (active)
            {
                _context.CourseModerators.Where(c => c.Activeted);
            };
            _context.CourseModerators
            .Include(c => c.Moderator)
            .Where(c => c.Moderator.Activeted)
            .ToList();
        }
        public static void IncludeCourses(this AppDbContext _context, bool active)
        {
            _context.CourseCategories
            .Where(c => !c.IsDeleted);
            if (active)
            {
                _context.CourseCategories.Where(c => c.Activeted);
            };
            _context.CourseCategories
            .Include(c => c.Course)
            .Where(c => c.Course.Activeted && !c.Course.IsDeleted)
            .ToList();
        }
        public static void IncludeCoursesFromModerator(this AppDbContext _context, bool active)
        {
            _context.CourseModerators
            .Where(c => !c.IsDeleted);
            if (active)
            {
                _context.CourseModerators.Where(c => c.Activeted);
            };
            _context.CourseModerators
            .Include(c => c.Course)
            .Where(c => c.Course.Activeted && !c.Course.IsDeleted)
            .ToList();
        }
        public static void IncludeCategoryEvent(this AppDbContext _context, bool active)
        {
            _context.EventCategories
            .Where(c => !c.IsDeleted);
            if (active)
            {
                _context.EventCategories.Where(c => c.Activeted);
            };
            _context.EventCategories
            .Include(c => c.Category)
            .Where(c => c.Category.Activeted && !c.Category.IsDeleted)
            .ToList();
        }
        public static void IncludeModeratorsEvent(this AppDbContext _context, bool active)
        {
            _context.EventModerators
            .Where(c => !c.IsDeleted);
            if (active)
            {
                _context.EventModerators.Where(c => c.Activeted);
            };
            _context.EventModerators
            .Include(c => c.Moderator)
            .Where(c => c.Moderator.Activeted)
            .ToList();
        }
        public static void IncludeEvents(this AppDbContext _context, bool active)
        {
            _context.EventCategories
            .Where(c => !c.IsDeleted);
            if (active)
            {
                _context.EventCategories.Where(c => c.Activeted);
            };
            _context.EventCategories
            .Include(c => c.Event)
            .Where(c => c.Event.Activeted && !c.Event.IsDeleted)
            .ToList();
        }
        public static void IncludeEventFromModerator(this AppDbContext _context, bool active)
        {
            _context.EventModerators
            .Where(c => !c.IsDeleted);
            if (active)
            {
                _context.EventModerators.Where(c => c.Activeted);
            };
            _context.EventModerators
            .Include(c => c.Event)
            .Where(c => c.Event.Activeted && !c.Event.IsDeleted)
            .ToList();
        }

        public static void IncludeCategoryBlog(this AppDbContext _context, bool active)
        {
            _context.BlogCategories
            .Where(b => !b.IsDeleted);
            if (active)
            {
                _context.BlogCategories.Where(b => b.Activeted);
            };
            _context.BlogCategories
            .Include(b => b.Category)
            .Where(b => b.Category.Activeted && !b.Category.IsDeleted)
            .ToList();
        }
        public static void IncludeModeratorsBlog(this AppDbContext _context, bool active)
        {
            _context.BlogModerators
            .Where(b => !b.IsDeleted);
            if (active)
            {
                _context.BlogModerators.Where(b => b.Activeted);
            };
            _context.BlogModerators
            .Include(b => b.Moderator)
            .Where(b => b.Moderator.Activeted)
            .ToList();
        }
        public static void IncludeBlogs(this AppDbContext _context, bool active)
        {
            _context.BlogCategories
            .Where(b => !b.IsDeleted);
            if (active)
            {
                _context.BlogCategories.Where(b => b.Activeted);
            };
            _context.BlogCategories
            .Include(b => b.Blog)
            .Where(b => b.Blog.Activeted && !b.Blog.IsDeleted)
            .ToList();
        }
        public static void IncludeBlogFromModerator(this AppDbContext _context, bool active)
        {
            _context.BlogModerators
            .Where(b => !b.IsDeleted);
            if (active)
            {
                _context.BlogModerators.Where(b => b.Activeted);
            };
            _context.BlogModerators
            .Include(b => b.Blog)
            .Where(b => b.Blog.Activeted && !b.Blog.IsDeleted)
            .ToList();
        }


        public static string CheckCategoryCourse(this AppDbContext _context, Category category, string str)
        {
            int count = 0;
            if (((category.Activeted == true && str == "delete") || (category.Activeted == true && str == "disable")) && (category.CourseCategories != null))
            {
                foreach (CourseCategory courseCategory in category.CourseCategories)
                {
                    count = courseCategory.Course.CourseCategories.Where(c => c.Activeted == true).Count();
                    if (count < 2) return "Course should have less one category! You can't " + str + " this category!";
                }
            }
            else
            {
                _context.IncludeCourses(false);
            }
            return "success";
        }
        public static string CheckCategoryEvent(this AppDbContext _context, Category category, string str)
        {
            int count = 0;
            if (((category.Activeted == true && str == "delete") || (category.Activeted == true && str == "disable")) && (category.EventCategories != null))
            {
                foreach (EventCategory eventCategory in category.EventCategories)
                {
                    count = eventCategory.Event.EventCategories.Where(e => e.Activeted == true).Count();
                    if (count < 2) return "Event should have less one category! You can't " + str + " this category!";
                }
            }
            else
            {
                _context.IncludeEvents(false);
            }
            return "success";
        }
        public static string CheckCategoryBlog(this AppDbContext _context, Category category, string str)
        {
            int count = 0;
            if (((category.Activeted == true && str == "delete") || (category.Activeted == true && str == "disable")) && (category.BlogCategories != null))
            {
                foreach (BlogCategory blogCategory in category.BlogCategories)
                {
                    count = blogCategory.Blog.BlogCategories.Where(b => b.Activeted == true).Count();
                    if (count < 2) return "Blog should have less one category! You can't " + str + " this category!";
                }
            }
            else
            {
                _context.IncludeBlogs(false);
            }
            return "success";
        }

        public static string CheckUserCourse(this AppDbContext _context, AppUser user)
        {
            int count = 0;
            if (user.Activeted == true && user.CourseModerators != null)
            {
                foreach (CourseModerator courseModerator in user.CourseModerators)
                {
                    count = courseModerator.Course.CourseModerators.Where(c => c.Activeted == true).Count();
                    if (count < 2) return "Course should have less one moderator! You can't disable this user";
                }
            }
            else
            {
                _context.IncludeCourses(false);
            }
            return "success";
        }
        public static string CheckUserEvent(this AppDbContext _context, AppUser user)
        {
            int count = 0;
            if (user.Activeted == true && user.EventModerators != null)
            {
                foreach (EventModerator eventModerator in user.EventModerators)
                {
                    count = eventModerator.Event.EventModerators.Where(c => c.Activeted == true).Count();
                    if (count < 2) return "Event should have less one moderator! You can't disable this user";
                }
            }
            else
            {
                _context.IncludeEvents(false);
            }
            return "success";
        }
        public static string CheckUserBlog(this AppDbContext _context, AppUser user)
        {
            int count = 0;
            if (user.Activeted == true && user.BlogModerators != null)
            {
                foreach (BlogModerator BlogModerators in user.BlogModerators)
                {
                    count = BlogModerators.Blog.BlogModerators.Where(b => b.Activeted == true).Count();
                    if (count < 2) return "Blog should have less one moderator! You can't disable this user";
                }
            }
            else
            {
                _context.IncludeBlogs(false);
            }
            return "success";
        }
        public static List<Tag> GetTags(this AppDbContext _context)
        {
            int total = _context.Tags.Count();
            Random r = new Random();
            int offset = r.Next(0, total);
            return _context.Tags.Where(t => t.Activeted == true && t.IsDeleted == false).Skip(offset).Take(6).ToList();
        }
    }

}
