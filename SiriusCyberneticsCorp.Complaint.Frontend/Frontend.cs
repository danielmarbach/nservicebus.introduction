namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using System;

    using NServiceBus;

    public class Frontend : IWantToRunAtStartup
    {
        private const string PressEnterToSendAMessageToExitCtrlC = "Press 'Enter' to send a message.To exit, Ctrl + C";

        private readonly ComplainAboutSender sender;

        public Frontend(ComplainAboutSender sender)
        {
            this.sender = sender;
        }

        public void Run()
        {
            Console.WriteLine("Complaint Frontend starting up...");
            Console.WriteLine();
            Console.WriteLine("Some marketing information about the Complaints Devision:");
            Console.WriteLine(
                "The only profitable division of the company is its Complaints division, which takes up all of the major" 
                + " landmasses on the first three planets in the Sirius Tau system. The theme song for the Complaints division" 
                + " is Share and Enjoy, and has since become the theme apparent for the company as a whole. The main office "
                + "building and headquarters for the company was originally built to represent this motto, but due to bad "
                + "architecture it sank halfway into the ground, killing many talented young complaints executives. " 
                + "The downside to this is that the upper halves of the motto's words now read, in the local language, \"Go Stick Your Head in a Pig.\"");
            Console.WriteLine();
            Console.WriteLine(PressEnterToSendAMessageToExitCtrlC);

            while (Console.ReadLine() != null)
            {
                Console.WriteLine("Galaxy wide username: ");

                string username = Console.ReadLine();

                Console.WriteLine("Your complaint:");

                string reason = Console.ReadLine();

                this.sender.Send(Guid.NewGuid(), username, reason);

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