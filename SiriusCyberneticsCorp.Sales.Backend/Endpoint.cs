namespace SiriusCyberneticsCorp.Sales.Backend
{
    using System;
    using NServiceBus;

    public class Endpoint : IConfigureThisEndpoint, AsA_Publisher, IWantCustomInitialization
    {
        public void Init()
        {
            Console.Title = "Sales.Backend";

            Configure.With()
                .DefaultBuilder()
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("SiriusCyberneticsCorp.InternalMessages"))
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("SiriusCyberneticsCorp.Contract"))
                .JsonSerializer();
        }
    }
}
