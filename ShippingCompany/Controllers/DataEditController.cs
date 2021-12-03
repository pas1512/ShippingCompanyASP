using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShippingCompany.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using System.Text.Json;
using System.Web;

namespace ShippingCompany.Controllers
{
    public class DataEditController : Controller
    {
        [HttpGet]
        public IActionResult CreateVoyage()
        {
            ViewBag.Ships = new SelectList(DummyDataBase.data.Ships, "Id", "Name");
            return View(new VoyageModel() {DateStart = DateTime.Now });
        }

        [HttpPost]
        public IActionResult CreateVoyage(VoyageModel voyage)
        {
            voyage.Id = DummyDataBase.data.Voyages.Count;
            voyage.ServingShip = DummyDataBase.data.Ships.Find(o => o.Id == voyage.ServingShipId);
            voyage.Name = $"STH-{voyage.ServingShip.ShipID}-{(voyage.Id + 1).ToString("D3")}-{(voyage.DateStart).Year}";
            DummyDataBase.data.Voyages.Add(voyage);
            return View("../Home/Index", DummyDataBase.data.Voyages);
        }

        public IActionResult GetCreatePortInfo(VoyageModel voyage)
        { 
            HttpContext.Session.SetString("Ports", JsonSerializer.Serialize(voyage.Ports));
            HttpContext.Session.SetInt32("ServingShip", voyage.ServingShipId);
            HttpContext.Session.SetString("DateStart", JsonSerializer.Serialize(voyage.DateStart));
            ViewBag.Ports = new SelectList(DummyDataBase.data.Ports, "Id", "Name");
            return View("CreatePortInfo", new PortInfoModel() {TimeOfArrival = DateTime.Now, ParkingTime = 30 });
        }

        public IActionResult CreatePortInfo(PortInfoModel portInfo)
        {
            portInfo.Port = DummyDataBase.data.Ports.Find(o => o.Id == portInfo.PortId);
            VoyageModel temp = new VoyageModel();
            temp.DateStart = (DateTime)JsonSerializer.Deserialize(HttpContext.Session.GetString("DateStart"), typeof(DateTime));
            temp.ServingShipId = (int)HttpContext.Session.GetInt32("ServingShip");
            temp.Ports = (List<PortInfoModel>)JsonSerializer.Deserialize(HttpContext.Session.GetString("Ports"), typeof(List<PortInfoModel>));
            temp.Ports.Add(portInfo);
            ViewBag.Ships = new SelectList(DummyDataBase.data.Ships, "Id", "Name", DummyDataBase.data.Ships.Find(o=>o.Id==temp.Id));
            return View("CreateVoyage", temp);
        }

        [HttpGet]
        public IActionResult CreatePort()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePort(PortModel port)
        {
            port.Id = DummyDataBase.data.Ports.Count;
            DummyDataBase.data.Ports.Add(port);
            return View("../Home/Ports", DummyDataBase.data.Ports);
        }
    }
}
