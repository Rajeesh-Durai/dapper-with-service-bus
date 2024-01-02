
namespace Student.Domain.Interface
{
    public interface IAzureServiceBusClient
    {
        Task SendAsync(string message);
    }
}
