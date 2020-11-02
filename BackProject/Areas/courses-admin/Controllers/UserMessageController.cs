using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using BackProject.DAL;
using BackProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackProject.Areas.courses_admin.Controllers
{
    [Area("courses-admin")]
    [Authorize(Roles = "Admin,MainAdmin")]
    public class UserMessageController : Controller
    {
        private readonly AppDbContext _context;

        public UserMessageController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.SendMessageFromUsers.Where(m=>!m.IsDeleted).ToList());
        }

        public async Task<IActionResult> Info(int? id)
        {
            if (id == null) NotFound();
            SendMessageFromUser message = _context.SendMessageFromUsers.FirstOrDefault(m => m.Id == id);
            if (message == null) NotFound();
            await _context.SaveChangesAsync();
            return View(message);
        }

        public IActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(int id, SendMessageFromAdmin sendMessage)
        {
            if (ModelState.IsValid)
            {
                var email = _context.SendMessageFromUsers.FirstOrDefault(m => m.Id == id).Email;
                sendMessage.Email = email;

                MailMessage message = new MailMessage();
                message.From = new MailAddress("eduhomeproject@gmail.com", "Home Education");
                message.To.Add(new MailAddress(sendMessage.Email));

                message.Subject = sendMessage.Subject;
                message.Body = sendMessage.Message;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                smtp.Credentials = new NetworkCredential("eduhomeproject@gmail.com", "seynur2462736");
                smtp.Send(message);

                return RedirectToAction(nameof(Index));
            }
            return View(sendMessage);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            SendMessageFromUser msg = _context.SendMessageFromUsers.Find(id);
            if (msg == null) return NotFound();

            msg.IsDeleted = true;
            await _context.SaveChangesAsync();
            return Json("Deleted");
        }
    }
}
