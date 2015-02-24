namespace SiriusCyberneticsCorp.InternalMessages.Sales
{
    using System;

    public class OrderFulfilled
    {
        public Guid OrderId { get; set; }

        public Guid FacilityId { get; set; }

        public DateTime When { get; set; }

        public string Where { get; set; }
    }
}