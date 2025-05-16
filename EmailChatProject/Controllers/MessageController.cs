
using EmailChatProject.Context;
using EmailChatProject.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;

namespace EmailChatProject.Controllers
{
    public class MessageController : Controller
    {
        private readonly ContextEmail _contextEmail;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(ContextEmail contextEmail, UserManager<AppUser> userManager)
        {
            _contextEmail = contextEmail;
            _userManager = userManager;
        }



        [Authorize]
        public async Task<IActionResult> Inbox(string search)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userEmail = user.Email;
            ViewBag.email = userEmail;
            ViewBag.namesurname = user.Name + " " + user.Surname;
            ViewBag.SearchTerm = search;
            var messages = _contextEmail.messages
                .Where(x => x.ReceiverMail == userEmail && x.Isread == true);

            if (!string.IsNullOrEmpty(search))
            {
                messages = messages.Where(x => x.Subject.ToLower().Contains(search.ToLower()));
            }

            return View(messages.ToList());
        }
        [HttpGet]
        public IActionResult CreateMessage()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessage(Message message)
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string senderEmail = values.Email;
            string senderName = values.Name;

            message.SenderMail = senderEmail;
            message.SenderName = senderName;
            message.Isread = true;
            message.SendDate = DateTime.Now;
            _contextEmail.messages.Add(message);
            _contextEmail.SaveChanges();
            ViewBag.Success = "Gönderim işlemi başarılı!";
            return View("~/Views/Message/NewMessage.cshtml");
        }
        public async Task<IActionResult> SendBox(string search)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            string userEmail = user.Email;
            ViewBag.email = userEmail;
            ViewBag.namesurname = user.Name + " " + user.Surname;
            ViewBag.SearchTerm = search;
            var sentEmails = _contextEmail.messages
                .Where(x => x.SenderMail == userEmail && x.Isread == true);
            if (!string.IsNullOrEmpty(search))
            {
                string term = search.ToLower();
                sentEmails = sentEmails.Where(x =>
                    x.Subject.ToLower().Contains(term) ||
                    x.ReceiverMail.ToLower().Contains(term) ||
                    x.MessageDetail.ToLower().Contains(term)
                );
            }
            return View(sentEmails.ToList());
        }
        public async Task<IActionResult> MessageDetail(int id)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);            
            var value = _contextEmail.messages.FirstOrDefault(x => x.MessageId == id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeMessageStatus(List<int> messageID)
        {
            foreach (var id in messageID)
            {
                var value = await _contextEmail.messages.FindAsync(id);
                if (value != null)
                {
                    value.Isread = false;

                }
            }
            await _contextEmail.SaveChangesAsync();
            return RedirectToAction("TrashBox");
        }

        public IActionResult TrashBox()
        {
            var deletedValues = _contextEmail.messages.Where(x => x.Isread == false).ToList();
            return View(deletedValues);
        }
        public async Task<IActionResult> MessageCount()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.RecipientEmailAddressCount = _contextEmail.messages
                         .Where(x => x.ReceiverMail == values.Email)
                         .Count();

            ViewBag.SenderEmailAddressCount = _contextEmail.messages
                                     .Where(x => x.SenderMail == values.Email)
                                     .Count();
            return View();
        }



    }
}