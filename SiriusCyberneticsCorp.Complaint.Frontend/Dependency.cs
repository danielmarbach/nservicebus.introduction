namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using NServiceBus;

    public class Dependency : INeedInitialization
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.RegisterComponents(c => c.ConfigureComponent<ComplainAboutSender>(DependencyLifecycle.SingleInstance));
        }
    }
}