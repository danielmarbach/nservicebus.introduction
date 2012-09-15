namespace SiriusCyberneticsCorp.Facility
{
    using System;

    using NServiceBus.Saga;

    public class FacilitySagaData : ISagaEntity
    {
        public Guid Id { get; set; }

        public string Originator { get; set; }

        public string OriginalMessageId { get; set; }

        [Unique]
        public Guid FacilityId { get; set; }

        public Guid OrderId { get; set; }

        public string Name { get; set; }

        public int Motivation { get; set; }
    }
}