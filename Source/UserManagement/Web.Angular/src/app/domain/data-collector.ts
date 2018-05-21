import { Location } from './location.model';

class PhoneNumber {
    value: string;
    confirmed: boolean;
}

export class DataCollector {

    id: string;
    fullName: string;
    displayName: string;
    yearOfBirth: number;
    phoneNumbers: Array<PhoneNumber>;
    sex: number;
    preferredLanguage: number;
    location: Location;
    registeredAt: Date;
    lastReportRecievedAt: Date;

    district: string;
    region: string;
    village: string;

    constructor(o: any) {

        this.id = o.id;
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
        this.district = o.district;
        this.region = o.region;
        this.village = o.village;
        this.registeredAt = o.registeredAt;
    }
}
