using EmailSenderMvc.Models;
using EmailSenderMvc.Models.Domains;
using EmailSenderMvc.Models.ViewModels;
using EmailSenderMvc.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmailSenderMvc.Controllers
{
    public class HomeController : Controller
    {
        private EmailRepository _emailRepo = new EmailRepository();

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(EmailViewModel emailVm)
        {
            var sendMail = new SendMail();
            var userId = User.Identity.GetUserId();
            
            try
            {
                sendMail.Send(emailVm);
                _emailRepo.AddEmail(emailVm, userId);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult MailList(string userId)
        {
            var vm = new List<Email>();

            vm = _emailRepo.GetEmailList(userId);

            return View(vm);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}