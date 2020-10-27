using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Models
{
    public class TestimonialSection
    {
        public int Id { get; set; }
        [Required, StringLength(15, ErrorMessage = "The name cannot exceed 15 characters.")]
        public string Name { get; set; }
        [Required, StringLength(20, ErrorMessage = "The surname cannot exceed 20 characters.")]
        public string Surname { get; set; }
        [Required, StringLength(40, ErrorMessage = "The position cannot exceed 40 characters.")]
        public string Position { get; set; }
        [Required, StringLength(600, MinimumLength = 10, ErrorMessage = "The short description cannot less 10 exceed 600 characters.")]
        public string ShortDescription { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
