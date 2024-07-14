using Microsoft.Extensions.Logging;
using OrderAPI.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Interfaces.Services
{
    public interface IRabitMQProducerConsumer
    {
        public void SendOrderMessage<T>(T message);
        public IEnumerable<OrderViewModel> ReadMessage(ILogger logger);
    }
}
