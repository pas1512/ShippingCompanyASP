using Microsoft.AspNetCore.Mvc;
using ShippingCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingCompany.Controllers
{
    public class ShipsController : Controller
    {
        [HttpGet]
        public IActionResult CreateShip()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateShip(ShipModel ship)
        {
            ship.Id = DataBaseModel.Data.Ships.Count;
            foreach(var it in ship.Cabins)
            {
                it.Id = DataBaseModel.Data.Cabins.Count;
                if (it.SeatsCount < 1)
                    it.SeatsCount = 1;
                DataBaseModel.Data.Cabins.Add(it);
            }
            DataBaseModel.Data.Ships.Add(ship);
            return View("../Home/Ships", DataBaseModel.Data.Ships);
        }

        public IActionResult CreateCabin(int id)
        {
            return PartialView(new CabinModel() { Number = id.ToString(), Type = "none", SeatsCount = 1});
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            return PartialView("Remove", DataBaseModel.Data.Ships.Find(o => o.Id == id));
        }

        [HttpPost]
        public IActionResult Remove(ShipModel delId)
        {
            var ship = DataBaseModel.Data.Ships.Find(o => o.Id == delId.Id);
            DataBaseModel.Data.Ships.Remove(ship);
            foreach (var it in ship.Cabins)
            {
                DataBaseModel.Data.Cabins.Remove(it);
            }
            return View("../Home/Ships", DataBaseModel.Data.Ships);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(DataBaseModel.Data.Ships.Find(o => o.Id == id));
        }

        [HttpPost]
        public IActionResult Edit(PortModel port)
        {
            var fined = DataBaseModel.Data.Ports.Find(o => o.Id == port.Id);
            int id = DataBaseModel.Data.Ports.IndexOf(fined);
            DataBaseModel.Data.Ports[id] = port;
            return View("../Home/Ports", DataBaseModel.Data.Ports);
        }
    }
}
