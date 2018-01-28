import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { ApiService } from './api.service';
import { User } from '../shared/models/index';

@Injectable()
export class UserService {

    constructor(private apiService: ApiService) { }

    getProjectOwners(nationalSocietyId: string): Observable<Array<User>> {
        return this.apiService
            .get(`/api/user?nationalSocietyId=${nationalSocietyId}`);
    }
}