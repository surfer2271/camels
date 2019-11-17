using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EthicsCap2.Models
{
    public class RegTargetedOutcomesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}