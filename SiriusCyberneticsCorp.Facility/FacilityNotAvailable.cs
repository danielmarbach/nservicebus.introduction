namespace SiriusCyberneticsCorp.Facility
{
    using System;

    using NServiceBus;
    using NServiceBus.Saga;

    using SiriusCyberneticsCorp.Contract.Complaint;
    using SiriusCyberneticsCorp.Contract.Facility;

    public class FacilityNotAvailable : IHandleSagaNotFound
    {
        private readonly IBus bus;

        public FacilityNotAvailable(IBus bus)
        {
            this.bus = bus;
        }

        public void Handle(object message)
        {
            var msg = message as ComplainedAbout;
            if (msg != null)
            {
                Console.WriteLine("Received complaint about facility {0} which is no longer operating because of demotivation!", msg.FacilityId);

                this.bus.Publish<BecameDemotivated>(m => m.FacilityId = msg.FacilityId);
            }
        }
    }
}