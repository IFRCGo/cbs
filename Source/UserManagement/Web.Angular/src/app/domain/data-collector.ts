export class DataCollector {
    dataCollectorId: string;
    fullName: string;
    displayName: string;
    yearOfBirth: number;
    phoneNumberString: string;
    phoneNumbers: Array<string>;
    sex: string;
    nationalSociety: string;
    preferredLanguage: string;
    gpsLocation: {
        latitude: number,
        longitude: number
    }
    registeredAt: Date;

    constructor(o: any) {
        this.dataCollectorId = '9bab0577-2d7e-4c6f-a8dc-41491740d4c3';
        this.fullName = o.fullName;
        this.displayName = o.displayName;
        this.yearOfBirth = o.yearOfBirth;
        this.phoneNumberString = o.phoneNumberString;
        this.phoneNumbers = o.phoneNumbers;
        this.sex = o.sex;
        this.nationalSociety = o.nationalSociety;
        this.preferredLanguage = o.preferredLanguage;
        this.gpsLocation = {
            longitude: o.longitude,
            latitude: o.latitude   
        }
        this.registeredAt = o.registeredAt;
    }
}
