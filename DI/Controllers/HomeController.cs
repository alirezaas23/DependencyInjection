using DI.Interfaces;
using DI.Models;
using DI.Services;
using DI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
        private KevenegarApiViewModel _kevenegarApi;
        private PasargadBankViewModel _pasargadBank;

        public HomeController(ISmsService smsService, IOptions<KevenegarApiViewModel> kavenegarOptions, IOptions<PasargadBankViewModel> pasargadBankOptions)
        {
            _smsService = smsService;
            _kevenegarApi = kavenegarOptions.Value;
            _pasargadBank = pasargadBankOptions.Value;
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
            ViewBag.KavenegarApi = _kevenegarApi.Api;
            ViewBag.PasargadBankId = _pasargadBank.TerminalId;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
