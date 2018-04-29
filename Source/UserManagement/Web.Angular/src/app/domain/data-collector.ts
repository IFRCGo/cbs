import { Location } from './location.model';

class PhoneNumber {
    value: string;
    confirmed: boolean;
}

export class DataCollector {

    dataCollectorId: string;
    fullName: string;
    displayName: string;
    yearOfBirth: number;
    phoneNumbers: Array<PhoneNumber>;
    sex: number;
    preferredLanguage: number;
    location: Location;
    registeredAt: Date;
    lastReportRecievedAt: Date;

    constructor(o: any) {

        this.dataCollectorId = o.dataCollectorId;
        this.fullName = o.fullName;
        this.displayName = o.displayName;
        this.yearOfBirth = o.yearOfBirth;
        this.phoneNumbers = o.phoneNumbers;
        this.sex = o.sex;
        this.preferredLanguage = o.preferredLanguage;
        this.location = {
            longitude: o.longitude,
            latitude: o.latitude
        }
        this.registeredAt = o.registeredAt;
    }
}
