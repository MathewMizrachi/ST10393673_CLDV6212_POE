using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace ST10393673_CLDV6212_POE.Services
{
    public class BlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobService(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("AzureStorage");
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        // Original method to upload blob
        public async Task<string> UploadBlobAsync(IFormFile file, string containerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync();

            var blobClient = containerClient.GetBlobClient(file.FileName);
            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, true);
            }

            return blobClient.Uri.ToString();
        }

        // New method to upload blob with three parameters
        public async Task<string> UploadBlobAsync(string containerName, string blobName, Stream stream)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync();

            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.UploadAsync(stream, true);

            return blobClient.Uri.ToString();
        }
    }
}
