using OrderAPI.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Interfaces.Services
{
    public interface IPaymentMethodService
    {
        Task<int> SavePaymentMethod(PaymentMethodViewModel paymentMethods);
        Task<int> UpdatePaymentMethod(PaymentMethodViewModel paymentMethods);
        Task<int> DeletePaymentMethod(int paymentMethodId);
        Task<IEnumerable<PaymentMethodViewModel>> GetPaymentMethods(Guid customerId);
    }
}
