using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using NServiceBus;

[assembly: FunctionsStartup(typeof(Startup))]
//[assembly: NServiceBusTriggerFunction(Startup.EndpointName, SendsAtomicWithReceive = true)]
internal class Startup : FunctionsStartup {
  public const string EndpointName = "Confirmationemail";
  public override void Configure(IFunctionsHostBuilder builder) {
    builder.UseNServiceBus(c => {
      var endpointConfiguration = new ServiceBusTriggeredEndpointConfiguration(EndpointName, c);
      endpointConfiguration.Transport.UseWebSockets();
      return endpointConfiguration;
    });
  }
}
