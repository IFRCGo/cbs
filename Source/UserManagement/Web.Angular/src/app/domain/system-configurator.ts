import { StaffUser } from './staffUser';

export class SystemConfigurator extends StaffUser {
  age: number;
  sex: string;
  nationalSociety: string;
  project: string;
  preferredLanguage: string;
  lat: string;
  long: string;
  mobilePhoneNumber: string;
  assignedNationalSocieties: string;

  constructor(o: any) {
    super(o);
    this.age = o.age;
    this.sex = o.sex;
    this.nationalSociety = o.nationalSociety;
    this.project = o.project;
    this.preferredLanguage = o.preferredLanguage;
    this.lat = o.lat;
    this.long = o.long;
    this.mobilePhoneNumber = o.mobilePhoneNumber;
    this.assignedNationalSocieties = o.assignedNationalSocieties;
  }

}