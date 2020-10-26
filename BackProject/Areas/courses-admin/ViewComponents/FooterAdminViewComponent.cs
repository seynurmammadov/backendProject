using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Areas.courses_admin.ViewComponents 
{ 
    [Area("courses-admin")]

    public class FooterAdminViewComponent : ViewComponent
    {
     
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
