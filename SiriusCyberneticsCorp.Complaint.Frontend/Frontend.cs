namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using System;

    using NServiceBus;

    using Raven.Client;

    using System.Linq;

    public class Frontend : IWantToRunAtStartup
    {
        private const string PressEnterToSendAMessageToExitCtrlC = "Press 'Enter' to send a message.To exit, Ctrl + C";

        private readonly IDocumentSession session;

        private readonly ComplainAboutSender sender;

        public Frontend(IDocumentSession session, ComplainAboutSender sender)
        {
            this.session = session;
            this.sender = sender;
        }

        public void Run()
        {
            Console.WriteLine("Complaint Frontend starting up...");
            Console.WriteLine();
            Console.WriteLine(PressEnterToSendAMessageToExitCtrlC);

            while (Console.ReadLine() != null)
            {
                var facilities = this.session.Query<Facility, Facility_ByLocationAndInstallationDate>().Take(35).ToList();
                if (!facilities.Any())
                {
                    Console.WriteLine("Nothing to complain about.");
                    continue;
                }

                for (int i = 0; i < facilities.Count(); i++)
                {
                    var facility = facilities.ElementAt(i);
                    Console.WriteLine("{0}: {1}", i, facility.Name);
                }

                Console.WriteLine("# Facility:");
                int facilityNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Galaxy wide username: ");

                string username = Console.ReadLine();

                Console.WriteLine("Your complaint:");

                string reason = Console.ReadLine();

                this.sender.Send(facilities.ElementAt(facilityNumber).FacilityId, username, reason);

                Console.WriteLine(PressEnterToSendAMessageToExitCtrlC);
            }
        }

        public void Stop()
        {
            Console.WriteLine("I see my service is not needed anymore.");
            Console.WriteLine("Complaint Frontend shutting down...");
        }
    }
}