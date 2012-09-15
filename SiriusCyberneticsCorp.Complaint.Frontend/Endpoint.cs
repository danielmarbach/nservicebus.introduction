namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using NServiceBus;

    /// <summary>
    /// When using the generic host you have to have at least an implementor
    /// of IConfigureThisEndpoint
    /// 
    /// IWantCustomInitialization allows to specialize the configuration of the bus
    /// </summary>
    public class Endpoint : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization, ICanBeMean
    {
        public void Init()
        {
            Configure.With(AllAssemblies.Except("Raven.Backup.exe"))
                .DefaultBuilder()
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("SiriusCyberneticsCorp.InternalMessages.Complaint"))
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("SiriusCyberneticsCorp.Contract.Facility"))
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