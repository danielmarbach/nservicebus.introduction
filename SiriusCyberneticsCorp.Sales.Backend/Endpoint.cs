using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiriusCyberneticsCorp.Sales.Backend
{
    using NServiceBus;

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
