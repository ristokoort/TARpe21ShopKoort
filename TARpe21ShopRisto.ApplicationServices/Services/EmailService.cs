using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopRisto.Core.Dto;
using TARpe21ShopRisto.Core.ServiceInterface;
using MailKit.Net.Smtp;

namespace TARpe21ShopRisto.ApplicationServices.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public void SendEmail(EmailDto dto)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(dto.To =));
            email.Subject = dto.Subject;
            email.Body = new TextPart(MineKit.Text.TextFormat.Html)
            {
                Text = dto.Body
            };

            using var sntp = new SmtpClient();

            sntp.Connect(_config.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            sntp.Authenticate(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value);
            sntp.Send(email);
            sntp.Discconnect(true);
        }
    }
}
