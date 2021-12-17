using Microsoft.AspNetCore.Mvc;
using ShippingCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingCompany.Controllers
{
    public class PortsController : Controller
    {
        [HttpGet]
        public IActionResult CreatePort()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePort(PortModel port)
        {
            port.Id = DataBaseModel.Data.Ports.Count;
            DataBaseModel.Data.Ports.Add(port);
            DataBaseModel.Save();
            return View("../Home/Ports", DataBaseModel.Data.Ports);
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            return PartialView(DataBaseModel.Data.Ports.Find(o => o.Id == id));
        }

        [HttpPost]
        public IActionResult Remove(PortModel delId)
        {
            var port = DataBaseModel.Data.Ports.Find(o => o.Id == delId.Id);
            DataBaseModel.Data.Ports.Remove(port);
            DataBaseModel.Save();
            return View("../Home/Ports", DataBaseModel.Data.Ports);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(DataBaseModel.Data.Ports.Find(o => o.Id == id));
        }

        [HttpPost]
        public IActionResult Edit(PortModel port)
        {
            var fined = DataBaseModel.Data.Ports.Find(o => o.Id == port.Id);
            int id = DataBaseModel.Data.Ports.IndexOf(fined);
            DataBaseModel.Data.Ports[id] = port;
            DataBaseModel.Save();
            return View("../Home/Ports", DataBaseModel.Data.Ports);
        }
    }
}
