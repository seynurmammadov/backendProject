using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Models
{
    public class NoticeSection
    {
        public int Id { get; set; }
        [Url] 
        [Required]
        public string VideoUrl { get; set; }
        public ICollection<Notice> Notices { get; set; }


    }
}
