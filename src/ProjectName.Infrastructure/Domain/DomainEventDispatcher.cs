using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using ProjectName.Domain.Contracts;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Infrastructure.Domain
{
    // https://gist.github.com/jbogard/54d6569e883f63afebc7
    // http://lostechies.com/jimmybogard/2014/05/13/a-better-domain-events-pattern/
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IComponentContext _container;

        public DomainEventDispatcher(IComponentContext container)
        {
            _container = container;
        }

        public void Dispatch(DomainEventBase domainEvent)
        {
            Type handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
            Type wrapperType = typeof(DomainEventHandler<>).MakeGenericType(domainEvent.GetType());
            IEnumerable handlers = (IEnumerable)_container.Resolve(typeof(IEnumerable<>).MakeGenericType(handlerType));
            IEnumerable<DomainEventHandler> wrappedHandlers = handlers.Cast<object>()
                .Select(handler => (DomainEventHandler)Activator.CreateInstance(wrapperType, handler));

            foreach (DomainEventHandler handler in wrappedHandlers)
            {
                handler.Handle(domainEvent);
            }
        }

        private abstract class DomainEventHandler
        {
            public abstract void Handle(DomainEventBase domainEvent);
        }

        private class DomainEventHandler<T> : DomainEventHandler
            where T : DomainEventBase
        {
            private readonly IDomainEventHandler<T> handler;

            public DomainEventHandler(IDomainEventHandler<T> handler)
            {
                this.handler = handler;
            }

            public override void Handle(DomainEventBase domainEvent)
            {
                handler.Handle((T)domainEvent);
            }
        }
    }
}