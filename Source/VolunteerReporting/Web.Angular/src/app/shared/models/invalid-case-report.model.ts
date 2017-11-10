import { Location, HealthRisk, DataCollector } from './index';
import { Report } from './report.model';

export class InvalidCaseReport implements Report {
    success(): boolean { return false; }
    id: string;
    timestamp: Date;
    dataCollector: DataCollector;
    message: string;
    errorMessages: Array<string>;
}
