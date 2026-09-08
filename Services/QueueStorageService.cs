using Azure.Storage.Queues;
using Azure.Identity;

using System.Linq.Expressions;
using Microsoft.VisualBasic;
using Azure.Storage.Queues.Models;

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
        public async Task<QueueMessage?> ReceiveMessageAsync()
        {
            await _queueClient.CreateIfNotExistsAsync();
            Azure.Response<QueueMessage[]> response = await _queueClient.ReceiveMessagesAsync(maxMessages:1);
            if(response.Value.Length == 0)
            {
                return null;
            }
            return response.Value[0];
        }
        public async Task DeleteMessageAsync(string messageId, string popReceipt)
        {
            await _queueClient.DeleteMessageAsync(messageId, popReceipt);
        }
    }
}
