using Newtonsoft.Json;
using Student.Domain.Interface;
using Student.Domain.Models;
using System.Text;

namespace Student.Domain.Service
{
    public class MessageQueueService:IMessageQueueService
    {
        #region Constructor
        private readonly IAzureServiceBusClient _serviceBusClient;
        public MessageQueueService(IAzureServiceBusClient serviceBusClient)
        {
            _serviceBusClient = serviceBusClient;
        }
        #endregion
        #region Sending the string type message to client
        public async Task SendMessageAsync(string message)
        {
            string serializedMessage = JsonConvert.SerializeObject(message);
            await _serviceBusClient.SendAsync(serializedMessage);
        }
        #endregion
        #region Sending the List type message to client
        public async Task SendAllMessageAsync(List<Students> message)
        {
            string serializedMessage =JsonConvert.SerializeObject(message);
            await _serviceBusClient.SendAsync(serializedMessage);
        }
        #endregion
    }
}
