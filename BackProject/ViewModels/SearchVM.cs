using BackProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.ViewModels
{
    public class SearchVM
    {
        public List<Course> Courses { get; set; }
        public List<Event> Events { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
