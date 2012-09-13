namespace SiriusCyberneticsCorp.Sales.Backend
{
    using System;

    using NServiceBus.Saga;

    public class OrderFacilitySagaData : ISagaEntity
    {
        public Guid Id { get; set; }

        public string Originator { get; set; }

        public string OriginalMessageId { get; set; }

        [Unique]
        public Guid OrderId { get; set; }

        public Guid FacilityId { get; set; }

        public bool IsDone
        {
            get
            {
                return this.DeliveredAt.HasValue && this.InstalledAt.HasValue;
            }
        }

        public DateTime? DeliveredAt { get; private set; }

        public string ToLocation { get; set; }

        public DateTime? InstalledAt { get; private set; }

        public string InstalledIn { get; private set; }

        public void Installed(DateTime at, string installedIn)
        {
            this.InstalledAt = at;
            this.InstalledIn = installedIn;
        }

        public void Delivered(DateTime at, string toLocation)
        {
            this.DeliveredAt = at;
            this.ToLocation = toLocation;
        }
    }
}