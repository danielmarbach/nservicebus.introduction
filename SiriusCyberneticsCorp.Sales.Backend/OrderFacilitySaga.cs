namespace SiriusCyberneticsCorp.Sales.Backend
{
    using System;

    using NServiceBus;
    using NServiceBus.Saga;

    using SiriusCyberneticsCorp.Contract.Facility;
    using SiriusCyberneticsCorp.Contract.Sales;
    using SiriusCyberneticsCorp.InternalMessages.Sales;

    public class OrderFacilitySaga : Saga<OrderFacilitySagaData>,
        IAmStartedByMessages<OrderFacility>,
        IHandleMessages<Delivered>,
        IHandleMessages<Installed>,
        IHandleTimeouts<OrderFacility>
    {
        public override void ConfigureHowToFindSaga()
        {
            ConfigureMapping<Delivered>(s => s.FacilityId, m => m.FacilityId);
            ConfigureMapping<Installed>(s => s.FacilityId, m => m.FacilityId);
        }

        public void Handle(OrderFacility message)
        {
            this.Data.OrderId = message.OrderId;
            this.Data.FacilityId = Guid.NewGuid();

            this.RequestUtcTimeout(TimeSpan.FromSeconds(20), message);

            this.Bus.Publish<Ordered>(m =>
                {
                    m.OrderId = this.Data.OrderId;
                    m.FacilityId = this.Data.FacilityId;
                });
        }

        public void Handle(Delivered message)
        {
            this.Data.Delivered(message.At, message.ToLocation);
        }

        public void Handle(Installed message)
        {
            this.Data.Installed(message.At, message.InstalledIn);

            this.Complete();
        }

        public void Timeout(OrderFacility state)
        {
            this.Complete();
        }

        private void Complete()
        {
            if (this.Data.IsDone)
            {
                this.ReplyToOriginator<OrderFulfilled>(
                    m =>
                    {
                        m.OrderId = this.Data.OrderId;
                        m.FacilityId = this.Data.FacilityId;
                        m.When = this.Data.InstalledAt.Value;
                        m.Where = this.Data.InstalledIn;
                    });
            }
            else
            {
                this.ReplyToOriginator<OrderFailed>(
                    m =>
                        {
                            m.OrderId = this.Data.OrderId;
                            m.FacilityId = this.Data.FacilityId;
                        });
            }

            this.MarkAsComplete();
        }
    }
}