namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using System;
    using System.Security.Principal;

    using NServiceBus.Installation;
    using NServiceBus.Installation.Environments;

    // Infrastructure installation now uses powershell. See http://www.nservicebus.com/powershell.aspx

    public class CustomWindowsEverytimeInstaller : INeedToInstallSomething<Windows>
    {
        public void Install(WindowsIdentity identity)
        {
            Console.Title = "Complaint.Frontend";

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