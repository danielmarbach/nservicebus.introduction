namespace SiriusCyberneticsCorp.InternalMessages.Sales
{
    using System;

    public class OrderDelayed
    {
        public Guid OrderId { get; set; }

        public Guid FacilityId { get; set; } 
    }
}