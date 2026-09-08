using Azure.Storage.Files.Shares;
using Azure.Identity;
using Azure.Storage.Files.Shares.Models;

namespace StudentTaskManagementSystem.Services
{
    public class AzureFileStorageService
    {
        private readonly ShareDirectoryClient _client;
        private readonly ILogger<AzureFileStorageService> _logger;
        public AzureFileStorageService(IConfiguration config, ILogger<AzureFileStorageService> logger)
        {
            _logger = logger;
            string accountName = config["AzureStorage:AccountName"]!;
            string shareName = config["AzureFileStorage:ShareName"]!;
            string directoryName = config["AzureFileStorage:DirectoryName"]!;
            string fileServiceUri = $"https://{accountName}.file.core.windows.net";
            ShareClientOptions options = new ShareClientOptions
            {
                AllowTrailingDot = true,
                AllowSourceTrailingDot = true,
                ShareTokenIntent = ShareTokenIntent.Backup
            };
            ShareServiceClient serviceClient = new ShareServiceClient(new Uri(fileServiceUri), new DefaultAzureCredential(), options);
            ShareClient client = serviceClient.GetShareClient(shareName);
            _client = client.GetDirectoryClient(directoryName);
        }
        public async Task<string> UploadAsync(IFormFile file)
        {
            try
            {
                string fileName =
                    Guid.NewGuid().ToString() +
                    Path.GetExtension(file.FileName);
                ShareFileClient fileClient =
                    _client.GetFileClient(fileName);
                using Stream stream = file.OpenReadStream();
                await fileClient.CreateAsync(stream.Length);
                await fileClient.UploadRangeAsync(
                    new Azure.HttpRange(0, stream.Length),
                    stream);
                return fileName;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Azure Files upload failed.");
                throw;
            }
        }
    }
}
