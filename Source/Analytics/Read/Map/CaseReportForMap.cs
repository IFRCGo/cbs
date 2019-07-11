using System;
using Dolittle.ReadModels;
using Concepts;
using Concepts.HealthRisk;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace Read.Overview.Map
{
    public class CaseReportForMap 
    {
        public CaseReportId CaseReportsId { get; set; }
        public NumberOfPeople NumberOfPeople { get; set; }
        public Location Location { get; set; }
        public Region Region { get; set; }

    }


}