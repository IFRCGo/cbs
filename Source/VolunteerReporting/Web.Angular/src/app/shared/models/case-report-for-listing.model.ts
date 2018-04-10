import { Location } from './index';
import { Report } from './report.model';
import { CaseReportStatus } from './case-report-status.model';

export class CaseReportForListing implements Report {    
    success(): boolean { return true; }
    id: string;
    status: CaseReportStatus;
    dataCollectorId: string;
    dataCollectorDisplayName: string;
    healthRiskId: string;
    healthRisk: string;
    message: string;
    numberOfFemalesAgedOver4: number;
    numberOfFemalesAges0To4: number;
    numberOfMalesAgedOver4: number;
    numberOfMalesAges0To4: number;
    timestamp: Date;
    location: Location;AgedOver4;

    origin: string;
    parsingErrorMessage: Array<string>;
}
