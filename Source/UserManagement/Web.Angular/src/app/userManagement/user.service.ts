import { AddUser } from '../domain/addUser';
import 'rxjs/add/operator/toPromise';

import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import { User } from './user';


@Injectable()
export class UserService {
  private headers = new Headers({ 'Content-Type': 'application/json' });

  constructor(private http: Http) { }

  saveUser(user: User): Promise<void> {
    const url = `http://localhost:5000/api/usermanagement/user`;

    const addUser = new AddUser();
    addUser.name = user.name;

    return this.http
      .post(url, JSON.stringify(addUser), { headers: this.headers })
      .toPromise()
      .then(() => { console.log('user added successfully'); })
      .catch((error) => console.error(error));
  }

  getAllUsers(): Promise<void> {
    const url = 'http://localhost:5000/api/usermanagement/users';

    return this.http
      .get(url, { headers: this.headers })
      .toPromise()
      .then((users) => { console.log(users); })
      .catch((error) => console.error(error));
  }
}
