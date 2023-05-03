using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmailSenderMvc.Models.Domains
{
    public class Email
    {
        public int Id { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Sender { get; set; }

        [Required]
        public string Recipient { get; set; }
        public string Attachment { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        
    }
}