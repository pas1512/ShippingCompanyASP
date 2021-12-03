using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingCompany.Models
{
    public class DataModel
    {
        public List<VoyageModel> Voyages { get; set; }
        public List<ShipModel> Ships { get; set; }
        public List<PortModel> Ports { get; set; }
        public List<PortInfoModel> PortInfo { get; set; }
        public List<CabinModel> Cabins { get; set; }
        public DataModel()
        {
            Voyages = new List<VoyageModel>();
            Ships = new List<ShipModel>();
            Ports = new List<PortModel>();
            PortInfo = new List<PortInfoModel>();
            Cabins = new List<CabinModel>();
        }
        public void DemoInitialization()
        {
            Ports.Add(
                new PortModel()
                {
                    Id = Ports.Count,
                    Country = "Китай",
                    Name = "Шанхай"
                }
            );
            Ports.Add(
                new PortModel()
                {
                    Id = Ports.Count,
                    Country = "Сингапур",
                    Name = "Сингапур"
                }
            );
            Ports.Add(
                new PortModel()
                {
                    Id = Ports.Count,
                    Country = "Голландия",
                    Name = "Роттердам"
                }
            );
            Ports.Add(
                new PortModel()
                {
                    Id = Ports.Count,
                    Country = "США",
                    Name = "Лос-Анджелес"
                }
            );

            Ships.Add(
                new ShipModel()
                {
                    Id = Ships.Count,
                    Name = "Avrora",
                    ShipID = "AVR",
                    Cabins = new List<CabinModel>()
                    {
                        new CabinModel()
                        {
                            Id = 0,
                            Number = "0",
                            Price = 100,
                            SeatsCount = 4,
                            Type = "none"
                        },
                        new CabinModel()
                        {
                            Id = 1,
                            Number = "1",
                            Price = 100,
                            SeatsCount = 4,
                            Type = "none"
                        },
                        new CabinModel()
                        {
                            Id = 2,
                            Number = "2",
                            Price = 100,
                            SeatsCount = 2,
                            Type = "none"
                        },
                        new CabinModel()
                        {
                            Id = 3,
                            Number = "3",
                            Price = 100,
                            SeatsCount = 2,
                            Type = "none"
                        }
                    }
                }
            );
            Ships.Add(
                new ShipModel()
                {
                    Id = Ships.Count,
                    Name = "Astor",
                    ShipID = "AST",
                    Cabins = new List<CabinModel>()
                    {
                        new CabinModel()
                        {
                            Id = 4,
                            Number = "0",
                            Price = 800,
                            SeatsCount = 6,
                            Type = "none"
                        },
                        new CabinModel()
                        {
                            Id = 5,
                            Number = "1",
                            Price = 800,
                            SeatsCount = 6,
                            Type = "none"
                        },
                        new CabinModel()
                        {
                            Id = 6,
                            Number = "2",
                            Price = 800,
                            SeatsCount = 6,
                            Type = "none"
                        },
                        new CabinModel()
                        {
                            Id = 7,
                            Number = "3",
                            Price = 800,
                            SeatsCount = 6,
                            Type = "none"
                        },
                        new CabinModel()
                        {
                            Id = 8,
                            Number = "4",
                            Price = 600,
                            SeatsCount = 4,
                            Type = "none"
                        },
                        new CabinModel()
                        {
                            Id = 9,
                            Number = "5",
                            Price = 600,
                            SeatsCount = 4,
                            Type = "none"
                        },
                        new CabinModel()
                        {
                            Id = 10,
                            Number = "6",
                            Price = 600,
                            SeatsCount = 4,
                            Type = "none"
                        },
                        new CabinModel()
                        {
                            Id = 11,
                            Number = "7",
                            Price = 600,
                            SeatsCount = 4,
                            Type = "none"
                        },
                        new CabinModel()
                        {
                            Id = 12,
                            Number = "7",
                            Price = 600,
                            SeatsCount = 4,
                            Type = "none"
                        },
                        new CabinModel()
                        {
                            Id = 13,
                            Number = "7",
                            Price = 600,
                            SeatsCount = 4,
                            Type = "none"
                        }
                    }
                }
            );
            
            Voyages.Add(
                new VoyageModel()
                {
                    Id = Voyages.Count,
                    Name = $"STH-{Ships[0].ShipID}-{(Voyages.Count + 1).ToString("D3")}-{(DateTime.Now).Year}",
                    DateStart = DateTime.Now,
                    ServingShip = Ships[0],
                    Ports = new List<PortInfoModel>()
                    {
                        new PortInfoModel()
                        {
                            Id = 0,
                            Port = Ports[0],
                            ParkingTime = 2,
                            TimeOfArrival = DateTime.Now
                        },
                        new PortInfoModel()
                        {
                            Id = 1,
                            Port = Ports[2],
                            ParkingTime = 2,
                            TimeOfArrival = DateTime.Now
                        }
                    }
                }
            );
            Voyages.Add(
                new VoyageModel()
                {
                    Id = Voyages.Count,
                    Name = $"STH-{Ships[1].ShipID}-{(Voyages.Count + 1).ToString("D3")}-{(DateTime.Now).Year}",
                    DateStart = (DateTime.Now).AddDays(2),
                    ServingShip = Ships[1],
                    Ports = new List<PortInfoModel>()
                    {
                        new PortInfoModel()
                        {
                            Id = 2,
                            Port = Ports[0],
                            ParkingTime = 5,
                            TimeOfArrival = DateTime.Now
                        },
                        new PortInfoModel()
                        {
                            Id = 3,
                            Port = Ports[1],
                            ParkingTime = 1,
                            TimeOfArrival = DateTime.Now
                        },
                        new PortInfoModel()
                        {
                            Id = 4,
                            Port = Ports[2],
                            ParkingTime = 2,
                            TimeOfArrival = DateTime.Now
                        }
                    }
                }
            );
            Voyages.Add(
                new VoyageModel()
                {
                    Id = Voyages.Count,
                    Name = $"STH-{Ships[1].ShipID}-{(Voyages.Count + 1).ToString("D3")}-{(DateTime.Now).Year}",
                    DateStart = (DateTime.Now).AddDays(8),
                    ServingShip = Ships[1],
                    Ports = new List<PortInfoModel>()
                    {
                        new PortInfoModel()
                        {
                            Id = 5,
                            Port = Ports[2],
                            ParkingTime = 2,
                            TimeOfArrival = DateTime.Now
                        },
                        new PortInfoModel()
                        {
                            Id = 6,
                            Port = Ports[1],
                            ParkingTime = 2,
                            TimeOfArrival = DateTime.Now
                        },
                        new PortInfoModel()
                        {
                            Id = 7,
                            Port = Ports[3],
                            ParkingTime = 2,
                            TimeOfArrival = DateTime.Now
                        }
                    }
                }
            );
            Voyages.Add(
                new VoyageModel()
                {
                    Id = Voyages.Count,
                    Name = $"STH-{Ships[0].ShipID}-{(Voyages.Count + 1).ToString("D3")}-{(DateTime.Now).Year}",
                    DateStart = (DateTime.Now).AddDays(10),
                    ServingShip = Ships[0],
                    Ports = new List<PortInfoModel>()
                    {
                        new PortInfoModel()
                        {
                            Id = 8,
                            Port = Ports[2],
                            ParkingTime = 2,
                            TimeOfArrival = DateTime.Now
                        },
                        new PortInfoModel()
                        {
                            Id = 9,
                            Port = Ports[3],
                            ParkingTime = 2,
                            TimeOfArrival = DateTime.Now
                        },
                        new PortInfoModel()
                        {
                            Id = 10,
                            Port = Ports[0],
                            ParkingTime = 2,
                            TimeOfArrival = DateTime.Now
                        }
                    }
                }
            );

            Cabins.AddRange(Ships[0].Cabins);
            Cabins.AddRange(Ships[1].Cabins);
            PortInfo.AddRange(Voyages[0].Ports);
            PortInfo.AddRange(Voyages[1].Ports);
            PortInfo.AddRange(Voyages[2].Ports);
            PortInfo.AddRange(Voyages[3].Ports);
        }
    }
}
