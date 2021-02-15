using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ProjectName.Domain.Contracts;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.UnitTests.SeedWork
{
    public class TestBase
    {
        public static T AssertPublishedDomainEvent<T, TKey>(EntityBase<StronglyTypedIdBase> aggregate)
            where T : DomainEventBase
        {
            var domainEvent = DomainEventsTestHelper.GetAllDomainEvents(aggregate).OfType<T>().SingleOrDefault();

            if (domainEvent == null)
            {
                throw new Exception($"{typeof(T).Name} event not published");
            }

            return domainEvent;
        }

        public static void AssertDomainEventNotPublished<T>(EntityBase<StronglyTypedIdBase> aggregate)
            where T : DomainEventBase
        {
            var domainEvent = DomainEventsTestHelper.GetAllDomainEvents(aggregate).OfType<T>().SingleOrDefault();
            Assert.Null(domainEvent);
        }

        public static List<T> AssertPublishedDomainEvents<T>(EntityBase<StronglyTypedIdBase> aggregate)
            where T : DomainEventBase
        {
            var domainEvents = DomainEventsTestHelper.GetAllDomainEvents(aggregate).OfType<T>().ToList();

            if (!domainEvents.Any())
            {
                throw new Exception($"{typeof(T).Name} event not published");
            }

            return domainEvents;
        }

        public static void AssertBrokenRule<TRule>(TestDelegate testDelegate)
            where TRule : class, IBusinessRule
        {
            var message = $"Expected {typeof(TRule).Name} broken rule";
            var businessRuleValidationException = Assert.Catch<BusinessRuleValidationException>(testDelegate, message);
            if (businessRuleValidationException != null)
            {
                Assert.That(businessRuleValidationException.BrokenRule, Is.TypeOf<TRule>(), message);
            }
        }

        public static void AssertBrokenRule<TRule>(AsyncTestDelegate testDelegate)
            where TRule : class, IBusinessRule
        {
            var message = $"Expected {typeof(TRule).Name} broken rule";
            var businessRuleValidationException = Assert.CatchAsync<BusinessRuleValidationException>(testDelegate, message);
            if (businessRuleValidationException != null)
            {
                Assert.That(businessRuleValidationException.BrokenRule, Is.TypeOf<TRule>(), message);
            }
        }
    }
}