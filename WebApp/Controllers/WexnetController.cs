using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class WexnetController : Controller
    {
        

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Wexnet wexnet)
        {
            string hestighet;
            hestighet = wexnet.Hestighet;

            if (hestighet == "1")
            {
                return Content($"Python3 config-access-ring.py {wexnet.RingNamn}  {wexnet.IPAdressDistA}  Gi0/0/0/{wexnet.PortDistA}  {wexnet.IPAdressDistB} Gi0/0/0/{wexnet.PortDistB}");
            }
            else
            {
                return Content($"Python3 config-gen_new_access_ring{wexnet.Hestighet}g.py  {wexnet.RingNamn} {wexnet.IPAdressDistA} Te0/0/0/{wexnet.PortDistA} {wexnet.IPAdressDistB} Te0/0/0/{wexnet.PortDistB}");
            }
        }

      public IActionResult File()
        {
            return View("File");
        }
        [HttpPost]
        public IActionResult GetFile()
        {
            
            return RedirectToAction("File");
        }
    }
}
