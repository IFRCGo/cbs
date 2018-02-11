import { StaffUser } from '../domain/staff-user';
import { NationalSociety } from '../domain/national-society';
import { environment } from '../../environments/environment';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

const API_URL = environment.api + '/api/usermanagement';
const API_USER = API_URL + '/staffuser';
const API_USERS = API_URL + '/staffusers';
const DELETE_USER = API_URL + '/delete/';

@Injectable()
export class StaffUserService {
  private headers = new Headers({'Content-Type': 'application/json'});

  constructor(private http: Http) {
  }

  saveUser(staffUser: StaffUser) {
    return this.http
      .post(API_USER, JSON.stringify(staffUser), {headers: this.headers});
      // .toPromise()
      // .then(() => staffUser)
      // .catch((error) => error);
  }

  getAllUsers() {
    return this.http
      .get(API_USERS, {headers: this.headers});
      // .map(response => response.json())
      // .toPromise()
      // .then((users) => {
      //   console.log(users);
      //   return users;
      // })
      // .catch((error) => console.error(error));
  }

  // TODO: Use result from api
  deleteUser(id: string): Promise<void> {
    return this.http
      .delete(DELETE_USER + id, {headers: this.headers})
      .toPromise()
      .then(() => console.log('User deleted' + id))
      .catch((error) => console.error(error));
  }

  // TOOD: Pull societies from FDRS
  getNationalSocieties(): Promise<Array<NationalSociety>> {
    return Promise.resolve([
      {id: 'nrx', displayName: 'Norwegian Red Cross (NRX)'},
      {id: 'drx', displayName: 'Danish Red Cross (DRX)'},
      {id: 'srx', displayName: 'Spanish Red Cross (SRX)'}
    ]);
  }
}
