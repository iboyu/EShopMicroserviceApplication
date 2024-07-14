using OrderAPI.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Interfaces.Services
{
    public interface IDocumentService
    {
        public Task GenerateInvoiceDocxAsync(List<OrderViewModel> orders);
    }
}
