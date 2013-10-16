namespace SiriusCyberneticsCorp.Complaint.Backend
{
    using System;

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
            Console.WriteLine("Received complain about {0} with reason {1}.", message.FacilityId, message.Reason);

            this.bus.Publish<ComplainedAbout>(m =>
                { 
                    m.FacilityId = message.FacilityId;
                });
        }
    }
}