export class StaffUser {
    fullName: string;
    displayName: string;
    age: number;
    sex: string;
    nationalSociety: string;
    preferredLanguage: string;
    mobilePhoneNumber: string;
    email: string;

    constructor(o: any) {
        this.fullName = o.fullName;
        this.displayName = o.displayName;
        this.age = o.age;
        this.sex = o.sex;
        this.nationalSociety = o.nationalSociety;
        this.preferredLanguage = o.preferredLanguage;
        this.mobilePhoneNumber = o.mobilePhoneNumber;
        this.email = o.email;
    }
}
