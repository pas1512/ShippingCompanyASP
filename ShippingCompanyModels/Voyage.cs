using System;
namespace ShippingCompanyModels
{
    public class Voyage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Ship ServingShip { get; set; }
        public DateTime DateStart { get; set; }
    }
}
