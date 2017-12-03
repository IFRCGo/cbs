import 'rxjs/add/operator/toPromise';

import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import { NationalSociety } from '../shared/models/index';

@Injectable()
export class NationalSocietyService {
    private headers = new Headers({ 'Content-Type': 'application/json' });

    constructor(private http: Http) { }

    getNationalSocieties(): Promise<Array<NationalSociety>> {
        return this.http
            .get('/api/nationalsociety', { headers: this.headers })
            .toPromise()
            .then((result) => { return result.json(); })
            .catch((error) => console.error(error));
    }
}