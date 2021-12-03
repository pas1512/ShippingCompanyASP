using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingCompany.Models
{
    public static class DummyDataBase
    {
        public static DataModel data = new DataModel();
        static DummyDataBase()
        {
            data.DemoInitialization();
        }
    }
}
