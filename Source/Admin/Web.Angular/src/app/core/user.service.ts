import 'rxjs/add/operator/toPromise';

import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import { environment } from '../../environments/environment';

import { User } from '../shared/models/index';

@Injectable()
export class UserService {
    private headers = new Headers({ 'Content-Type': 'application/json' });

    constructor(private http: Http) { }

    getProjectOwners(nationalSocietyId: string): Promise<Array<User>> {
        return this.http
            .get(environment.api + '/api/user?nationalSocietyId=${nationalSocietyId}', { headers: this.headers })
            .toPromise()
            .then((result) => { return result.json(); })
            .catch((error) => console.error(error));
    }
}