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
    longitude: number;
    latitude: number;


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
        this.longitude = o.longitude;
        this.latitude = o.latittude;
    }
}
