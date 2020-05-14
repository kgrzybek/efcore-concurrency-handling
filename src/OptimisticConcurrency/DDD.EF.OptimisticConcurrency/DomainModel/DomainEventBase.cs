using System;

namespace DDD.EF.OptimisticConcurrency.DomainModel
{
    public class DomainEventBase : IDomainEvent
    {
        public DomainEventBase()
        {
            this.OccurredOn = DateTime.Now;
        }

        public DateTime OccurredOn { get; }
    }
}