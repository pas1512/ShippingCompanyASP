using ShippingCompanyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingCompany.Models
{
    public static class ModelsExtends
    {
        public static Port ParseTo(this PortModel port)
        {
            return new Port()
            {
                Id = port.Id,
                Name = port.Name,
                Country = port.Country,
                Latitude = port.Latitude,
                Longitude = port.Longitude
            };
        }
    }
}
