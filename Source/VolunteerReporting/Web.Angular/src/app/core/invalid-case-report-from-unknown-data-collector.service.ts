import 'rxjs/add/operator/toPromise';

import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import { InvalidCaseReportFromUnknownDataCollector } from '../shared/models/invalid-case-report-from-unknown-data-collector.model';

@Injectable()
export class InvalidCaseReportFromUnknownDataCollectorService {
    private headers = new Headers({ 'Content-Type': 'application/json' });

    constructor(private http: Http) { }

    getAnonymousCaseReports(): Promise<Array<InvalidCaseReportFromUnknownDataCollector>> {
        return this.http
            .get('/api/invalidcasereportsfromunknowndatacollectors', { headers: this.headers })
            .toPromise()
            .then((result) => { return result.json(); })
            .catch((error) => console.error(error));
    }
}