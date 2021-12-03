using System;
using System.Collections.Generic;
using System.Text.Json;

namespace ShippingCompany.Models
{
    [Serializable]
    public class VoyageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public ShipModel ServingShip { get; set; }
        public int ServingShipId { get; set; }

        private Dictionary<CabinModel, bool> sits;
        public Dictionary<CabinModel, bool> Sits
        {
            get { return sits; }
            set { sits = value; }
        }

        public List<PortInfoModel> Ports { get; set; }

        public VoyageModel()
        {
            Sits = new Dictionary<CabinModel, bool>();
            Ports = new List<PortInfoModel>();
        }
        public VoyageModel(VoyageModel other)
        {
            this.Id = other.Id;
            this.Name = other.Name;
            this.DateStart = other.DateStart;
            this.ServingShip = other.ServingShip;
            this.ServingShipId = other.ServingShipId;
            this.Sits = other.Sits;
            this.Ports = other.Ports;
        }
        public string PortsInfo {
            get
            {
                string ports = "";
                if (Ports == null) return "null";
                foreach (var item in Ports)
                {
                    ports += $"\"{item.Port.Name}\"|";
                }
                return ports == ""? "":ports.Remove(ports.Length - 1); 
            }
        }
        public string PortsJson
        {
            get
            {
                return JsonSerializer.Serialize(Ports);
            }
            set
            {
                Ports = value == null? new List<PortInfoModel>(): (List<PortInfoModel>)JsonSerializer.Deserialize(value, typeof(List<PortInfoModel>));
            }
        }
    }
}
