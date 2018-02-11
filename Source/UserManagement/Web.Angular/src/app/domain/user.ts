import { UserType } from './userType.enum';
import { Sex } from './sex.enum';

export class User {
  firstName: string;
  lastName: string;
  mobilePhoneNumber: string;
  email: string;
  userType: UserType;
  age: number;
  sex: Sex;
  nationalSociety: string;
  project: string;
  preferredLanguage: string;
  lat: string;
  long: string;
  assignedNationalSocieties: string;
  position: string;
  dutyStation: string;
  location: string;

  constructor(o: any) {
    this.firstName = o.firstName;
    this.lastName = o.lastName;
    this.mobilePhoneNumber = o.mobilePhoneNumber;
    this.email = o.email;
    this.userType = o.userType;
    this.age = o.age;
    this.sex = o.sex;
    this.nationalSociety = o.nationalSociety;
    this.project = o.project;
    this.preferredLanguage = o.preferredLanguage;
    this.lat = o.lat;
    this.long = o.long;
    this.assignedNationalSocieties = o.assignedNationalSocieties;
    this.position = o.position;
    this.dutyStation = o.dutySation;
    this.location = o.location;

  }
}
