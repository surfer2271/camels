using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EthicsCap2.Controllers
{
    public class SRKnowledgeAssessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Score()
        {
            return View();
        }


        public IActionResult Questions()
        {
            return View();
        }
    }
}