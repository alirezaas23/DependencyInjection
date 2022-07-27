using DI.Interfaces;
using DI.Models;
using DI.Services;
using DI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Controllers
{
    public class HomeController : Controller
    {
        private ISmsService _smsService;

        public HomeController(ISmsService smsService)
        {
            _smsService = smsService;
        }

        public IActionResult Index()
        {
            var status = new IndexViewModel()
            {
                SMSStatus = _smsService.SendSMS()
            };
            ViewBag.Message = status.SMSStatus;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
