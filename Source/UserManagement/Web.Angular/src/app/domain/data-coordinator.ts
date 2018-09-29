import { StaffUser } from './staff-user';

export class DataCoordinator extends StaffUser {
  age: number;
  sex: string;
  nationalSociety: string;
  project: string;
  preferredLanguage: string;
  longtitude: string;
  latitude: string;
  mobilePhoneNumber: string;
  assignedNationalSocieties: string;

  constructor(o: any) {
    super(o);
    this.age = o.age;
    this.sex = o.sex;
    this.nationalSociety = o.nationalSociety;
    this.project = o.project;
    this.preferredLanguage = o.preferredLanguage;
    this.longtitude = o.longtitude;
    this.latitude = o.latitude;
    this.mobilePhoneNumber = o.mobilePhoneNumber;
    this.assignedNationalSocieties = o.assignedNationalSocieties;
  }
}
