using NServiceBus;

namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using System;

    using NServiceBus.Installation;
    using NServiceBus.Installation.Environments;

    // Infrastructure installation now uses powershell. See http://www.nservicebus.com/powershell.aspx

    public class CustomWindowsEverytimeInstaller : INeedToInstallSomething
    {
        public void Install(string identity, Configure config)
        {
            Console.Title = "Complaint.Frontend";

            Console.WriteLine(
                "Hy there from CustomWindowsEverytimeInstaller! I will run every time! Identity {0}", identity);
        }
    }

    public class CustomWindowsInstaller : INeedToInstallSomething
    {
        public void Install(string identity, Configure config)
        {
            Console.WriteLine(
                "Hy there from CustomWindowsInstaller! I will run every time! Identity {0}", identity);
        }
    }
}