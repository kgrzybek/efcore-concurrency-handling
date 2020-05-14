using System;

namespace DDD.EF.OptimisticConcurrency.DomainModel
{
    public class OrderLineAddedDomainEvent : DomainEventBase
    {
        public OrderLineAddedDomainEvent(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; }
    }
}