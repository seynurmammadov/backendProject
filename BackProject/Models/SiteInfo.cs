using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Models
{
    public class SiteInfo
    {
        public int Id { get; set; }
        [Required,StringLength(60, MinimumLength =5, ErrorMessage = "The title value cannot less 5 exceed 60 characters.")]
        public string Title { get; set; }
        [Required, Phone, StringLength(25, ErrorMessage = "The phone number value cannot exceed 25 characters.")]
        public string PhoneNumber1 { get; set; }
        [Phone, StringLength(25, ErrorMessage = "The phone number value cannot exceed 25 characters.")]
        public string PhoneNumber2 { get; set; }
        public string Logo { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required, StringLength(200, MinimumLength = 20, ErrorMessage = "The site description value cannot less 20 exceed 200 characters.")]
        public string ShortDescription { get; set; }
        [Url]
        public string Facebook { get; set; }
        [Url]
        public string Pinterest { get; set; }
        [Url]
        public string Twitter { get; set; }
        [Required, StringLength(100, ErrorMessage = "The address value cannot exceed 100 characters.")]
        public string Address { get; set; }

        [Required, EmailAddress ,StringLength(25, ErrorMessage = "The email value cannot exceed 25 characters.")]
        public string Email { get; set; }
        public string SiteUrl { get; set; }
        [Required]
        public double LocationLatitude { get; set; }
        [Required]
        public double LocationLongitude { get; set; }


    }
}
