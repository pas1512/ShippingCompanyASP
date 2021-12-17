using System;
namespace ShippingCompany.Models
{
    [Serializable]
    public class PortInfoModel
    {
        public int Id { get; set; }
        public PortModel Port { get; set; }
        public int PortId { get; set; }

        private DateTime timearr;
        public DateTime TimeOfArrival
        {
            get { return timearr; }
            set 
            {
                DateTime dateTime = value.AddSeconds(-value.Second);
                dateTime = value.AddMilliseconds(-dateTime.Millisecond);
                timearr = dateTime; 
            }
        }

        public int ParkingTime { get; set; }

        public PortInfoModel()
        {
            Id = -1;
        }
    }
}
