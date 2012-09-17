namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using NServiceBus;

    using Raven.Client;

    using SiriusCyberneticsCorp.Contract.Facility;

    public class BecameDemotivatedHandler : IHandleMessages<BecameDemotivated>
    {
        private readonly IDocumentSession session;

        public BecameDemotivatedHandler(IDocumentSession session)
        {
            this.session = session;
        }

        public void Handle(BecameDemotivated message)
        {
            var facility = this.session.Load<Facility>(message.FacilityId);

            this.session.Delete(facility);
        }
    }
}