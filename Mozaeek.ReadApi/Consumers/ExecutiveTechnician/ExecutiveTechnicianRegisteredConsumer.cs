using MassTransit;
using MozaeekCore.Domain.Contract.IntegrationEvents;
using System;
using System.Threading.Tasks;

namespace Mozaeek.ReadApi.Consumers.ExecutiveTechnician
{
    public class ExecutiveTechnicianRegisteredConsumer :
        IConsumer<ExecutiveTechnicianRegistered>
    {
        public Task Consume(ConsumeContext<ExecutiveTechnicianRegistered> context)
        {
            //ToDo: Write into the read database
            Console.WriteLine($"Executive Tech:{context.Message.FirstName},{context.Message.LastName}:{context.Message.NationalCode}:{context.Message.CreateDateTime}");
            return Task.CompletedTask;
        }
    }
}
