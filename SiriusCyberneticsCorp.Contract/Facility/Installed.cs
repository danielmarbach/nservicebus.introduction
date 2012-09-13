namespace SiriusCyberneticsCorp.Contract.Facility
{
    using System;

    public interface Installed
    {
        Guid FacilityId { get; set; }

        string Name { get; set; }

        DateTime At { get; set; }

        string InstalledIn { get; set; }
    }
}