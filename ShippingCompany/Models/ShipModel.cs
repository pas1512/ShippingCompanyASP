using System;
using System.Linq;
using System.Collections.Generic;

namespace ShippingCompany.Models
{
    [Serializable]
    public class ShipModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShipID { get; set; }
        public List<CabinModel> Cabins { get; set; }
        public int TotalSits 
        { 
            get 
            {
                return Cabins.Sum(o => o.SeatsCount);
            } 
        }

    }
}
