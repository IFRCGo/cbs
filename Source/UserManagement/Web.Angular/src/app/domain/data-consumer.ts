import { StaffUser } from './staff-user';

export class DataConsumer extends StaffUser {
    longtitude: string;
    latitude: string;

    constructor(params) {
        super(params);
        this.longtitude = params.longtitude;
        this.latitude = params.latitude;
    }
}
