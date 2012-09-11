namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using System;

    using NServiceBus;

    using SiriusCyberneticsCorp.InternalMessages.Complaint;

    public class ComplainAboutSender
    {
        private readonly IBus bus;

        public ComplainAboutSender(IBus bus)
        {
            this.bus = bus;
        }

        public bool MeanMode { get; set; }

        public void Send(Guid facilityId, string username, string reason)
        {
            if (MeanMode)
            {
                Console.WriteLine("Ooops! Your complaint was accidentally burned by a nearby Infinite Improbability Drive!");
                return;
            }

            this.bus.Send<ComplainAbout>(
                c =>
                    {
                        c.FacilityId = facilityId;
                        c.GalaxyWideUniqueUsername = username;
                        c.Reason = reason;
                    });
        }
    }
}