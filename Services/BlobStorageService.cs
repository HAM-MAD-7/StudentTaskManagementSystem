using Azure.Storage.Blobs;
using Azure.Identity;

namespace StudentTaskManagementSystem.Services
{
    public class BlobStorageService
    {
        private readonly BlobContainerClient _containerClient;
        public BlobStorageService(IConfiguration config)
        {
            string accountName = config["AzureStorage:AccountName"];
            string containerName = config["AzureStorage:ContainerName"];
            string blobServiceUri = $"https://{accountName}.blob.core.windows.net";
            BlobServiceClient serviceClient = new BlobServiceClient(new Uri(blobServiceUri), new DefaultAzureCredential());
            _containerClient = serviceClient.GetBlobContainerClient(containerName);
        }
        public async Task<(string BlobName, string BlobUrl)> UploadAsync(IFormFile file)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            BlobClient client = _containerClient.GetBlobClient(fileName);
            using Stream stream = file.OpenReadStream();
            await client.UploadAsync(stream, overwrite:true);
            return (fileName, client.Uri.ToString());
        }
        public async Task<(Stream stream, string ContentType, string FileName)> DownloadAsync(string fileName)
        {
            BlobClient client = _containerClient.GetBlobClient(fileName);
            Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadResult> response = await client.DownloadContentAsync();
            string contentType = response.Value.Details.ContentType;
            return(response.Value.Content.ToStream(), contentType, fileName);
        }
    }
}
