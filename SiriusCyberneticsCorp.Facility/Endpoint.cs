namespace SiriusCyberneticsCorp.Facility
{
    using NServiceBus;

    /// <summary>
    /// AsA_Publisher extends AsA_Server and also indicates to the infrastructure that a storage for subscription requests is to be set up.
    /// </summary>
    public class Endpoint : IConfigureThisEndpoint, AsA_Publisher, IWantCustomInitialization
    {
        public void Init()
        {
            Configure.With()
                .DefaultBuilder()
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("SiriusCyberneticsCorp.InternalMessages"))
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("SiriusCyberneticsCorp.Contract"))
                .JsonSerializer();
        }
    }
}