using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using System;

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using MailKit.Security;

namespace ContactForm.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string message1 { get; set; }

        public void OnPost()
        {
            //string Query takes the entries from the form and then joins them to build a string that 
            //can be used as the message body.
            string query = "Query from " + (Request.Form["Name"]) + " " + (Request.Form["Email"]) + " " + (Request.Form["Query"]);

            var message = new MimeMessage();
            //message.From.Add is the email address you are using to send the message
            message.From.Add(new MailboxAddress("Nigel", "someone@hotmail.com"));
            //message.To.Add provides the email address where you would like to receive the message
            message.To.Add(new MailboxAddress("Nigel", "m0cvo@yahoo.co.uk"));
            //message.Subject provides a subject line header for the email
            message.Subject = "Query";
            //message.Body uses the string query that was created at the top of this page.
            message.Body = new TextPart("plain") { Text = $"{query}" };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
                // Note: only needed if the SMTP server requires authentication
                //this is the user name/email for your smtp server and password.
                client.Authenticate("someone@hotmail.com", "password");

                client.Send(message);
                client.Disconnect(true);
            }

            //The following returns a message for whoever completed the form to contact you.
            if (!StringValues.IsNullOrEmpty(Request.Form["Name"]))
            {
                message1 = $"Thank you {Request.Form["Name"]}, we will be in touch by e-mail.";
            }
        }
    }
}