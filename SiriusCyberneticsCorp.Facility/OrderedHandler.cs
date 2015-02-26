namespace SiriusCyberneticsCorp.Facility
{
    using System;

    using NServiceBus;

    using SiriusCyberneticsCorp.Contract.Facility;
    using SiriusCyberneticsCorp.Contract.Sales;

    public class OrderedHandler : IHandleMessages<Ordered>
    {
        private readonly IBus bus;

        public OrderedHandler(IBus bus)
        {
            this.bus = bus;
        }

        public void Handle(Ordered message)
        {
            Console.WriteLine("Someone ordered a facility with order number {0}", message.OrderId);

            this.bus.Publish<Installed>(
                m =>
                {
                    m.FacilityId = message.FacilityId;
                    m.At = DateTime.UtcNow;
                    m.InstalledIn = "Building 42";
                    m.Name = string.Format("VHPT-{0}", message.FacilityId.ToString().Substring(0, 6)).ToUpper();
                });
        }
    }
}