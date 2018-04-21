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
    phoneNumberString: string;
    phoneNumbers: Array<PhoneNumber>;
    sex: string;
    preferredLanguage: string;
    location: Location;
    registeredAt: Date;
    lastReportRecievedAt: Date;

    constructor(o: any) {

        this.dataCollectorId = o.id;
        this.fullName = o.fullName;
        this.displayName = o.displayName;
        this.yearOfBirth = o.yearOfBirth;
        this.phoneNumberString = o.phoneNumberString;
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
