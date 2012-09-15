namespace SiriusCyberneticsCorp.InternalMessages.Sales
{
    using System;

    public interface OrderFacility
    {
        Guid OrderId { get; set; }

        Guid CategoryId { get; set; }
    }
}