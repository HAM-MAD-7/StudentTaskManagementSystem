using Azure.Data.Tables;
using Azure.Identity;

namespace StudentTaskManagementSystem.Services
{
    public class AzureTableStorageService
    {
        private readonly TableClient _tableClient;
        public AzureTableStorageService(IConfiguration config)
        {
            string accountName = config["AzureStorage:AccountName"]!;
            string tableName = "StudentLogs";
            string tableServiceUri = $"https://{accountName}.table.core.windows.net";
            TableServiceClient serviceClient = new TableServiceClient(new Uri(tableServiceUri), new DefaultAzureCredential());
            _tableClient = serviceClient.GetTableClient(tableName);
        }
        public async Task AddLogAsync(string studentId, string action)
        {
            TableEntity entity = new TableEntity
            {
                PartitionKey = "Students",
                RowKey = Guid.NewGuid().ToString(),
                ["StudentId"] = studentId,
                ["Action"] = action,
                ["Timestamp"] = DateTime.UtcNow
            };
            await _tableClient.AddEntityAsync(entity);
        }
    }
}
