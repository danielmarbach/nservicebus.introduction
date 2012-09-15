namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using System;

    using NServiceBus.UnitOfWork;

    using Raven.Client;

    public class RavenUnitOfWork : IManageUnitsOfWork
    {
        private readonly IDocumentSession session;

        public RavenUnitOfWork(IDocumentSession session)
        {
            this.session = session;
        }

        public void Begin()
        {
        }

        public void End(Exception ex)
        {
            if (ex == null)
            {
                this.session.SaveChanges();
            }
        }
    }
}