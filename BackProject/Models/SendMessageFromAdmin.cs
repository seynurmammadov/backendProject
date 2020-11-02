using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Models
{
    public class SendMessageFromAdmin
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        [Required(ErrorMessage = "Please, add your message!")]
        public string Message { get; set; }
    }
}
