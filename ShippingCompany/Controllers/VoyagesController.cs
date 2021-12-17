using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShippingCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShippingCompany.Controllers
{
    public class VoyagesController : Controller
    {
        public JsonResult GetFindedPorts(string q)
        {
            var ports = q == null? DataBaseModel.Data.Ports: DataBaseModel.Data.Ports.Where(o => o.Name.Contains(q)).ToList();
            return Json(ports);
        }
        public IActionResult GetPortItemTemlate()
        {
            return PartialView("PortInfoItem");
        }
        public IActionResult GetRemovePortItemTemlate()
        {
            return PartialView("PortInfoRemove");
        }
        public IActionResult GetPortInfoForm(int id)
        {
            //HttpContext.Session.SetString("Ports", JsonSerializer.Serialize(voyage.Ports));
            return PartialView("PortInfoForm", new PortInfoModel() { TimeOfArrival = DateTime.Now, ParkingTime = 30 });
        }
        public IActionResult GetEditPortItemTemlate(int id)
        {
            return PartialView("PortInfoForm");
        }

        [HttpGet]
        public IActionResult CreateVoyage()
        {
            ViewBag.Ships = new SelectList(DataBaseModel.Data.Ships, "Id", "Name");
            ViewBag.Action = nameof(CreateVoyage);
            return View("VoyageForm" ,new VoyageModel() { DateStart = DateTime.Now});
        }

        [HttpPost]
        public IActionResult CreateVoyage(VoyageModel voyage)
        {
            voyage.Id = DataBaseModel.Data.Voyages.Count;
            voyage.ServingShip = DataBaseModel.Data.Ships.Find(o => o.Id == voyage.ServingShipId);
            voyage.Name = $"STH-{voyage.ServingShip.ShipID}-{(voyage.Id + 1).ToString("D3")}-{(voyage.DateStart).Year}";
            foreach(var it in voyage.Ports)
            {
                it.Port = DataBaseModel.Data.Ports.Find(o => o.Id == it.PortId);
                it.Id = DataBaseModel.Data.PortInfo.Count();
                DataBaseModel.Data.PortInfo.Add(it);
            }
            DataBaseModel.Data.Voyages.Add(voyage);
            return View("../Home/Index", DataBaseModel.Data.Voyages);
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            return PartialView("VoyageRemove", DataBaseModel.Data.Voyages.Find(o => o.Id == id));
        }

        [HttpPost]
        public IActionResult Remove(VoyageModel delId)
        {
            var voyage = DataBaseModel.Data.Voyages.Find(o => o.Id == delId.Id);
            DataBaseModel.Data.Voyages.Remove(voyage);
            foreach(var it in voyage.Ports)
            {
                DataBaseModel.Data.PortInfo.Remove(it);
            }
            return View("../Home/Index", DataBaseModel.Data.Voyages);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            int shipId = DataBaseModel.Data.Voyages.Find(o => o.Id == id).ServingShip.Id;
            ViewBag.Action = nameof(Edit);
            ViewBag.Ships = new SelectList(DataBaseModel.Data.Ships, "Id", "Name", DataBaseModel.Data.Ships.Find(o => o.Id == shipId));
            return View("VoyageForm", DataBaseModel.Data.Voyages.Find(o => o.Id == id));
        }

        [HttpPost]
        public IActionResult Edit(VoyageModel voyage)
        {
            voyage.ServingShip = DataBaseModel.Data.Ships.Find(o => o.Id == voyage.ServingShipId);
            foreach (var it in voyage.Ports)
            {
                it.Port = DataBaseModel.Data.Ports.Find(o => o.Id == it.PortId);
                if (it.Id == -1)
                {
                    it.Id = DataBaseModel.Data.PortInfo.Count();
                    DataBaseModel.Data.PortInfo.Add(it);
                }
            }
            var selected = DataBaseModel.Data.Voyages.Find(o => o.Id == voyage.Id);
            voyage.Name = selected.Name;

            int index = DataBaseModel.Data.Voyages.IndexOf(selected);
            DataBaseModel.Data.Voyages[index] = voyage;
            return View("../Home/Index", DataBaseModel.Data.Voyages);
        }


        //public IActionResult CreatePortInfo(PortInfoModel portInfo)
        //{
        //    portInfo.Port = DummyDataBase.data.Ports.Find(o => o.Id == portInfo.PortId);
        //    VoyageModel temp = new VoyageModel();
        //    temp.DateStart = (DateTime)JsonSerializer.Deserialize(HttpContext.Session.GetString("DateStart"), typeof(DateTime));
        //    temp.ServingShipId = (int)HttpContext.Session.GetInt32("ServingShip");
        //    temp.Ports = (List<PortInfoModel>)JsonSerializer.Deserialize(HttpContext.Session.GetString("Ports"), typeof(List<PortInfoModel>));
        //    temp.Ports.Add(portInfo);
        //    ViewBag.Ships = new SelectList(DummyDataBase.data.Ships, "Id", "Name", DummyDataBase.data.Ships.Find(o => o.Id == temp.Id));
        //    return View("CreateVoyage", temp);
        //}
    }
}
