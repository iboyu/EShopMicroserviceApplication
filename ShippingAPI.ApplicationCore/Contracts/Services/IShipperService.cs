using ShippingAPI.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingAPI.ApplicationCore.Contracts.Services
{
    public interface IShipperService
    {
        Task<int> AddShipperAsync(ShipperRequestModel model);
        Task<int> UpdateShipperAsync(ShipperRequestModel model);
        Task<int> DeleteShipperAsync(int id);
        Task<IEnumerable<ShipperResponseModel>> GetAllShippers();
        Task<ShipperResponseModel> GetShipperByIdAsync(int id);
        Task<IEnumerable<ShipperResponseModel>> GetShipperByRegion(string region);
    }
}
