using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.UnitTests.SeedWork
{
    public class DomainEventsTestHelper
    {
        public static List<DomainEventBase> GetAllDomainEvents(EntityBase<StronglyTypedIdBase> aggregate)
        {
            List<DomainEventBase> domainEvents = new List<DomainEventBase>();

            if (aggregate.Events != null)
            {
                domainEvents.AddRange(aggregate.Events);
            }

            var fields = aggregate.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).Concat(aggregate.GetType().BaseType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)).ToArray();

            foreach (var field in fields)
            {
                var isEntity = typeof(EntityBase<>).IsAssignableFrom(field.FieldType);

                if (isEntity)
                {
                    var entity = field.GetValue(aggregate) as EntityBase<StronglyTypedIdBase>;
                    domainEvents.AddRange(GetAllDomainEvents(entity).ToList());
                }

                if (field.FieldType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(field.FieldType))
                {
                    if (field.GetValue(aggregate) is IEnumerable enumerable)
                    {
                        foreach (var en in enumerable)
                        {
                            if (en is EntityBase<StronglyTypedIdBase> entityItem)
                            {
                                domainEvents.AddRange(GetAllDomainEvents(entityItem));
                            }
                        }
                    }
                }
            }

            return domainEvents;
        }

        public static void ClearAllDomainEvents(EntityBase<StronglyTypedIdBase> aggregate)
        {
            aggregate.ClearDomainEvents();

            var fields = aggregate.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).Concat(aggregate.GetType().BaseType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)).ToArray();

            foreach (var field in fields)
            {
                var isEntity = field.FieldType.IsAssignableFrom(typeof(EntityBase<>));

                if (isEntity)
                {
                    var entity = field.GetValue(aggregate) as EntityBase<StronglyTypedIdBase>;
                    ClearAllDomainEvents(entity);
                }

                if (field.FieldType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(field.FieldType))
                {
                    if (field.GetValue(aggregate) is IEnumerable enumerable)
                    {
                        foreach (var en in enumerable)
                        {
                            if (en is EntityBase<StronglyTypedIdBase> entityItem)
                            {
                                ClearAllDomainEvents(entityItem);
                            }
                        }
                    }
                }
            }
        }
    }
}
