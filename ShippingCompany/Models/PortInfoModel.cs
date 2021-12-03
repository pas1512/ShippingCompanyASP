using System;
namespace ShippingCompany.Models
{
    [Serializable]
    public class PortInfoModel
    {
        public int Id { get; set; }
        public PortModel Port { get; set; }
        public int PortId { get; set; }
        public DateTime TimeOfArrival { get; set; }
        public int ParkingTime { get; set; }
    }
}
