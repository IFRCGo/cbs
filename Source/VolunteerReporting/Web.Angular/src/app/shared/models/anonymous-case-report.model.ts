import { Location, HealthRisk } from './index';

export class AnonymousCaseReport {
    id: string;
    healthRisk: HealthRisk;
    numberOfFemalesOver5: number;
    numberOfFemalesUnder5: number;
    numberOfMalesOver5: number;
    numberOfMalesUnder5: number;
    timestamp: Date;
    location: Location;
}
