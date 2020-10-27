using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Models
{
    public class Notice
    {
        public int Id { get; set; }
        [Required]
        public DateTime NoticeTime { get; set; }
        [Required, StringLength(420, MinimumLength = 5, ErrorMessage = "The notice text cannot less 5 exceed 420 characters.")]
        public string NoticeText { get; set; }
        public int NoticeSectionId { get; set; }
        public virtual NoticeSection Notices { get; set; }

    }
}
