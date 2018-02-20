import { Location } from './index';
import { Report } from './report.model';
import { CaseReportStatus } from './case-report-status.model'

export class CaseReportForListing implements Report {
    
    /*
        public Guid Id { get; private set; }
        public CaseReportStatus Status { get; internal set; }
        public DataCollectorId DataCollectorId { get; internal set; }
        public string DataCollectorDisplayName { get; internal set; } = "Unknown"; //QUESTION: Should this be a concept with default value if unknown?
        public HealthRiskId HealthRiskId { get; internal set; }
        public string HealthRisk { get; internal set; } = "Unknown"; //QUESTION: Should this be a concept with default value if unknown?
        public int NumberOfFemalesOver5 { get; internal set; }
        public int NumberOfFemalesUnder5 { get; internal set; } 
        public int NumberOfMalesOver5 { get; internal set; } 
        public int NumberOfMalesUnder5 { get; internal set; } 
        public DateTimeOffset Timestamp { get; internal set; }
        public Location Location { get; internal set; }

    */
    success(): boolean { return true; }
    id: string;
    status: CaseReportStatus;
    dataCollectorId: string;
    dataCollectorDisplayName: string;
    healthRiskId: string;
    healthRisk: string;
    message: string;
    numberOfFemalesOver5: number;
    numberOfFemalesUnder5: number;
    numberOfMalesOver5: number;
    numberOfMalesUnder5: number;
    timestamp: Date;
    location: Location;
}
