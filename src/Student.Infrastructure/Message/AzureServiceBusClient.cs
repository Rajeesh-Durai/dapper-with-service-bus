using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Student.Domain.Interface;
using System.Text;

namespace Student.Infrastructure.Message
{
    public class AzureServiceBusClient: IAzureServiceBusClient
    {
        private readonly ServiceBusSender _serviceBusSender;
        private readonly IConfiguration _configuration;

        public AzureServiceBusClient(IConfiguration configuration)
        {
            _configuration = configuration;

            var connectionString = _configuration["ServiceBus:ServiceBusConnectionString"];
            var queueName = _configuration["ServiceBus:ServiceBusQueueName"];
            var client = new ServiceBusClient(connectionString);
            _serviceBusSender = client.CreateSender(queueName);
        }

        public async Task SendAsync( string message)
        {
            var serviceBusMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(message));
            await _serviceBusSender.SendMessageAsync(serviceBusMessage);
        }
    }
}
