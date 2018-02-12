class PhoneNumber {
    value: string;
    confirmed: boolean;
}

export class DataCollector {
    id: string;
    fullName: string;
    displayName: string;
    age: number;
    sex: string;
    nationalSociety: string;
    preferredLanguage: string;
    latitude: string;
    longtitude: string;
    phoneNumbers: Array<PhoneNumber>;
    email: string;
    registeredAt: Date;

    constructor(o: any) {
        this.id = o.id;
        this.fullName = o.fullName;
        this.displayName = o.displayName;
        this.age = o.age;
        this.sex = o.sex;
        this.nationalSociety = o.nationalSociety;
        this.preferredLanguage = o.preferredLanguage;
        this.longtitude = o.longtitude;
        this.latitude = o.latitude;
        this.phoneNumbers = o.phoneNumbers;
        this.email = o.email;
        this.registeredAt = o.registeredAt;
    }
}
