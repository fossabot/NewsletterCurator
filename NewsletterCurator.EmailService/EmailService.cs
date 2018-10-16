﻿using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NewsletterCurator.EmailService
{
    public class EmailService
    {
        private readonly SmtpClient smtpClient;

        public EmailService(SmtpClient smtpClient)
        {
            this.smtpClient = smtpClient;
        }

        public async Task SendAsync(string html)
        {
            await smtpClient.SendMailAsync(new MailMessage(new MailAddress("curated@newsletters.cdemi.io", "cdemi's Curated Newsletter"), new MailAddress("christopher.demicoli@outlook.com", "Christopher Demicoli"))
            {
                Subject = $"{DateTime.Now.ToString("dd MMMM yyyy")} - cdemi's Curated Newsletter",
                Body = html,
                IsBodyHtml = true
            });
        }

        public async Task SendValidationEmailAsync(string email, string validationURL)
        {
            await smtpClient.SendMailAsync(new MailMessage(new MailAddress("curated@newsletters.cdemi.io", "cdemi's Curated Newsletter"), new MailAddress(email))
            {
                Subject = $"Validate your Email",
                Body = $"Welcome to cdemi's Curated Newsletter! Please validate your email by visitng this URL: {validationURL}",
                IsBodyHtml = false
            });
        }
    }
}
