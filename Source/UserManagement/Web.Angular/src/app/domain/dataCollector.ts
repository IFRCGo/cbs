export class PhoneNumber {
    value: string;
    confirmed: boolean;
}

export class Location {
    latitude: number;
    longitude: number;
}

export class DataCollector {
    id: string;
    fullName: string;
    displayName: string;
    age: number;
    sex: string;
    nationalSociety: string;
    preferredLanguage: string;
    location: Location;
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
        this.location = o.location;
        this.phoneNumbers = o.phoneNumbers;
        this.email = o.email;
        this.registeredAt = o.registeredAt;
    }
}
