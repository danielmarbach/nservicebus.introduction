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
        IHandleMessages<Installed>,
        IHandleTimeouts<OrderFacility>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<OrderFacilitySagaData> mapper)
        {
            mapper.ConfigureMapping<Installed>(m => m.FacilityId).ToSaga(s => s.FacilityId);
        }

        public void Handle(OrderFacility message)
        {
            this.Data.OrderId = message.OrderId;
            this.Data.FacilityId = Guid.NewGuid();
            this.Data.CategoryId = message.CategoryId;

            Console.WriteLine("Order {0} received.", this.Data.OrderId);

            this.RequestTimeout(TimeSpan.FromSeconds(20), message);

            this.Bus.Publish<Ordered>(m =>
                {
                    m.OrderId = this.Data.OrderId;
                    m.FacilityId = this.Data.FacilityId;
                });
        }

        public void Handle(Installed message)
        {
            Console.WriteLine("Facility {0} installed at {1}.", message.InstalledIn, message.At.ToString());

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
                Console.WriteLine("Order {0} fulfilled.", this.Data.OrderId);

                var orderFulfilled = new OrderFulfilled
                {
                    OrderId = this.Data.OrderId,
                    FacilityId = this.Data.FacilityId,
                    When = this.Data.InstalledAt.Value,
                    Where = this.Data.InstalledIn,
                };

                this.ReplyToOriginator(orderFulfilled);
            }
            else
            {
                Console.WriteLine("Order {0} delayed.", this.Data.OrderId);

                var orderDelayed = new OrderDelayed
                {
                    OrderId = this.Data.OrderId,
                    FacilityId = this.Data.FacilityId,
                };
                this.ReplyToOriginator(orderDelayed);
            }

            this.MarkAsComplete();
        }
    }
}