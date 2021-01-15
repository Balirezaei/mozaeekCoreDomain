using System;
using MozaeekCore.Core.Domain;

namespace MozaeekCore.Domain
{
    public class UnProcessedRequest: AggregateRootBase
    {
        public DateTime CreateDateTime { get; private set; }
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Summery { get; private set; }
        public bool IsProcessed { get; private set; }
        protected UnProcessedRequest() { }
        public UnProcessedRequest(string title, string summery)
        {
            Title = title;
            Summery = summery;
            this.CreateDateTime = DateTime.Now;
            this.IsProcessed = false;
            //ToDo : Publish event in EventPublisher
        }
    }
}