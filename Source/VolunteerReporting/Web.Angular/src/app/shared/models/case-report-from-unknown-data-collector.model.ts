import { Location, HealthRisk } from './index';
import { Report } from './report.model';

export class CaseReportFromUnknownDataCollector implements Report {
    success(): boolean { return true; }
    id: string;
    healthRisk: HealthRisk;
    numberOfFemalesOver5: number;
    numberOfFemalesUnder5: number;
    numberOfMalesOver5: number;
    numberOfMalesUnder5: number;
    timestamp: Date;
    location: Location;
}
