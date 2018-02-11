import { StaffUser } from './staff-user';
import { Sex } from './sex';
import { NationalSociety } from './national-society';
import { Location } from './location';

export class DataVerifier extends StaffUser {
    age: number;
    sex: Sex;
    nationalSociety: NationalSociety;
    project: string;
    preferredLocation: Location;
    gpsLocation: Location;
    mobilePhoneNumbers: Array<string>;

    constructor(params) {
        super(params);

        this.age = params.age;
        this.sex = params.sex;
        this.nationalSociety = params.nationalSociety;
        this.project = params.project;
        this.preferredLocation = params.preferredLocation;
        this.gpsLocation = params.gpsLocation;
        this.mobilePhoneNumbers = params.mobilePhoneNumbers;
    }
}