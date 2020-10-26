using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required, StringLength(15,ErrorMessage = "The name cannot exceed 15 characters.")]

        public string Name { get; set; }
        [Required, StringLength(20, ErrorMessage = "The surname cannot exceed 20 characters.")]

        public string Surname { get; set; }
        [Required, StringLength(40, ErrorMessage = "The position cannot exceed 40 characters.")]
        public string Position { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required, EmailAddress ]
        public string Email { get; set; }
        [Required, Phone, StringLength(25, ErrorMessage = "The email value cannot exceed 25 characters.")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Skype { get; set; }
        [Url]
        public string Facebook { get; set; }
        [Url]
        public string Pinterest { get; set; }
        [Url]
        public string Twitter { get; set; }
        public TeacherDescription teacherDescription { get; set; }
        public bool Activeted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
