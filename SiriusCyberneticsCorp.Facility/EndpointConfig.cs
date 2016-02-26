using NServiceBus.Persistence;

namespace SiriusCyberneticsCorp.Facility
{
    using System;
    using System.Runtime.InteropServices;

    using NServiceBus;

    /// <summary>
    /// AsA_Publisher extends AsA_Server and also indicates to the infrastructure that a storage for subscription requests is to be set up.
    /// </summary>
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration configuration)
        {
            Console.Title = "Facility";

            configuration.Conventions()
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("SiriusCyberneticsCorp.InternalMessages"))
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("SiriusCyberneticsCorp.Contract"));

            configuration.UseSerialization<JsonSerializer>();
            configuration.UsePersistence<RavenDBPersistence>();
        }
    }
}