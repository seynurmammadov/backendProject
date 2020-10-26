using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.ViewComponents
{
    public class SiteTitleViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string str)
        {
            ViewBag.Title = str;
            return View();
        }
    }
}
