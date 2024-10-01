using Azure.Storage.Blobs;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;


namespace ST10393673_CLDV6212_POE.Functions
{


    public class BlobFunction
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobFunction(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        [Function("UploadToBlob")]
        public async Task Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequestData req,
            FunctionContext context)
        {
            var logger = context.GetLogger("UploadToBlob");

            string fileName = req.Headers["FileName"].ToString();
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient("mycontainer");

            await blobContainerClient.CreateIfNotExistsAsync();

            var blobClient = blobContainerClient.GetBlobClient(fileName);

            using (var stream = req.Body)
            {
                await blobClient.UploadAsync(stream);
            }

            logger.LogInformation($"Uploaded file: {fileName} to Blob Storage.");
        }
    }
}