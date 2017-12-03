import 'rxjs/add/operator/toPromise';

import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import { CaseReportFromUnknownDataCollector } from '../shared/models/case-report-from-unknown-data-collector.model';

@Injectable()
export class CaseReportFromUnknownDataCollectorService {
    private headers = new Headers({ 'Content-Type': 'application/json' });

    constructor(private http: Http) { }

    getAnonymousCaseReports(): Promise<Array<CaseReportFromUnknownDataCollector>> {
        return this.http
            .get('/api/casereportsfromunknowndatacollectors', { headers: this.headers })
            .toPromise()
            .then((result) => { return result.json(); })
            .catch((error) => console.error(error));
    }
}