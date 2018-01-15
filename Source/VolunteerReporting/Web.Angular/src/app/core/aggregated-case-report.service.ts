import 'rxjs/add/operator/toPromise';
import 'rxjs/add/observable/forkJoin';

import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import { Report } from '../shared/models/report.model';
import { CaseReport } from '../shared/models/index';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/forkJoin'; 
import { environment } from '../../environments/environment'; 

@Injectable()
export class AggregatedCaseReportService {
    private headers = new Headers({ 'Content-Type': 'application/json' });

    constructor(private http: Http) { }

    getReports(): Promise<void | Array<Report>> {

       /* 
        *  This code was left like this just because it works. The point is to fetch
        *  data from the four lists, and return a sorted array of these. This way is 
        *  probably the least efficient way, and should be improved by someone a more
        *  skilled javascript programmer than me // 2017-11-07 roarfred //
        */ 

        var caseReports = this.http.get(environment.api + '/api/casereports', { headers: this.headers });
        var caseReportsFromUnknownDataCollectors = this.http.get(environment.api + '/api/casereportsfromunknowndatacollectors', { headers: this.headers });
        var invalidCaseReports = this.http.get(environment.api + '/api/invalidcasereports', { headers: this.headers });
        var invalidCaseReportsFromUnknownDataCollectors = this.http.get(environment.api + '/api/invalidcasereportsfromunknowndatacollectors', { headers: this.headers });
        
        return Observable.forkJoin(
            caseReports, 
            caseReportsFromUnknownDataCollectors,
            invalidCaseReports,
            invalidCaseReportsFromUnknownDataCollectors
        )
            .toPromise()
            .then(([caseReports, caseReportsFromUnknownDataCollectors, invalidCaseReports, invalidCaseReportsFromUnknownDataCollectors]) => { 
                let array = caseReports.json()
                    .concat(caseReportsFromUnknownDataCollectors.json())
                    .concat(invalidCaseReports.json())
                    .concat(invalidCaseReportsFromUnknownDataCollectors.json());
                return array.sort((a:Report, b:Report) => a.timestamp > b.timestamp ? 1 : a.timestamp < b.timestamp ? -1 : 0);
             })
            .catch((error) => console.error(error));
    };
}