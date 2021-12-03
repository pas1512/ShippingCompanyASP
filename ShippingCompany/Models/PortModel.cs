using System;
namespace ShippingCompany.Models
{
    [Serializable]
    public class PortModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
