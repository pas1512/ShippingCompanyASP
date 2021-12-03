using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingCompanyModels
{
    class VoyageHistory
    {
        public int Id { get; set; }

        public Voyage Voyage { get; set; }
        public int VoyageId { get; set; }

        public double Losses { get; set; }
    }
}
