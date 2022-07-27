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
        public IActionResult Index()
        {
            var smsService = new KavenegarService();
            var status = new IndexViewModel();
            status.SMSStatus = smsService.SendSMS();
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
