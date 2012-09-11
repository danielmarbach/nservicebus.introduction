namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using NServiceBus;

    /// <summary>
    /// When using the generic host you have to have at least an implementor
    /// of IConfigureThisEndpoint
    /// 
    /// AsA_Client sets MsmqTransport to be non-transactional, and it purges 
    /// its queue of messages on startup. This means that it starts fresh every time, 
    /// not remembering anything before a crash. Also, it processes messages using 
    /// its own permissions, not those of the message sender.
    /// 
    /// IWantCustomInitialization allows to specialize the configuration of the bus
    /// </summary>
    public class Endpoint : IConfigureThisEndpoint, AsA_Client, IWantCustomInitialization, ICanBeMean
    {
        public void Init()
        {
            Configure.With()
                .DefaultBuilder()
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("SiriusCyberneticsCorp.InternalMessages"))
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("SiriusCyberneticsCorp.Contract"))
                .JsonSerializer();
        }

        public void BeMean()
        {
            Configure.Instance.Configurer.ConfigureProperty<ComplainAboutSender>(s => s.MeanMode, true);
        }
    }

    public interface ICanBeMean
    {
        void BeMean();
    }
}