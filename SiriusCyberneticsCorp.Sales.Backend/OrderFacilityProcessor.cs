namespace SiriusCyberneticsCorp.Sales.Backend
{
    using System;

    using NServiceBus;

    using SiriusCyberneticsCorp.Contract.Sales;
    using SiriusCyberneticsCorp.InternalMessages.Sales;

    public class OrderFacilityProcessor : IHandleMessages<OrderFacility>
    {
        private readonly IBus bus;

        public OrderFacilityProcessor(IBus bus)
        {
            this.bus = bus;
        }

        public void Handle(OrderFacility message)
        {
            Console.WriteLine("Order {0} received.", message.OrderId);

            Guid facilityId = Guid.NewGuid();

            this.bus.Publish<Ordered>(m =>
                {
                    m.OrderId = message.OrderId;
                    m.FacilityId = facilityId;
                });
        }
    }
}