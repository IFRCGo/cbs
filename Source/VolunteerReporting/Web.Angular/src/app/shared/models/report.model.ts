import { Location, DataCollector, HealthRisk } from './index';

export interface Report {
    id: string;
    timestamp: Date;
    success(): boolean;
}
