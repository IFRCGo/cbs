import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { ApiService } from './api.service';
import { NationalSociety } from '../shared/models/index';

@Injectable()
export class NationalSocietyService {

    constructor(private apiService: ApiService) { }

    getNationalSocieties(): Observable<Array<NationalSociety>> {
        return this.apiService
            .get('/api/nationalsociety');
    }
}