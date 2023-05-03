using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmailSenderMvc.Models.ViewModels
{
    public class EmailViewModel
    {
        [Required]
        public string Sender { get; set; }

        [Required]
        public string Recipient { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Password { get; set; }
        public string Attachment { get; set; }
        public string Body { get; set; }
    }
}