namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using System;

    using NServiceBus;
    using NServiceBus.Hosting.Profiles;
    using NServiceBus.ObjectBuilder;

    public class LiteBehavior : IHandleProfile<Lite>, IWantTheEndpointConfig
    {
        public IConfigureThisEndpoint Config { get; set; }

        public void ProfileActivated()
        {
            Console.WriteLine("Lite profile activated!");
        }
    }

    public class IntegrationBehavior : IHandleProfile<Integration>, IWantTheEndpointConfig
    {
        public IConfigureThisEndpoint Config { get; set; }

        public void ProfileActivated()
        {
            Console.WriteLine("Integration profile activated!");
        }
    }

    public class ProductionBehavior : IHandleProfile<Production>, IWantToRunBeforeConfigurationIsFinalized
    {
        public void ProfileActivated()
        {
            Console.WriteLine("Production profile activated!");
        }

        public void Run()
        {
            
        }
    }

    /// <summary>
    /// This shows how it is possible to define your own profile handler which is invoked when 
    /// you start the host with the specified profile
    /// </summary>
    public class MeanBehavior : IHandleProfile<DoNotAllowAnyoneInTheUniverseToComplainAboutOurProducts>, IWantTheEndpointConfig
    {
        public IConfigureThisEndpoint Config { get; set; }

        public void ProfileActivated()
        {
            Console.WriteLine("DoNotAllowAnyoneInTheUniverseToComplainAboutOurProducts profile activated!");

            var canBeMean = Config as ICanBeMean;
            if (canBeMean != null)
            {
                Console.WriteLine("Muahahahha! Enabling mean mode!");
                canBeMean.BeMean();
            }
        }
    }

    /// <summary>
    /// If you provide your own profile you must implement IConfigureLoggingForProfile!
    /// </summary>
    public class MeanBehaviorLogging : IConfigureLoggingForProfile<DoNotAllowAnyoneInTheUniverseToComplainAboutOurProducts>
    {
        public void Configure(IConfigureThisEndpoint specifier)
        {
            
        }
    }
}