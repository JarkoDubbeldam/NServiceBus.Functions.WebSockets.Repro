using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
internal class Startup : FunctionsStartup {
  public const string EndpointName = "Confirmationemail";
  public override void Configure(IFunctionsHostBuilder builder) {

  }
}
