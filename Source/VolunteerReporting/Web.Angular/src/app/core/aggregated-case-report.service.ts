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

    getLimitFirstReports(limit: number): Promise<void | Array<CaseReportForListing>> {
        return this.http.get(environment.api + "/api/casereports/getlimitfirst?limit=" + limit, {headers: this.headers})
            .toPromise()
            .then(result => {return result.json();})
            .catch(error => console.error(error));
    }

    getLimitLastReports(limit: number): Promise<void | Array<CaseReportForListing>> {
        return this.http.get(environment.api + "/api/casereports/getlimitlast?limit=" + limit, {headers: this.headers})
            .toPromise()
            .then(result => {return result.json();})
            .catch(error => console.error(error));
    }
    
    getReports(): Promise<void | Array<CaseReportForListing>> {
        
        return this.http.get(environment.api + "/api/casereports", {headers: this.headers})
            .toPromise()
            .then(result => {return result.json(); })
            .catch(error => console.error(error)); 
    }
}