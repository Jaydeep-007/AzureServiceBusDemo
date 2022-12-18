using AzureServiceBusDemo.Models;
using System;

namespace AzureServiceBusDemo.Repositories
{
    public interface IServiceBus
    {
        Task SendMessageAsync(CarDetails carDetails);
    }
}
