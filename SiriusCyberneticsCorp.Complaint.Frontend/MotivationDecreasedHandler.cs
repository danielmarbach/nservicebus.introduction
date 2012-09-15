namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using NServiceBus;

    using Raven.Client;

    using SiriusCyberneticsCorp.Contract.Facility;

    public class MotivationDecreasedHandler : IHandleMessages<MotivationDecreased>
    {
        private readonly IDocumentSession session;

        public MotivationDecreasedHandler(IDocumentSession session)
        {
            this.session = session;
        }

        public void Handle(MotivationDecreased message)
        {
            var facility = this.session.Load<Facility>(message.FacilityId);

            facility.Motivation -= message.Amount;
        }
    }
}