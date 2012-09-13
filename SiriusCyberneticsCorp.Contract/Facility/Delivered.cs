namespace SiriusCyberneticsCorp.Contract.Facility
{
    using System;

    public interface Delivered
    {
        Guid FacilityId { get; set; }

        string Name { get; set; }

        string FromLocation { get; set; }

        string ToLocation { get; set; }

        DateTime At { get; set; }
    }
}