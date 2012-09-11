namespace SiriusCyberneticsCorp.InternalMessages.Complaint
{
    using System;

    public interface ComplainAbout
    {
        Guid FacilityId { get; set; }

        string GalaxyWideUniqueUsername { get; set; }

        string Reason { get; set; }
    }
}