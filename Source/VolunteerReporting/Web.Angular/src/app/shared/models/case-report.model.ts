import { Location, DataCollector, HealthRisk } from './index';
import { Report } from './report.model';

export class CaseReport implements Report {
    success(): boolean { return true; }
    id: string;
    dataCollector: DataCollector;
    healthRiskId: HealthRisk;
    numberOfFemalesOver5: number;
    numberOfFemalesUnder5: number;
    numberOfMalesOver5: number;
    numberOfMalesUnder5: number;
    timestamp: Date;
    location: Location;
}
