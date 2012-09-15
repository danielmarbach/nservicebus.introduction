namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using System.Reflection;

    using NServiceBus;

    using Raven.Client;
    using Raven.Client.Embedded;
    using Raven.Client.Indexes;

    public class Dependency : IWantCustomInitialization
    {
        public void Init()
        {
            var documentStore = new EmbeddableDocumentStore { DataDirectory = @".\Data", EnlistInDistributedTransactions = true };
            documentStore.Initialize();

            IndexCreation.CreateIndexes(Assembly.GetExecutingAssembly(), documentStore);

            Configure.Instance.Configurer.ConfigureComponent<IDocumentStore>(() => documentStore, DependencyLifecycle.SingleInstance);

            Configure.Instance.Configurer.ConfigureComponent<IDocumentSession>(() => documentStore.OpenSession(), DependencyLifecycle.InstancePerUnitOfWork);

            Configure.Instance.Configurer.ConfigureComponent<RavenUnitOfWork>(DependencyLifecycle.InstancePerCall);
            
            Configure.Instance.Configurer.ConfigureComponent<ComplainAboutSender>(DependencyLifecycle.SingleInstance);
        }
    }
}