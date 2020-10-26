using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [Required, StringLength(20, ErrorMessage = "The name cannot exceed 20 characters.")]

        public string Name { get; set; }
        public bool Activeted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
