using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Models
{
    public class AppUser:IdentityUser
    {
        [Required, StringLength(15, ErrorMessage = "The name cannot exceed 15 characters.")]
        public string Name { get; set; }
        [Required, StringLength(20, ErrorMessage = "The name cannot exceed 20 characters.")]
        public string Surname { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public bool Activeted { get; set; }
        public ICollection<CourseModerator> CourseModerators { get; set; }
        public ICollection<EventModerator> EventModerators { get; set; }
        public ICollection<BlogModerator> BlogModerators { get; set; }


    }
}
