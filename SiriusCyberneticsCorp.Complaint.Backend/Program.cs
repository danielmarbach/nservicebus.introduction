namespace SiriusCyberneticsCorp.Complaint.Backend
{
    using System;
    using System.Runtime.InteropServices;

    using NServiceBus;

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

            Configure.With()
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("SiriusCyberneticsCorp.InternalMessages"))
                .CustomConfigurationSource(new CustomConfigurationSource())
                .DefaultBuilder();

            Configure.Serialization.Json();

            Configure.Instance.UseTransport<Msmq>()
                .PurgeOnStartup(false);

            Configure.Transactions.Enable();

            Configure.Instance
                .RavenSubscriptionStorage()
                .UnicastBus()
                    .RunHandlersUnderIncomingPrincipal(false)
                    .LoadMessageHandlers()
                .CreateBus()
                .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install());

            Console.WriteLine("Press any key to shut down.");

            Console.ReadLine();
            Console.WriteLine("Complaint Backend shutting down...");
        }
    }
}
