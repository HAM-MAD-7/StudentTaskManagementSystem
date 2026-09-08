using Azure.Storage.Queues;
using Azure.Identity;

using System.Linq.Expressions;
using Microsoft.VisualBasic;

namespace StudentTaskManagementSystem.Services
{
    public class QueueStorageService
    {
        private readonly QueueClient _queueClient;
        public QueueStorageService(IConfiguration config)
        {
            string accountName = config["AzureStorage:AccountName"]!;
            string queueName = config["AzureQueue:QueueName"]!;
            string queueServiceUri = $"https://{accountName}.queue.core.windows.net";
            _queueClient = new QueueClient(new Uri($"{queueServiceUri}/{queueName}"), new DefaultAzureCredential());
        }
        public async Task SendMessageAsync(string message)
        {
            await _queueClient.CreateIfNotExistsAsync();
            await _queueClient.SendMessageAsync(message);
        }
    }
}
