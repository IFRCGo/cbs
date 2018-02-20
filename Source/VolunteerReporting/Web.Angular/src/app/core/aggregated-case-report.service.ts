import 'rxjs/add/operator/toPromise';
import 'rxjs/add/observable/forkJoin';

import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import { Report } from '../shared/models/report.model';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/forkJoin'; 
import { environment } from '../../environments/environment'; 
import { CaseReportForListing } from '../shared/models/case-report-for-listing.model';

@Injectable()
export class AggregatedCaseReportService {
    private headers = new Headers({ 'Content-Type': 'application/json' });

    constructor(private http: Http) { }

    getReports(): Promise<void | Array<CaseReportForListing>> {
        
        return this.http.get(environment.api + "/api/casereports/casereportsforlisting", {headers: this.headers})
            .toPromise()
            .then(result => {return result.json(); })
            .catch(error => console.error(error)); 
            //Question: Should I even bother having the view initiated with a 
            //list sorted by the timestamp when the user can do so himself?
             
        
    }
    /* Obsolete
    getReports(): Promise<void | Array<Report>> {

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
    };*/
}