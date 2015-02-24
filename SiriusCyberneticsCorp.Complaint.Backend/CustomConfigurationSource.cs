namespace SiriusCyberneticsCorp.Complaint.Backend
{
    using NServiceBus.Config;
    using NServiceBus.Config.ConfigurationSource;

    public class CustomConfigurationSource : IConfigurationSource
    {
        public T GetConfiguration<T>() where T : class, new()
        {
            if (typeof(T) == typeof(UnicastBusConfig))
            {
                return new UnicastBusConfig() as T;
            }

            if (typeof(T) == typeof(MessageForwardingInCaseOfFaultConfig))
            {
                return new MessageForwardingInCaseOfFaultConfig { ErrorQueue = "error" } as T;
            }

            return null;
        }
    }
}