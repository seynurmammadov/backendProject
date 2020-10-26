using BackProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.ViewModels
{
    public class EventVM
    {
        public Event Event { get; set; }
        public List<Event> LastestEvent { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
