using Microsoft.Extensions.Logging;
using NServiceBus;
using System.Threading.Tasks;

namespace MinimalRepro {
  internal class MessageHandler : IHandleMessages<object> {
    private readonly ILogger<MessageHandler> logger;

    public MessageHandler(ILogger<MessageHandler> logger) {
      this.logger = logger;
    }
    public Task Handle(object message, IMessageHandlerContext context) {
      logger.LogInformation("Handled message of type {type}", message.GetType());
      return Task.CompletedTask;
    }
  }
}