using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.ViewModels
{
    public class UserVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Image { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool Activeted { get; set; }
        public string Role { get; set; }
        public List<string> Roles { get; set; }

    }
}
