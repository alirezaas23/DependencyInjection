using Microsoft.AspNetCore.Mvc;
using DI.Services;
using System.Collections.Generic;

namespace DI.Controllers
{
    public class LifeTimeController : Controller
    {
        private TransientService _transientService;
        private ScopedService _scopedService;
        private SingletonService _singletonService;
        public LifeTimeController(TransientService transientService, ScopedService scopedService, SingletonService singletonService)
        {
            _transientService = transientService;
            _scopedService = scopedService;
            _singletonService = singletonService;
        }
        
        public IActionResult Index()
        {
            var lifeTimeList = new List<string>();
            lifeTimeList.Add($"Transient Guid from controller = {_transientService.GetGuid()}");
            lifeTimeList.Add(HttpContext.Items["TransientService"].ToString());
            lifeTimeList.Add("--------------------------------------------------------------------");

            lifeTimeList.Add($"Scoped Guid from controller = {_scopedService.GetGuid()}");
            lifeTimeList.Add(HttpContext.Items["ScopedService"].ToString());
            lifeTimeList.Add("--------------------------------------------------------------------");

            lifeTimeList.Add($"Singleton Guid from controller = {_singletonService.GetGuid()}");
            lifeTimeList.Add(HttpContext.Items["SingletonSerive"].ToString());
            lifeTimeList.Add("--------------------------------------------------------------------");

            ViewData["lifeTimeList"] = lifeTimeList;
            return View();
        }
    }
}
