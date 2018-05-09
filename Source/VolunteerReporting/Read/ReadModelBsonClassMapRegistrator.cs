using Read.AutomaticReplyMessages;
using Read.CaseReports;
using Read.CaseReportsForListing;
using Read.DataCollectors;
using Read.HealthRisks;
using Read.InvalidCaseReports;
using Read.Projects;

namespace Read
{
    public static class ReadModelBsonClassMapRegistrator
    {
        public static void RegisterAllReadModelBsonClassMaps()
        {
            RegisterAllAutomaticReplyMessagesBsonClassMaps();
            RegisterAllCaseReportsBsonClassMaps();
            RegisterAllCaseReportsForListingBsonClassMaps();
            RegisterAllDataCollectorsBsonClassMaps();
            RegisterAllHealthRisksBsonClassMaps();
            RegisterAllInvalidCaseReportsBsonClassMaps();
            RegisterAllProjectsBsonClassMaps();
        }

        public static void RegisterAllAutomaticReplyMessagesBsonClassMaps()
        {
            AutomaticReplyBsonClassMapRegistrator.Register();
            AutomaticReplyKeyMessageBsonClassMapRegistrator.Register();
            DefaultAutomaticReplyBsonClassMapRegistrator.Register();
            DefaultAutomaticReplyMessageBsonClassMapRegistrator.Register();
        }

        public static void RegisterAllCaseReportsBsonClassMaps()
        {
            CaseReportBsonClassMapRegistrator.Register();
            CaseReportFromUnknownDataCollectorBsonClassMapRegistrator.Register();
        }

        public static void RegisterAllCaseReportsForListingBsonClassMaps()
        {
            CaseReportForListingBsonClassMapRegistrator.Register();
        }

        public static void RegisterAllDataCollectorsBsonClassMaps()
        {
            DataCollectorBsonClassMapRegistrator.Register();
        }

        public static void RegisterAllHealthRisksBsonClassMaps()
        {
            HealthRIskBsonClassMapRegistrator.Register();
        }

        public static void RegisterAllInvalidCaseReportsBsonClassMaps()
        {
            InvalidCaseReportBsonClassMapRegistrator.Register();
            InvalidCaseReportFromUnknownDataCollectorBsonClassMapRegistrator.Register();
        }

        public static void RegisterAllProjectsBsonClassMaps()
        {
            ProjectBsonClassMapRegistrator.Register();
        }

    }
}