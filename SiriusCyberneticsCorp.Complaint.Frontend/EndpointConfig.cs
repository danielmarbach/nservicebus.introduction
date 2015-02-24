using NServiceBus.Persistence;

namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using System;
    using System.Runtime.InteropServices;

    using NServiceBus;

    /// <summary>
    /// When using the generic host you have to have at least an implementor
    /// of IConfigureThisEndpoint
    /// 
    /// IWantCustomInitialization allows to specialize the configuration of the bus
    /// </summary>
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        const int SwpNosize = 0x0001;

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        private static readonly IntPtr ConsolePtr = GetConsoleWindow();

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        public void Customize(BusConfiguration configuration)
        {
            Console.SetWindowSize(70, 30);
            SetWindowPos(ConsolePtr, 0, 10, 420, 0, 0, SwpNosize);

            configuration.Conventions()
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("SiriusCyberneticsCorp.InternalMessages.Complaint"))
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("SiriusCyberneticsCorp.Contract.Facility"));

            configuration.UseSerialization<JsonSerializer>();
            configuration.UsePersistence<RavenDBPersistence>();

            configuration.EnableInstallers();
        }
    }
}