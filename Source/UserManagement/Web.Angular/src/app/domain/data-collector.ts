export class DataCollector {
    id: string;
    fullName: string;
    displayName: string;
    yearOfBirth: number;
    sex: string;
    nationalSociety: string;
    preferredLanguage: string;
    latitude: string;
    longtitude: string;
    registeredAt: Date;

    constructor(o: any) {
        this.id = o.id;
        this.fullName = o.fullName;
        this.displayName = o.displayName;
        this.yearOfBirth = o.yearOfBirth;
        this.sex = o.sex;
        this.nationalSociety = o.nationalSociety;
        this.preferredLanguage = o.preferredLanguage;
        this.longtitude = o.longtitude;
        this.latitude = o.latitude;
        this.registeredAt = o.registeredAt;
    }
}
