using Azure.Messaging.ServiceBus;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NServicebusFunction {
  class CustomTriggerDefinition {
    IFunctionEndpoint functionEndpoint;

    public CustomTriggerDefinition(IFunctionEndpoint functionEndpoint) {
      this.functionEndpoint = functionEndpoint;
    }

    [FunctionName("MyCustomTrigger")]
    public async Task Run(
        [ServiceBusTrigger(Startup.EndpointName)]
        Message message,
        ILogger logger,
        MessageReceiver messageReceiver,
        ExecutionContext executionContext) {
      await functionEndpoint.Process(message, executionContext, messageReceiver, logger);
    }
  }
}
