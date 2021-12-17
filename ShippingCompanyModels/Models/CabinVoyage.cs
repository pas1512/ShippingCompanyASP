using System;
namespace ShippingCompanyModels
{
    public class CabinVoyage
    {
        public int Id { get; set; }

        public Voyage Voyage { get; set; }
        public int VoyageId { get; set; }

        public Cabin Cabin { get; set; }
        public int CabinId { get; set; }

        public bool Occupied { get; set; }
    }
}
