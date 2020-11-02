using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Models
{
    public class SendMessageFromUser
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Please, add your email!"), EmailAddress]
        public string Email { get; set; }
        public string Subject { get; set; }
        [Required(ErrorMessage = "Please, add your message!")]
        public string Message { get; set; }
        public bool IsDeleted { get; set; }
    }
}
