namespace DDD.EF.OptimisticConcurrency.DomainModel
{
    public interface IAggregateRoot
    {
        void IncreaseVersion();
    }
}