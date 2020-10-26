using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Models
{
    public class TeacherDescription
    {
        public int Id { get; set; }
       
        [Required]
        public string Description { get; set; }
        [Required]
        public int LanguageLevel { get; set; }
        [Required]
        public int TeamLeaderLevel { get; set; }
        [Required]
        public int DevelopmentLevel { get; set; }
        [Required]
        public int DesingLevel { get; set; }
        [Required]
        public int CommunicationLevel { get; set; }
        [Required]
        public int InnovationLevel { get; set; }
        public int  TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

    }
}
