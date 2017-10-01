export class StaffUser {
    firstName: string;
    lastName: string;
    age: number;
    sex: string;
    nationalSociety: string;
    projectName: string;
    preferredLanguage: string;
    mobilePhoneNumber: string;
    email: string;

    constructor(o: any) {
        this.firstName = o.firstName;
        this.lastName = o.lastName;
        this.age = o.age;
        this.sex = o.sex;
        this.nationalSociety = o.nationalSociety;
        this.projectName = o.projectName;
        this.preferredLanguage = o.preferredLanguage;
        this.mobilePhoneNumber = o.mobilePhoneNumber;
        this.email = o.email;
    }
}
