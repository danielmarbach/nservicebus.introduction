namespace SiriusCyberneticsCorp.Complaint.Backend
{
    using System;
    using NServiceBus;
    using NServiceBus.Persistence;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Complaint.Backend";

            Console.WriteLine("Complaint Backend starting up...");

            var configuration = new BusConfiguration();

            configuration.CustomConfigurationSource(new CustomConfigurationSource());

            configuration.UseSerialization<JsonSerializer>();
            configuration.UsePersistence<RavenDBPersistence>();
            configuration.UseTransport<MsmqTransport>();

            var bus = Bus.Create(configuration).Start();

            Console.WriteLine("Press any key to shut down.");

            Console.ReadLine();
            Console.WriteLine("Complaint Backend shutting down...");

            bus.Dispose();
        }
    }
}
