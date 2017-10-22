import 'rxjs/add/operator/toPromise';

import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import { AnonymousCaseReport } from '../shared/models/anonymous-case-report.model';

@Injectable()
export class AnonymousCaseReportService {
    private headers = new Headers({ 'Content-Type': 'application/json' });

    constructor(private http: Http) { }

    getAnonymousCaseReports(): Promise<Array<AnonymousCaseReport>> {
        return this.http
            .get('/api/anonymouscasereports', { headers: this.headers })
            .toPromise()
            .then((result) => { return result.json(); })
            .catch((error) => console.error(error));
    }
}