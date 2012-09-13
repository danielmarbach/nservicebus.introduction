namespace SiriusCyberneticsCorp.Sales.Frontend.Injection
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using NServiceBus;
    using NServiceBus.ObjectBuilder;

    public class NServiceBusDependencyResolverAdapter : IDependencyResolver
    {
        readonly IBuilder builder;

        public NServiceBusDependencyResolverAdapter(IBuilder builder)
        {
            this.builder = builder;
        }

        public object GetService(Type serviceType)
        {
            return Configure.Instance.Configurer.HasComponent(serviceType) ? this.builder.Build(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return builder.BuildAll(serviceType);
        }
    }
}