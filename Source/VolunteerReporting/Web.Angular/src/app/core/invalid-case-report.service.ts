import 'rxjs/add/operator/toPromise';

import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import { InvalidCaseReport } from '../shared/models/invalid-case-report.model';
import { environment } from '../../environments/environment'; 

@Injectable()
export class InvalidCaseReportService {
    private headers = new Headers({ 'Content-Type': 'application/json' });

    constructor(private http: Http) { }

    getCaseReports(): Promise<Array<InvalidCaseReport>> {
        return this.http
            .get(environment.api + '/api/invalidcasereports', { headers: this.headers })
            .toPromise()
            .then((result) => { return result.json(); })
            .catch((error) => console.error(error));
    }
}