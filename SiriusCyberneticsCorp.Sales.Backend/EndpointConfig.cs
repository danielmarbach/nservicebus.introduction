using NServiceBus.Persistence;

namespace SiriusCyberneticsCorp.Sales.Backend
{
    using System;
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration configuration)
        {
            Console.Title = "Sales.Backend";

            Console.SetWindowSize(70, 29);

            configuration
                .Conventions()
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("SiriusCyberneticsCorp.InternalMessages"))
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("SiriusCyberneticsCorp.Contract"));

            configuration.UseSerialization<JsonSerializer>();
            configuration.UsePersistence<RavenDBPersistence>();
        }
    }
}
