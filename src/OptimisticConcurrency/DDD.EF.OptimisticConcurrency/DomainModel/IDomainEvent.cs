using System;

namespace DDD.EF.OptimisticConcurrency.DomainModel
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}