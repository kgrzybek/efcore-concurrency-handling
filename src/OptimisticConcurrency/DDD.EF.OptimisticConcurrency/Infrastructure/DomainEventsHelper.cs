using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DDD.EF.OptimisticConcurrency.DomainModel;

namespace DDD.EF.OptimisticConcurrency.Infrastructure
{
    public class DomainEventsHelper
    {
        public static List<IDomainEvent> GetAllDomainEvents(IAggregateRoot aggregate)
        {
            return GetAllDomainEvents(aggregate as Entity);
        }

        private static List<IDomainEvent> GetAllDomainEvents(Entity entity)
        {
            List<IDomainEvent> domainEvents = new List<IDomainEvent>();

            if (entity.DomainEvents != null)
            {
                domainEvents.AddRange(entity.DomainEvents);
            }

            var fields = entity.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).Concat(entity.GetType().BaseType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)).ToArray();

            foreach (var field in fields)
            {
                var isEntity = field.FieldType.IsAssignableFrom(typeof(Entity));

                if (isEntity)
                {
                    var entityObject = field.GetValue(entity) as Entity;
                    domainEvents.AddRange(GetAllDomainEvents(entityObject).ToList());
                }

                if (field.FieldType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(field.FieldType))
                {
                    if (field.GetValue(entity) is IEnumerable enumerable)
                    {
                        foreach (var en in enumerable)
                        {
                            if (en is Entity entityItem)
                            {
                                domainEvents.AddRange(GetAllDomainEvents(entityItem));
                            }
                        }
                    }
                }
            }

            return domainEvents;
        }
    }
}