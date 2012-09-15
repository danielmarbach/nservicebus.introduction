namespace SiriusCyberneticsCorp.Complaint.Backend
{
    using NServiceBus;

    using SiriusCyberneticsCorp.Contract.Complaint;
    using SiriusCyberneticsCorp.InternalMessages.Complaint;

    public class ComplainAboutProcessor : IHandleMessages<ComplainAbout>
    {
        private readonly IBus bus;

        public ComplainAboutProcessor(IBus bus)
        {
            this.bus = bus;
        }

        public void Handle(ComplainAbout message)
        {
            this.bus.Publish<ComplainedAbout>(m =>
                { 
                    m.FacilityId = message.FacilityId;
                });
        }
    }
}