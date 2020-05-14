namespace DDD.EF.OptimisticConcurrency.DomainModel
{
    public class AggregateRootBase : Entity, IAggregateRoot
    {
        private int _versionId;

        public void IncreaseVersion()
        {
            _versionId++;
        }
    }
}