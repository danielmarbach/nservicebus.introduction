namespace SiriusCyberneticsCorp.InternalMessages.Sales
{
    using System;

    public interface OrderFailed
    {
        Guid OrderId { get; set; } 

        Guid FacilityId { get; set; } 
    }
}