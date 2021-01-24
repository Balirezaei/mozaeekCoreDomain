using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MozaeekCore.Core.MessageBus
{
    public interface IMessagePublisher
    {
        Task PublishAsync(object @event);
    }
}
