using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using EmailSenderMvc.Models.ViewModels;
using System.Net;

namespace EmailSenderMvc.Models
{
    public class SendMail
    {
        public void Send(EmailViewModel evm)
        {
            // gmail parameters

            string host = "smtp.gmail.com";
            int port = 587;

            using(MailMessage mail = new MailMessage
                (evm.Sender, evm.Recipient, evm.Subject, evm.Body))
            {
                mail.Attachments.Add(new Attachment(evm.Attachment));

                using(SmtpClient smtp = new SmtpClient(host, port))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(evm.Sender, evm.Password);
                    smtp.Send(mail);
                }
            }
        }
    }
}