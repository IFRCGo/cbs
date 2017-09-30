export class DataCollector {
    firstName: string;
    lastName: string;
    age: number;
    sex: string;
    nationalSociety: string;
    preferredLanguage: string;
    gpsLocation: string;
    mobilePhoneNumber: string;
    email: string;

    constructor(o: any) {
        this.firstName = o.name;
        this.lastName = o.lastName;
        this.age = o.age;
        this.sex = o.sex;
        this.nationalSociety = o.nationalSociety;
        this.preferredLanguage = o.preferredLanguage;
        this.gpsLocation = o.gpsLocation;
        this.mobilePhoneNumber = o.mobilePhoneNumber;
        this.email = o.email;
    }
}
