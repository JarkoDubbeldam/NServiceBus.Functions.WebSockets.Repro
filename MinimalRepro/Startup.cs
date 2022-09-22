using System;
using System.IO;
using System.Reflection;
using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NServiceBus;

[assembly: FunctionsStartup(typeof(Startup))]
[assembly: NServiceBusTriggerFunction(Startup.EndpointName)]
internal class Startup : FunctionsStartup {
  public const string EndpointName = "MyEndpoint";
  public override void Configure(IFunctionsHostBuilder builder) {
    builder.UseNServiceBus(c => {
      var endpointConfiguration = new ServiceBusTriggeredEndpointConfiguration(EndpointName, c);
      endpointConfiguration.Transport.UseWebSockets();
      return endpointConfiguration;
    });
  }
}
