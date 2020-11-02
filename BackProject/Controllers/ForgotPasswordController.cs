using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using BackProject.DAL;
using BackProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackProject.Controllers
{
    public class ForgotPasswordController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<AppUser> _userManager;


        public ForgotPasswordController( AppDbContext context, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("index", "home");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string User)
        {
            if (User.Length == 0) return NotFound();
            AppUser user = await _userManager.FindByEmailAsync(User);
            if (user == null)
            {
                ModelState.AddModelError("", "Email is wrong!");
                return View();
            }
            if (user.ActiveCode != null)
            {
                ModelState.AddModelError("", "We send email in your address!");
                return View();
            }
            user.ActiveCode = Guid.NewGuid().ToString();
            await _context.SaveChangesAsync();
            string url  = _contextAccessor.HttpContext.Request.Scheme + System.Uri.SchemeDelimiter + _contextAccessor.HttpContext.Request.Host.Value + "/reset/index/" + user.ActiveCode;
            MailMessage message = new MailMessage();
            message.From = new MailAddress("eduhomeproject@gmail.com", "Home Education");
            message.To.Add(new MailAddress(user.Email));

            message.Subject = "Reset Password";
            message.Body = "We heard that you lost your password. Sorry about that!<br>"+
                "<br>But don’t worry!You can use the following link to<span class='il' >reset</span> your password:<br>"+
                "<br><a href = "+ url+" rel='noreferrer' target='_blank'>"+ url + "</a><br>"+
                "<br>If you don’t use this link within 3 hours, it will expire.<br>"+
                "Thanks,<br>"+
                "The Seynur Team";
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            smtp.Credentials = new NetworkCredential("eduhomeproject@gmail.com", "seynur2462736");
            smtp.Send(message);

            TempData["suc"] = "We send email in your address, please check inbox.";
            return RedirectToAction(nameof(Index));
        }
    }
}
