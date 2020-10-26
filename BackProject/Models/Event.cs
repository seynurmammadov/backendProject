using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required, StringLength(100, MinimumLength = 5, ErrorMessage = "The title cannot less 5 exceed 100 characters.")]

        public string Title { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Created_at { get; set; }
        [Required, StringLength(100, MinimumLength = 5, ErrorMessage = "The name cannot exceed 100 characters.")]
        public string Venue { get; set; }
        public bool IsDeleted { get; set; }
        public bool Activeted { get; set; }
        public ICollection<EventModerator> EventModerators { get; set; }
        public ICollection<EventCategory> EventCategories { get; set; }
       
    }
}
