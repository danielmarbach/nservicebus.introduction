namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using System;

    using NServiceBus;

    public class Frontend : IWantToRunAtStartup
    {
        private const string PressEnterToSendAMessageToExitCtrlC = "Press 'Enter' to send a message.To exit, Ctrl + C";

        public void Run()
        {
            Console.WriteLine("Complaint Frontend starting up...");
            Console.WriteLine();
            Console.WriteLine(PressEnterToSendAMessageToExitCtrlC);

            while (Console.ReadLine() != null)
            {
            }

            Console.WriteLine(PressEnterToSendAMessageToExitCtrlC);
        }

        public void Stop()
        {
            Console.WriteLine("I see my service is not needed anymore.");
            Console.WriteLine("Complaint Frontend shutting down...");
        }
    }
}