using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Models
{
    public class BlogCategory
    {
        public int Id { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public bool IsDeleted { get; set; }
        public bool Activeted { get; set; }
    }
}
