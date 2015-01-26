namespace SiriusCyberneticsCorp.Complaint.Backend
{
    using System;
    using System.Runtime.InteropServices;

    using NServiceBus;
    using NServiceBus.Persistence;

    class Program
    {
        const int SwpNosize = 0x0001;

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        private static readonly IntPtr ConsolePtr = GetConsoleWindow();

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        static void Main(string[] args)
        {
            Console.Title = "Complaint.Backend";
            Console.SetWindowSize(80, 30);
            SetWindowPos(ConsolePtr, 0, 650, 420, 0, 0, SwpNosize);

            Console.WriteLine("Complaint Backend starting up...");

            var configuration = new BusConfiguration();
            configuration.Conventions()
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("SiriusCyberneticsCorp.InternalMessages"))
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("SiriusCyberneticsCorp.Contract"));

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
