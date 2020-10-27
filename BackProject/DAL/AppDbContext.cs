using BackProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BackProject.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<CourseModerator> CourseModerators { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventModerator> EventModerators { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherDescription> TeacherDescriptions { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogModerator> BlogModerators { get; set; }
        public DbSet<SiteInfo> SiteInfo { get; set; }
        public DbSet<Sliders> Sliders { get; set; }
    }
}
