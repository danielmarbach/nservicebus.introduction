namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using System;
    using System.Security.Principal;

    using NServiceBus.Installation;
    using NServiceBus.Installation.Environments;

    /// <summary>
    /// Infrastructure installers are only run when the host is instructed to do so
    /// by using the /installinfrastructure flag
    /// </summary>
    public class CustomWindowsInfrastructureInstaller : INeedToInstallInfrastructure<Windows>
    {
        public void Install(WindowsIdentity identity)
        {
            Console.WriteLine(
                "Hy there from CustomWindowsInfrastructureInstaller! I will only run when /installinfrastructure is used");
        }
    }

    /// <summary>
    /// Infrastructure installers are only run when the host is instructed to do so
    /// by using the /installinfrastructure flag
    /// </summary>
    public class CustomInfrastructureInstaller : INeedToInstallInfrastructure
    {
        public void Install(WindowsIdentity identity)
        {
            Console.WriteLine(
                "Hy there from CustomInfrastructureInstaller! I will only run when /installinfrastructure or is used");
        }
    }

    public class CustomWindowsEverytimeInstaller : INeedToInstallSomething<Windows>
    {
        public void Install(WindowsIdentity identity)
        {
            Console.WriteLine(
                "Hy there from CustomWindowsEverytimeInstaller! I will run every time!");
        }
    }

    public class CustomWindowsInstaller : INeedToInstallSomething
    {
        public void Install(WindowsIdentity identity)
        {
            Console.WriteLine(
                "Hy there from CustomWindowsInstaller! I will run every time!");
        }
    }
}