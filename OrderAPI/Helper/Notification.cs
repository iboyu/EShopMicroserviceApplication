﻿using RabbitMQ.Client;
using System.Text;
namespace OrderAPI.Helper
{
    public class Notification
    {
        ConnectionFactory connectionFactory;
        public Notification()
        {
            connectionFactory = new ConnectionFactory();
        }
        public void AddMessageToQueue(string message)
        {
            connectionFactory.Uri = new Uri("amqp://guest:guest@localhost:5672");
            connectionFactory.ClientProvidedName = "Order Service";

            using (var connection = connectionFactory.CreateConnection())
            {
                var channel = connection.CreateModel();
                string exchange = "order-api-exchange";
                string routingKey = "order-api-routing-key";
                string queueName = "order-api-queue";
                channel.ExchangeDeclare(exchange, ExchangeType.Direct);
                channel.QueueDeclare(queueName);
                channel.QueueBind(queueName, exchange, routingKey, null);
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange, routingKey, null, messageBytes);
                channel.Close();
                connection.Close();
            }

           



        }
    }
}
