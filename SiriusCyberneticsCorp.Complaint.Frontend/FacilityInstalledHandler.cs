namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using NServiceBus;

    using Raven.Client;

    using SiriusCyberneticsCorp.Contract.Facility;

    public class FacilityInstalledHandler : IHandleMessages<Installed>
    {
        private readonly IDocumentSession session;

        public FacilityInstalledHandler(IDocumentSession session)
        {
            this.session = session;
        }

        public void Handle(Installed message)
        {
            this.session.Store(new Facility
                {
                    FacilityId = message.FacilityId,
                    Name = message.Name,
                    InstalledAt = message.At,
                    Location = message.InstalledIn
                });
        }
    }
}