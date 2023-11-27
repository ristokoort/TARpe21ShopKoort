﻿using Microsoft.AspNetCore.Mvc;
using TARpe21ShopRisto.Core.Dto;
using TARpe21ShopRisto.Core.ServiceInterface;
using TARpe21ShopRisto.Models.Email;

namespace TARpe21ShopRisto.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendEmail(EmailViewModel vm)
        {
            var dto = new EmailDto()
            {
                To = vm.To,
                Subject = vm.Subject,
                Body = vm.Body,
            };
            _emailService.SendEmail(dto);
            return RedirectToAction(nameof(Index)); 
        }
    }
}
