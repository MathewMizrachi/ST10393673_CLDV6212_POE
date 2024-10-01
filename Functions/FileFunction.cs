
using Azure.Storage.Files.Shares;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;



namespace ST10393673_CLDV6212_POE.Functions
{
    public class FileFunction
    {
        private readonly ShareServiceClient _shareServiceClient;

        public FileFunction(ShareServiceClient shareServiceClient)
        {
            _shareServiceClient = shareServiceClient;
        }

        [Function("UploadToFileShare")]
        public async Task Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequestData req,
            FunctionContext context)
        {
            var logger = context.GetLogger("UploadToFileShare");

            string fileName = req.Headers["FileName"].ToString();
            var shareClient = _shareServiceClient.GetShareClient("myfileshare");
            await shareClient.CreateIfNotExistsAsync();

            var directoryClient = shareClient.GetRootDirectoryClient();
            var fileClient = directoryClient.GetFileClient(fileName);

            using (var stream = req.Body)
            {
                await fileClient.CreateAsync(stream.Length);
                await fileClient.UploadAsync(stream);
            }

            logger.LogInformation($"Uploaded file: {fileName} to Azure File Storage.");
        }
    }
}