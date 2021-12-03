using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingCompany.Models
{
    [Serializable]
    public class CabinModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public int SeatsCount { get; set; }
        public double Price { get; set; }
    }
}
