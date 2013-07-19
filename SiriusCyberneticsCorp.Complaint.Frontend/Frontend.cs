namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using System;
    using System.Collections.Generic;

    using NServiceBus;

    using Raven.Client;

    using System.Linq;

    public class Frontend : IWantToRunWhenBusStartsAndStops
    {
        private const string PressEnterToSendAMessageToExitCtrlC = "Press 'Enter' to send a message.To exit, Ctrl + C";

        private readonly IDocumentStore store;

        private readonly ComplainAboutSender sender;

        public Frontend(IDocumentStore store, ComplainAboutSender sender)
        {
            this.store = store;
            this.sender = sender;
        }

        public void Start()
        {
            Console.WriteLine("Complaint Frontend starting up...");
            Console.WriteLine();
            Console.WriteLine(PressEnterToSendAMessageToExitCtrlC);

            while (Console.ReadLine() != null)
            {
                List<Facility> facilities;
                using (var session = this.store.OpenSession())
                {
                    facilities = session.Query<Facility, Facility_ByLocationAndInstallationDate>().Take(35).ToList();
                }

                if (!facilities.Any())
                {
                    Console.WriteLine("Nothing to complain about.");
                    continue;
                }

                PrintFacilities(facilities);

                Console.WriteLine("# Facility:");
                int facilityNumber;
                try
                {
                    facilityNumber = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    continue;
                }

                Console.WriteLine("Galaxy wide username: ");

                string username = Console.ReadLine();

                Console.WriteLine("Your complaint:");

                string reason = Console.ReadLine();

                this.sender.Send(facilities.ElementAt(facilityNumber).FacilityId, username, reason);
            }

            Console.WriteLine(PressEnterToSendAMessageToExitCtrlC);
        }

        private static void PrintFacilities(List<Facility> facilities)
        {
            for (int i = 0; i < facilities.Count(); i++)
            {
                var facility = facilities.ElementAt(i);
                Console.WriteLine("{0}: {1} (Motivation: {2})", i, facility.Name, facility.Motivation);
            }
        }

        public void Stop()
        {
            Console.WriteLine("I see my service is not needed anymore.");
            Console.WriteLine("Complaint Frontend shutting down...");
        }
    }
}