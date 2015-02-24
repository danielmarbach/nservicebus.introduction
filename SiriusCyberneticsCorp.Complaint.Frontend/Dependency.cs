using System.Reflection;
using NServiceBus;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    public class Dependency : INeedInitialization
    {
        public void Customize(BusConfiguration configuration)
        {
            var documentStore = new DocumentStore
            {
                Url = "http://localhost:8080",
                DefaultDatabase = "Complaint.Frontend"
            };
            documentStore.Initialize();

            IndexCreation.CreateIndexes(Assembly.GetExecutingAssembly(), documentStore);

            configuration.RegisterComponents(c => c.ConfigureComponent<IDocumentStore>(() => documentStore, DependencyLifecycle.SingleInstance));

            configuration.RegisterComponents(c => c.ConfigureComponent<IDocumentSession>(() => documentStore.OpenSession(), DependencyLifecycle.InstancePerUnitOfWork));

            configuration.RegisterComponents(c => c.ConfigureComponent<RavenUnitOfWork>(DependencyLifecycle.InstancePerCall));

            configuration.RegisterComponents(c => c.ConfigureComponent<ComplainAboutSender>(DependencyLifecycle.SingleInstance));
        }
    }
}