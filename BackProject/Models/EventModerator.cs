using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Models
{
    public class EventModerator
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
        public string ModeratorId { get; set; }
        public virtual AppUser Moderator { get; set; }
        public bool IsDeleted { get; set; }
        public bool Activeted { get; set; }
    }
}
