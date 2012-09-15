namespace SiriusCyberneticsCorp.Complaint.Frontend
{
    using System;
    using System.Linq;

    using Raven.Client.Indexes;

    public class Facility
    {
        public string Location { get; set; }

        public DateTime InstalledAt { get; set; }

        public string Name { get; set; }

        public Guid FacilityId { get; set; }
    }

    public class Facility_ByLocationAndInstallationDate : AbstractIndexCreationTask<Facility>
    {
        public Facility_ByLocationAndInstallationDate()
        {
            Map = facilities => from facility in facilities
                           select new
                           {
                               facility.Location,
                               facility.InstalledAt,
                               facility.Name,
                               facility.FacilityId
                           };

            Reduce = results => from result in results
                                group result by new
                                {
                                    result.InstalledAt,
                                    result.Location,
                                }
                                    into facility
                                    let lastFacility = facility.First()
                                    select new
                                    {
                                        lastFacility.Location,
                                        lastFacility.InstalledAt,
                                        lastFacility.Name,
                                        lastFacility.FacilityId,
                                    };
        }
    }
}