using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Wexnet me= new Wexnet();
            return View(Wexnet.DBWexnet);
        }
       [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind(include: "Id,Hestighet,RingNamn,IPAdressDistA,PortDistA,IPAdressDistB,PortDistB")]Wexnet wexnet)
        {
            if(ModelState.IsValid)
            {
                Wexnet.DBWexnet.Add(wexnet);
                return RedirectToAction("Index");
            }
            return View(wexnet);
        }
        public IActionResult Delete(int id)
        {
            Wexnet wexnet = Wexnet.DBWexnet.SingleOrDefault(m => m.Id == id);
            Wexnet.DBWexnet.Remove(wexnet);
            return RedirectToAction("Index");
        }
        
        
       
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
