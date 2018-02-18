import 'rxjs/add/operator/toPromise';

import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import { CaseReport } from '../shared/models/case-report.model';
import { environment } from '../../environments/environment'; 

@Injectable()
export class CaseReportService {
    private headers = new Headers({ 'Content-Type': 'application/json' });

    constructor(private http: Http) { }

    getCaseReports(): Promise<Array<CaseReport>> {
        // endpoint is obsolete and should be updated after the view has been adapted to the new read model (which will be /api/casereports again). 
        return this.http
            .get(environment.api + '/api/casereportsobsolete', { headers: this.headers })
            .toPromise()
            .then((result) => { return result.json(); })
            .catch((error) => console.error(error));
    }
}