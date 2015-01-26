namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using System.Reflection;

    using NServiceBus;

    using Raven.Client;
    using Raven.Client.Embedded;
    using Raven.Client.Indexes;

    public class Dependency : INeedInitialization
    {
        public void Customize(BusConfiguration configuration)
        {
            var documentStore = new EmbeddableDocumentStore { DataDirectory = @".\Data", EnlistInDistributedTransactions = true };
            documentStore.Initialize();

            IndexCreation.CreateIndexes(Assembly.GetExecutingAssembly(), documentStore);

            configuration.RegisterComponents(c => c.ConfigureComponent<IDocumentStore>(() => documentStore, DependencyLifecycle.SingleInstance));

            configuration.RegisterComponents(c => c.ConfigureComponent<IDocumentSession>(() => documentStore.OpenSession(), DependencyLifecycle.InstancePerUnitOfWork));

            configuration.RegisterComponents(c => c.ConfigureComponent<RavenUnitOfWork>(DependencyLifecycle.InstancePerCall));

            configuration.RegisterComponents(c => c.ConfigureComponent<ComplainAboutSender>(DependencyLifecycle.SingleInstance));
        }
    }
}