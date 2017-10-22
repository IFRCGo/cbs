import { Location, DataCollector, HealthRisk } from './index';

export class CaseReport {
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
