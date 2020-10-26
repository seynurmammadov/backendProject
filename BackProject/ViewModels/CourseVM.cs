using BackProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.ViewModels
{
    public class CourseVM
    {
        public Course Course { get; set; }
        public List<Course> LastestCourse { get; set; }
        public List<Tag> Tags { get; set; }

    }
}
