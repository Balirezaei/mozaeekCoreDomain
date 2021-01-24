using MassTransit;
using MozaeekCore.Core.MessageBus;
using System.Threading.Tasks;

namespace MozaeekCore.Messaging.RabbitMQ
{
    public class MassTransitMqPublisher : IMessagePublisher
    {
        private readonly IPublishEndpoint publishEndpoint;

        public MassTransitMqPublisher(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
        }
        public Task PublishAsync(object @event)
        {
            return publishEndpoint.Publish(@event);
        }
    }
}
