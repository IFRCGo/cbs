import { Location } from "./location.model";

class PhoneNumber {
    value: string;
    confirmed: boolean;
}

export class DataCollector {
    dataCollectorId: string;
    fullName: string;
    displayName: string;
    yearOfBirth: number;
    sex: string;
    nationalSociety: string;
    preferredLanguage: string;
    location: Location;
    phoneNumbers: Array<PhoneNumber>;
    registeredAt: Date;
    lastReportRecievedAt: Date;

    constructor(o: any) {
        this.dataCollectorId = o.id;
        this.fullName = o.fullName;
        this.displayName = o.displayName;
        this.yearOfBirth = o.age;
        this.sex = o.sex;
        this.nationalSociety = o.nationalSociety;
        this.preferredLanguage = o.preferredLanguage;
        this.location = o.location;
        this.phoneNumbers = o.phoneNumbers;
        this.registeredAt = o.registeredAt;
    }
}
