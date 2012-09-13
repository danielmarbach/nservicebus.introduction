namespace SiriusCyberneticsCorp.Contract.Sales
{
    using System;

    public interface Ordered
    {
        Guid OrderId { get; set; }

        Guid FacilityId { get; set; }
    }
}