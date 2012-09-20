namespace SiriusCyberneticsCorp.Sales.Backend
{
    using System;

    using NServiceBus;

    using SiriusCyberneticsCorp.Contract.Facility;

    public class InstalledHandler : IHandleMessages<Installed>
    {
        public void Handle(Installed message)
        {
            Console.WriteLine("Received installation notice about {0}", message.Name);
        }
    }
}