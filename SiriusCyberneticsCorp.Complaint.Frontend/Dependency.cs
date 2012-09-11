namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using NServiceBus;

    public class Dependency : IWantCustomInitialization
    {
        public void Init()
        {
            Configure.Instance.Configurer.ConfigureComponent<ComplainAboutSender>(DependencyLifecycle.SingleInstance);
        }
    }
}