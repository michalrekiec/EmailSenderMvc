using EmailSenderMvc.Models;
using EmailSenderMvc.Models.Domains;
using EmailSenderMvc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EmailSenderMvc.Repositories
{
    public class EmailRepository
    {
        public void AddEmail(EmailViewModel emailVm, string userId)
        {
            var emailToAdd = new Email();

            emailToAdd.Sender = emailVm.Sender;
            emailToAdd.Recipient = emailVm.Recipient;
            emailToAdd.Body = emailVm.Body;
            emailToAdd.CreatedDate = DateTime.Now;
            emailToAdd.Subject = emailVm.Subject;
            emailToAdd.Attachment = emailVm.Attachment;
            emailToAdd.UserId = userId;
            

            using (var context = new ApplicationDbContext())
            {
                context.Emails.Add(emailToAdd);
                context.SaveChanges();
            }
        }

        public List<Email> GetEmailList(string userId)
        {
            var emailList = new List<Email>();

            using(var context = new ApplicationDbContext())
            {
                emailList = context.Emails.Where(x => x.UserId == userId).ToList();
            }

            return emailList;
        }
    }
}