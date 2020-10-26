using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required, StringLength(100, MinimumLength = 5, ErrorMessage = "The name cannot not less 5 exceed 100 characters.")]
        public string Name { get; set; }
        [Required, StringLength(600, MinimumLength = 70, ErrorMessage = "The short description cannot less 70 exceed 600 characters.")]
        public string ShortDescription { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Created_at { get; set; }
        public ICollection<CourseModerator> CourseModerators { get; set; }
        public ICollection<CourseCategory> CourseCategories { get; set; }
        public bool IsDeleted { get; set; }
        public bool Activeted { get; set; }

    }
}
