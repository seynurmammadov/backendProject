using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Models
{
    public class CourseModerator
    {
        public int Id { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public string ModeratorId { get; set; }
        public virtual AppUser Moderator { get; set; }
        public bool IsDeleted { get; set; }
        public bool Activeted { get; set; }

    }
}
