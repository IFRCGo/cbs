import { Location, HealthRisk } from './index';
import { Report } from './report.model';

export class InvalidCaseReportFromUnknownDataCollector implements Report {
    success(): boolean { return false; }
    id: string;
    timestamp: Date;
    phoneNumber: string;
    message: string;
    errorMessages: Array<string>;
}
