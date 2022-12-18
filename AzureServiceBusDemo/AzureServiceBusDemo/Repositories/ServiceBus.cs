using System.Text.Json;
using System.Text;
using AzureServiceBusDemo.Models;
using Microsoft.Azure.ServiceBus;

namespace AzureServiceBusDemo.Repositories
{
    public class ServiceBus : IServiceBus
    {
        private readonly IConfiguration _configuration;

        public ServiceBus(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMessageAsync(CarDetails carDetails)
        {
            IQueueClient client = new QueueClient(_configuration["AzureServiceBusConnectionString"], _configuration["QueueName"]);

            //Serialize car details object
            var messageBody = JsonSerializer.Serialize(carDetails);

            //Set content type and Guid
            var message = new Message(Encoding.UTF8.GetBytes(messageBody))
            {
                MessageId = Guid.NewGuid().ToString(),
                ContentType = "application/json"
            };

            await client.SendAsync(message);
        }
    }
}
