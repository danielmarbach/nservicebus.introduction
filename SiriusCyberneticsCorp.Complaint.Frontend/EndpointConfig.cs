using NServiceBus.Persistence;

namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using NServiceBus;

    /// <summary>
    /// When using the generic host you have to have at least an implementor
    /// of IConfigureThisEndpoint
    /// 
    /// IWantCustomInitialization allows to specialize the configuration of the bus
    /// </summary>
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.Conventions()
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("SiriusCyberneticsCorp.InternalMessages.Complaint"))
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("SiriusCyberneticsCorp.Contract.Facility"));

            configuration.UseSerialization<JsonSerializer>();
            configuration.UsePersistence<RavenDBPersistence>();

            configuration.EnableInstallers();
        }
    }
}