using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ShippingCompanyModels;

namespace ShippingCompany.Models
{
    public static class DataBaseModel
    {
        public static DataModel Data { get; set; }
        static DataBaseModel()
        {
            Data = new DataModel();
            Load();
        }

        static void Load()
        {
            using (MainDbContext db = new MainDbContext())
            {
                Data.Ports.Clear();
                var ports = db.Ports;
                foreach (var port in ports)
                {

                }


            }
        }
        public static void Save()
        {
            using (MainDbContext db = new MainDbContext())
            {
                db.Ports.RemoveRange(from c in db.Ports select c);
                foreach (var it in Data.Ports)
                {
                    db.Ports.Add(it.ParseTo());
                }
                db.SaveChanges();
            }
        }

        public static class Voyages
        {
            public static void Edit(VoyageModel model)
            {

            }
            public static void Remove(int id)
            {
                using (MainDbContext db = new MainDbContext())
                {
                    db.Voyages.Remove(db.Voyages.FirstOrDefault(o=>o.Id == id));
                    foreach (var item in db.PortInfo.Where(o => o.VoyageId == id))
                    {
                        db.PortInfo.Remove(item);
                    }
                    foreach (var item in db.CabinVoyage.Where(o => o.VoyageId == id))
                    {
                        db.CabinVoyage.Remove(item);
                    }
                }
            }
            public static void Add(VoyageModel model)
            {
                using (MainDbContext db = new MainDbContext())
                {
                    model.Id = db.Voyages.Count() > 0 ? db.Voyages.Last().Id + 1 : 0;
                    db.Voyages.Add(Convert(model));
                    foreach (var item in model.Ports)
                    {
                        PortInfo port = PortsInfo.Convert(item);
                        port.Id = db.Cabins.Count() > 0 ? db.Cabins.Last().Id + 1 : 0;
                        port.VoyageId = model.Id;
                        port.Voyage = Convert(model);
                        db.PortInfo.Add(port);
                    }
                    foreach (var item in model.ServingShip.Cabins)
                    {
                        CabinVoyage cabin = new CabinVoyage();
                        cabin.Id = db.CabinVoyage.Count() > 0 ? db.CabinVoyage.Last().Id + 1 : 0;
                        cabin.Occupied = false;
                        cabin.VoyageId = model.Id;
                        cabin.CabinId = item.Id;
                        cabin.Voyage = Convert(model);
                        cabin.Cabin = Cabins.Convert(item);
                        db.CabinVoyage.Add(cabin);
                    }
                }
            }
            public static VoyageModel Convert(Voyage dbData)
            {
                VoyageModel model = new VoyageModel();
                model.Id = dbData.Id;
                model.Name = dbData.Name;
                model.ServingShipId = dbData.ServingShip.Id;
                model.DateStart = dbData.DateStart;

                model.Ports = new List<PortInfoModel>();
                model.Sits = new Dictionary<CabinModel, bool>();
                using (MainDbContext db = new MainDbContext())
                {
                    var portList = db.PortInfo.Where(o => o.VoyageId == dbData.Id);
                    foreach (var item in portList)
                    {
                        model.Ports.Add(PortsInfo.Convert(item));
                    }
                    var cabins = db.CabinVoyage.Where(o => o.VoyageId == dbData.Id);
                    foreach (var item in cabins)
                    {
                        model.Sits.Add(Cabins.Convert(item.Cabin), item.Occupied);
                    }
                    model.ServingShip = Ships.Convert(db.Ships.FirstOrDefault(o=> o.Id == dbData.ServingShip.Id));
                }
                return model;
            }
            public static Voyage Convert(VoyageModel model)
            {
                Voyage dbData = new Voyage();
                dbData.Id = model.Id;
                dbData.Name = model.Name;
                dbData.DateStart = model.DateStart;
                dbData.ServingShip = Ships.Convert(model.ServingShip);
                return dbData;
            }
        }
        public static class PortsInfo
        {
            public static PortInfoModel Convert(PortInfo dbData)
            {
                PortInfoModel model = new PortInfoModel();
                model.Id = dbData.Id;
                model.PortId = dbData.PortId;
                model.TimeOfArrival = dbData.TimeOfArrival;
                model.ParkingTime = dbData.ParkingTime;

                model.Port = Ports.Convert(dbData.Port);

                return model;
            }
            public static PortInfo Convert(PortInfoModel model)
            {
                PortInfo dbData = new PortInfo();
                dbData.Id = model.Id;
                dbData.PortId = model.PortId;
                dbData.TimeOfArrival = model.TimeOfArrival;
                dbData.ParkingTime = model.ParkingTime;

                dbData.Port = Ports.Convert(model.Port);

                return dbData;
            }
        }
        public static class Ports
        {
            public static void Remove(int id)
            {
                using (MainDbContext db = new MainDbContext())
                {
                    db.Ports.Remove(db.Ports.FirstOrDefault(o => o.Id == id));
                }
            }
            public static void Add(PortModel model)
            {
                using (MainDbContext db = new MainDbContext())
                {
                    model.Id = db.Ports.Count() > 0 ? db.Ports.Last().Id + 1 : 0;
                    db.Ports.Add(Convert(model));
                }
            }
            public static PortModel Convert(Port dbData)
            {
                PortModel model = new PortModel();
                model.Id = dbData.Id;
                model.Name = dbData.Name;
                model.Country = dbData.Country;
                model.Latitude = dbData.Latitude;
                model.Longitude = dbData.Longitude;
                return model;
            }
            public static Port Convert(PortModel model)
            {
                Port dbData = new Port();
                dbData.Id = model.Id;
                dbData.Name = model.Name;
                dbData.Country = model.Country;
                dbData.Latitude = model.Latitude;
                dbData.Longitude = model.Longitude;
                return dbData;
            }
        }
        public static class Cabins
        {
            public static CabinModel Convert(Cabin dbData)
            {
                CabinModel model = new CabinModel();
                model.Id = dbData.Id;
                model.Number = dbData.Number;
                model.Price = dbData.Price;
                model.SeatsCount = dbData.SeatsCount;
                model.Type = dbData.Type;
                return model;
            }
            public static Cabin Convert(CabinModel model)
            {
                Cabin dbData = new Cabin();
                dbData.Id = model.Id;
                dbData.Number = model.Number;
                dbData.Price = model.Price;
                dbData.SeatsCount = model.SeatsCount;
                dbData.Type = model.Type;
                return dbData;
            }
        }
        public static class Ships
        {
            public static void Remove(int id)
            {
                using (MainDbContext db = new MainDbContext())
                {
                    db.Ships.Remove(db.Ships.FirstOrDefault(o => o.Id == id));
                    foreach (var item in db.Cabins.Where(o=>o.OwnerId == id))
                    {
                        db.Cabins.Remove(item);
                    }
                }
            }
            public static void Add(ShipModel model)
            {
                using (MainDbContext db = new MainDbContext())
                {
                    model.Id = db.Ships.Count() > 0 ? db.Ships.Last().Id + 1 : 0;
                    db.Ships.Add(Convert(model));
                    foreach (var item in model.Cabins)
                    {
                        Cabin cabin = Cabins.Convert(item);
                        cabin.Id = db.Cabins.Count() > 0 ? db.Cabins.Last().Id + 1 : 0;
                        cabin.OwnerId = model.Id;
                        cabin.Owner = Convert(model);
                        db.Cabins.Add(cabin);
                    }
                }
            }
            public static ShipModel Convert(Ship dbData)
            {
                ShipModel model = new ShipModel();
                model.Id = dbData.Id;
                model.Name = dbData.Name;
                model.ShipID = dbData.ShipID;
                model.Cabins = new List<CabinModel>();
                using (MainDbContext db = new MainDbContext())
                {
                    var cabins = db.Cabins.Where(o => o.OwnerId == dbData.Id);
                    foreach (var item in cabins)
                    {
                        model.Cabins.Add(Cabins.Convert(item));
                    }
                }
                return model;
            }
            public static Ship Convert(ShipModel model)
            {
                Ship dbData = new Ship();
                dbData.Id = model.Id;
                dbData.Name = model.Name;
                dbData.ShipID = model.ShipID;
                return dbData;
            }
        }
    }
}
