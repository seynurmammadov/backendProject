using BackProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.ViewModels
{
    public class HomeVM
    {
        public List<Sliders> Sliders  { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Course> Courses { get; set; }
        public List<Event> Events { get; set; }
        public List<Blog> Blogs { get; set; }
        public AboutSection AboutSections { get; set; }
        public NoticeSection NoticeSections { get; set; }
        public List<TestimonialSection> TestimonialSections { get; set; }
    }
}
