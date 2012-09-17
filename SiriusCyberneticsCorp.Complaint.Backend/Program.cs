namespace SiriusCyberneticsCorp.Complaint.Backend
{
    using System;

    using NServiceBus;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Complaint.Backend";

            Console.WriteLine("Complaint Backend starting up...");

            Configure.With()
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("SiriusCyberneticsCorp.InternalMessages"))
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("SiriusCyberneticsCorp.Contract"))
                .CustomConfigurationSource(new CustomConfigurationSource())
                .DefaultBuilder()
                .JsonSerializer()
                .MsmqTransport()
                    .IsTransactional(true)
                    .PurgeOnStartup(false)
                .RavenSubscriptionStorage()
                .UnicastBus()
                    .ImpersonateSender(false)
                    .LoadMessageHandlers()
                .CreateBus()
                .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install());

            Console.WriteLine("Press any key to shut down.");

            Console.ReadLine();
            Console.WriteLine("Complaint Backend shutting down...");
        }
    }
}
