using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingCompanyModels
{
    public class Cabin
    {
        public int Id { get; set; }

        public Ship Owner { get; set; }
        public int OwnerId { get; set; }

        public string Number { get; set; }
        public string Type { get; set; }
        public int SeatsCount { get; set; }
        public double Price { get; set; }
    }
}
