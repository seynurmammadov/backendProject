using BackProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace BackProject.ViewModels
{
    public class BlogVM
    {
        public Blog Blog { get; set; }
        public List<Blog> LastestBlog { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
