using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Models
{
    public class BlogModerator
    {
        public int Id { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        public string ModeratorId { get; set; }
        public virtual AppUser Moderator { get; set; }
        public bool IsDeleted { get; set; }
        public bool Activeted { get; set; }
    }
}
