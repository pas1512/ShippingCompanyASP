using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingCompanyModels
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
            : base("MainDataBase")
        {
            base.Database.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=F:\DBS\SHIPPINGCOMPANY\MAINDATABASE.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public DbSet<Cabin> Cabins { get; set; }
        public DbSet<CabinVoyage> CabinVoyage{ get; set; }
        public DbSet<Voyage> Voyages { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<PortInfo> PortInfo { get; set; }
        public DbSet<Port> Ports { get; set; }

    }
}
