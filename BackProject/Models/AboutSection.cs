using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Models
{
    public class AboutSection
    {
        public int Id { get; set; }
        [Required, StringLength(50, MinimumLength = 5, ErrorMessage = "The name cannot less 5 exceed 50 characters.")]
        public string Title { get; set; }
        [Required, StringLength(420, MinimumLength = 5, ErrorMessage = "The Description cannot less 5 exceed 420 characters.")]
        public string Description { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
