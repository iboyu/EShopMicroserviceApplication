using OrderAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Interfaces.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<int> SaveOrderDetail(OrderDetailsEntity orderDetails);
        Task<int> DeleteOrderDetail(int id, int OrderId);
        Task<OrderDetailsEntity> GetOrderDetailById(int orderdetailId);
        Task<IEnumerable<OrderDetailsEntity>> GetOrderDetailsByOrderId(int OrderId, int pageNumber, int pageSize);
        Task<int> UpdateOrderDetail(OrderDetailsEntity orderDetails);
        Task<IEnumerable<OrderDetailsEntity>> GetOrderDetailByOrderId(int orderId);
    }
}
