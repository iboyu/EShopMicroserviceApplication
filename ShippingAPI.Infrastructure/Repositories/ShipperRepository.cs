using ShippingAPI.ApplicationCore.Contracts.Repositories;
using ShippingAPI.ApplicationCore.Entities;
using ShippingAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingAPI.Infrastructure.Repositories
{
    public class ShipperRepository : BaseRepository<Shipper>, IShipperRepository
    {
        public ShipperRepository(ShippingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
