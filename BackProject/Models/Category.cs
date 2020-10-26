using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, StringLength(30, ErrorMessage = "The name cannot exceed 30 characters.")]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public bool Activeted { get; set; }
        public ICollection<CourseCategory> CourseCategories { get; set; }
        public ICollection<EventCategory> EventCategories { get; set; }
        public ICollection<BlogCategory> BlogCategories { get; set; }

    }
}
