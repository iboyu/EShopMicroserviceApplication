using Microsoft.EntityFrameworkCore;
using ShippingAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingAPI.Infrastructure.Data
{
    public class ShippingDbContext :DbContext
    {
        public ShippingDbContext(DbContextOptions<ShippingDbContext> option) : base(option)
        {
            
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<ShipperRegion> ShipperRegions { get; set; }
    }
}
