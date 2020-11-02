using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Models
{
    public class SubscribedUsers
    {
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        public string ActiveCode { get; set; }
        public bool Actived { get; set; }
    }
}
