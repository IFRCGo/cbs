import { AddStaffUser } from '../domain/addStaffUser';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import { StaffUser } from './staffUser';

const API_URL = 'http://localhost:5000/api/usermanagement';
const API_USER = API_URL + '/user';
const API_USERS = API_URL + '/users';

@Injectable()
export class StaffUserService {
  private headers = new Headers({ 'Content-Type': 'application/json' });

  constructor(private http: Http) { }

  saveUser(staffUser: StaffUser): Promise<void> {
    const addStaffUser = new AddStaffUser();
    addStaffUser.name = staffUser.name;

    return this.http
      .post(API_USER, JSON.stringify(addStaffUser), { headers: this.headers })
      .toPromise()
      .then(() => { console.log('staff user added successfully'); })
      .catch((error) => console.error(error));
  }

  getAllUsers(): Promise<void> {
    return this.http
      .get(API_USERS, { headers: this.headers })
      .map(response => response.json())
      .toPromise()
      .then((users) => { console.log(users); })
      .catch((error) => console.error(error));
  }
}
