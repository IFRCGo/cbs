import { Location } from './index';
import { Report } from './report.model';
import { CaseReportStatus } from './case-report-status.model';

export class CaseReportForListing implements Report {    
    success(): boolean { return true; }
    id: string;
    status: CaseReportStatus;
    dataCollectorId: string;
    dataCollectorDisplayName: string;
    dataCollectorRegion: string;
    dataCollectorDistrict: string;
    dataCollectorVillage: string;
    healthRiskId: string;
    healthRisk: string;
    message: string;
    numberOfFemalesAged5AndOlder: number;
    numberOfFemalesUnder5: number;
    numberOfMalesAged5AndOlder: number;
    numberOfMalesUnder5: number;
    timestamp: Date;
    location: Location;AgedOver4;

    origin: string;
    parsingErrorMessage: Array<string>;
}
