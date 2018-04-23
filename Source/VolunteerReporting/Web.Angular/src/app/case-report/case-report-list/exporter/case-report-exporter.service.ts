import {Injectable} from '@angular/core';
import {CaseReportForListing} from '../../../shared/models/case-report-for-listing.model';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/observable/forkJoin';

import {Headers, Http} from '@angular/http';

import {environment} from '../../../../environments/environment';

@Injectable()
export class CaseReportExporter {
  private headers = new Headers({'Content-Type': 'application/json'});
  constructor(private http: Http) {
  }

  exportToCsv(listedReports: Array<CaseReportForListing>, fields: Array<string>) {
    //TODO: Should export the list of CaseReports using the various applied filters on the list to produce a
    // csv file that will be downloaded by the client.
    // I have not figured out to do this yet, I tried looking it up, tried using different packages, but it
    // all just grew into a mess and nothing worked. That's why I have not done anything here atm.
    // We really should have someone that has experience with this frontend here.
    // --Woksin

    // TODO: From woksin: I think that this shoul be a backend thing. The way I'm seeing it we only want
    // to do a request call with the filters we want to use, and what we are sorting on perhaps, and let the
    // backend do the job. Sending an Array of CaseReportForListing would be pretty slow.

  }
  exportToPdf(/* filters, orderby */): Promise<void | any> {
    //TODO: Export to pdf should work on the backend now, we just need to make a button for exporting
    return this.http.get(`${environment.api}/api/casereports/export/pdf`, {headers: this.headers})
      .toPromise()
      .then(res => {
          return res;
      })
      .catch(error => console.error(error));
  }
}
