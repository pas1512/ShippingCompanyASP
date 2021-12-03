using System;
namespace ShippingCompanyModels
{
    public class PortInfo
    {
        public int Id { get; set; }
        public DateTime TimeOfArrival { get; set; }
        public int ParkingTime { get; set; }

        public Port Port { get; set; }
        public int PortId { get; set; }

        public Voyage Voyage { get; set; }
        public int VoyageId { get; set; }
    }
}
