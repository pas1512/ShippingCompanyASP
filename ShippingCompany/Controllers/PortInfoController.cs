using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingCompany.Controllers
{
    public class PortInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
