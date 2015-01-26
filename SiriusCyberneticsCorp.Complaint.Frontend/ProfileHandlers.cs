namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using System;

    using NServiceBus;
    using NServiceBus.Hosting.Profiles;

    public class LiteBehavior : IHandleProfile<Lite>
    {
        public void ProfileActivated(BusConfiguration config)
        {
            Console.WriteLine("Lite profile activated!");
        }
    }

    public class IntegrationBehavior : IHandleProfile<Integration>
    {
        public void ProfileActivated(BusConfiguration config)
        {
            Console.WriteLine("Integration profile activated!");
        }
    }

    public class ProductionBehavior : IHandleProfile<Production>, IWantToRunBeforeConfigurationIsFinalized
    {
        public void ProfileActivated(BusConfiguration config)
        {
            Console.WriteLine("Production profile activated!");
        }

        public void Run(Configure configure)
        {
        }
    }

    /// <summary>
    /// This shows how it is possible to define your own profile handler which is invoked when 
    /// you start the host with the specified profile
    /// </summary>
    public class MeanBehavior : IHandleProfile<DoNotAllowAnyoneInTheUniverseToComplainAboutOurProducts>
    {
        public void ProfileActivated(BusConfiguration config)
        {
            Console.WriteLine("DoNotAllowAnyoneInTheUniverseToComplainAboutOurProducts profile activated!");

            Console.WriteLine("Muahahahha! Enabling mean mode!");

            config.RegisterComponents(c => c.ConfigureProperty<ComplainAboutSender>(s => s.MeanMode, true));
        }
    }

    /// <summary>
    /// If you provide your own profile you must implement IConfigureLoggingForProfile!
    /// </summary>
    public class MeanBehaviorLogging : NServiceBus.Hosting.Profiles.IConfigureLoggingForProfile<DoNotAllowAnyoneInTheUniverseToComplainAboutOurProducts>
    {
        public void Configure(IConfigureThisEndpoint specifier)
        {
        }
    }
}