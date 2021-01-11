using System;

namespace NerdStore.Core.Messages.CommonMessages.DomainEvent
{
    public class DomainEvent: Event
    {
        public DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}
