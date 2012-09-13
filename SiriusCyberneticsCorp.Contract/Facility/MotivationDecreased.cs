namespace SiriusCyberneticsCorp.Contract.Facility
{
    using System;

    public interface MotivationDecreased
    {
        Guid FacilityId { get; set; }

        int Amount { get; set; }
    }
}