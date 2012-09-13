namespace SiriusCyberneticsCorp.InternalMessages.Sales
{
    using System;

    public interface OrderFulfilled
    {
        Guid OrderId { get; set; }

        Guid FacilityId { get; set; }

        DateTime When { get; set; }

        string Where { get; set; }
    }
}