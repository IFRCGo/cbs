import { Location } from './index';

export class CaseReport {
    id: string;
    dataCollectorId: string;
    healthRiskId: string;
    numberOfFemalesOver5: number;
    numberOfFemalesUnder5: number;
    numberOfMalesOver5: number;
    numberOfMalesUnder5: number;
    timestamp: Date;
    location: Location;
}
