import { StaffUser } from './staff-user';
import { Sex } from './sex';
import { NationalSociety } from './national-society';

export class DataVerifier extends StaffUser {
    age: number;
    sex: Sex;
    nationalSociety: NationalSociety;
    preferredLanguage: string;
    longtitude: string;
    latitude: string;
    mobilePhoneNumber: string;

    constructor(params) {
        super(params);

        this.age = params.age;
        this.sex = params.sex;
        this.nationalSociety = params.nationalSociety;
        this.preferredLanguage = params.preferredLocation;
        this.longtitude = params.longtitude;
        this.latitude = params.latitude;
        this.mobilePhoneNumber = params.mobilePhoneNumber;
    }
}
