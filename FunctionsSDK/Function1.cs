using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FunctionsSDK {
  public class MyFunction {
    [FunctionName("MyFunction")]
    public void Run([ServiceBusTrigger(Startup.EndpointName, Connection = "AzureWebJobsServiceBus")] string myQueueItem, ILogger log) {
      log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
    }
  }
}
