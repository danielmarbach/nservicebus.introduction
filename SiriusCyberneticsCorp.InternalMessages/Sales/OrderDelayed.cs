namespace SiriusCyberneticsCorp.InternalMessages.Sales
{
    using System;

    public interface OrderDelayed
    {
        Guid OrderId { get; set; } 

        Guid FacilityId { get; set; } 
    }
}