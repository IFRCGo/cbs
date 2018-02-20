import { Location } from './index';

export interface Report {
    id: string;
    timestamp: Date;
    success(): boolean;
}
