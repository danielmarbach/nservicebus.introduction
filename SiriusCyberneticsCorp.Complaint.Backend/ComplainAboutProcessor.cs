namespace SiriusCyberneticsCorp.Complaint.Backend
{
    using System;

    using NServiceBus;

    using SiriusCyberneticsCorp.InternalMessages.Complaint;

    public class ComplainAboutProcessor : IHandleMessages<ComplainAbout>
    {
        public void Handle(ComplainAbout message)
        {
            Console.WriteLine(message.Reason);
        }
    }
}