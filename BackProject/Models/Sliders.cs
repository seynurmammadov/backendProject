using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Models
{
    public class Sliders { 
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [NotMapped]
        public IFormFile[] Photos { get; set; }
        public bool Activeted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
