namespace SiriusCyberneticsCorp.Facility
{
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
                this.bus.Publish<BecameDemotivated>(m => m.FacilityId = msg.FacilityId);
            }
        }
    }
}